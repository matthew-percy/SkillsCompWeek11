using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Semester
    {
        public List<Course> allCourses;
        public int semester { get; set; }


        public Semester() { }

        public Semester(int semester, List<Course> allCourses)
        {
            this.semester = semester;
            this.allCourses = allCourses;
        }


    }
}
