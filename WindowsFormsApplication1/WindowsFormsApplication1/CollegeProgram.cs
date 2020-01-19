using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class CollegeProgram
    {
        public string ProgramName { get; set; }
        public List<Semester> AllSemesters;

        public CollegeProgram() { }

        public CollegeProgram(string ProgramName, List<Semester> AllSemesters)
        {
            this.ProgramName = ProgramName;
            this.AllSemesters = AllSemesters;
        }

        public void AddToTreeView(TreeView treeView)
        {
            TreeNode ProgramNode = treeView.Nodes.Add(ProgramName);

            foreach (Semester semester in AllSemesters)
            {
                TreeNode semesterNode = ProgramNode.Nodes.Add("Semester " + semester.semester.ToString());
                foreach (Course course in semester.allCourses)
                {
                    TreeNode courseNode = semesterNode.Nodes.Add(course.CourseName);
                    course.AddToTreeView(courseNode);
                }
            }
        }
    }
}
