using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public class Course
    {
        public string CourseName { get; set; }
        //public int Semester { get; private set; }
        //public string Program { get; private set; }

        [XmlElement("Prerequisites")]
        public List<Course> Prerequisites;
        [XmlElement("Corerequisites")]
        public List<string> Corerequisites;

        public Course() { }

        [Obsolete("Semester and Program values do not exist in this class anymore")]
        public Course(string CourseName, int Semester, string Program, List<Course> Prerequisites = null)
        {
            this.CourseName = CourseName;
            //this.Semester = Semester;
            //this.Program = Program;
            this.Prerequisites = Prerequisites;
            //this.Corerequisites = Corerequisites;
        }
        public Course(string CourseName, List<Course> Prerequisites = null)
        {
            this.CourseName = CourseName;
            this.Prerequisites = Prerequisites;
        }

        public void AddCorerequisite(Course course)
        {
            if (Corerequisites == null) { Corerequisites = new List<string>(); }
            Corerequisites.Add(course.CourseName);
            if (course.Corerequisites == null) { course.Corerequisites = new List<string>(); }
            course.Corerequisites.Add(CourseName);
        }

        public void AddToTreeView(TreeNode node, bool IncludeCorereqs = true)//int level)
        {
            if (Prerequisites != null)
            {
                foreach (Course prerequisite in Prerequisites)
                {
                    TreeNode nextNode = node.Nodes.Add(prerequisite.CourseName);
                    prerequisite.AddToTreeView(nextNode);
                }
            }
            if (Corerequisites != null && IncludeCorereqs == true)
            {
                //foreach (Course corerequisite in Corerequisites)
                foreach(string corerequisite in Corerequisites)
                {
                    TreeNode nextNode = node.Nodes.Add(corerequisite);
                    //corerequisite.AddToTreeView(nextNode, false);
                }
            }
        }
    }
}
