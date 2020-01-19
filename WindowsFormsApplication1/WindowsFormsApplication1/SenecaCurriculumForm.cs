using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class SenecaCurriculumForm : Form
    {
        public SenecaCurriculumForm()
        {
            InitializeComponent();

            List<CollegeProgram> AllCollegePrograms = new XMLFile("SenecaCurriculumDatabase.xml").AllPrograms;

            foreach (CollegeProgram program in AllCollegePrograms)
            {
                program.AddToTreeView(CourseTreeView);
            }


            /*
            //Semester 1 
            Course ETY155 = new Course("ETY155", 1, "ECT");
            Course PRG155 = new Course("PRG155", 1, "ECT");

            Course LIN155 = new Course("LIN155", 1, "ECT");
            Course ICO155 = new Course("ICO155", 1, "ECT");
            Course MTH155 = new Course("MTH155", 1, "ECT");
            Course COM101 = new Course("COM101", 1, "ECT");

            //Semester 2 
            Course PRG255 = new Course("PRG255", 2, "ECT", new List<Course> { PRG155}); //HSI CORE
            Course HSI255 = new Course("HSI255", 2, "ECT", new List<Course> { ETY155}); //PRG2 CORE
            //PRG255.Corerequisites.Add(HSI255);
            //HSI255.Corerequisites.Add(PRG255);
            PRG255.AddCorerequisite(HSI255);

            Course LNX255 = new Course("LNX255", 2, "ECT", new List<Course> { ICO155 });
            Course APL255 = new Course("APL255", 2, "ECT", new List<Course> { ICO155 });
            Course MTH255 = new Course("MTH255", 2, "ECT", new List<Course> { MTH155 });
            Course IPS255 = new Course("IPS255", 2, "ECT", new List<Course> { LIN155 });
            //Semester 3
            Course MCO455 = new Course("MCO455", 3, "ECT", new List<Course> { PRG255 });
            Course DGS255 = new Course("DGS255", 3, "ECT", new List<Course> { HSI255 });
            MCO455.AddCorerequisite(DGS255);

            Course APL355 = new Course("APL355", 3, "ECT", new List<Course> { APL255 });
            Course NET455 = new Course("NET455", 3, "ECT", new List<Course> { APL255 });
            Course PRG355 = new Course("PRG355", 3, "ECT", new List<Course> { PRG255 });
            //Semester 4
            Course TEC400 = new Course("TEC400", 4, "ECT", new List<Course> { COM101 });
            Course ECP455 = new Course("ECP455", 4, "ECT", new List<Course> { MTH255,IPS255 });
            Course NSP655 = new Course("NSP655", 4, "ECT", new List<Course> { NET455 });
            Course PRG455 = new Course("PRG455", 4, "ECT", new List<Course> { PRG355 });
            Course MTH356 = new Course("MTH356", 4, "ECT", new List<Course> { MTH255 });
            //Semester 5
            Course ETD555 = new Course("ETD555", 5, "ECT", new List<Course> { ECP455 });
            Course WCM555 = new Course("WCM555", 5, "ECT", new List<Course> { MCO455,PRG455 });
            Course SEC555 = new Course("SEC555", 5, "ECT", new List<Course> { NSP655 });
            Course NET556 = new Course("NET556", 5, "ECT", new List<Course> { NSP655 });
            Course PRG550 = new Course("PRG550", 5, "ECT", new List<Course> { PRG455 });
            //Semester 6  
            Course TPJ655 = new Course("TPJ655", 6, "ECT", new List<Course> { MCO455,TEC400,ETD555 });
            Course MCO556 = new Course("MCO556", 6, "ECT", new List<Course> { ETD555,MCO455});
            Course PRG650 = new Course("PRG650", 6, "ECT", new List<Course> { PRG550 });
            Course AMT453 = new Course("AMT453", 6, "ECT", new List<Course> { MTH356 });

            Semester Semester1 = new Semester(1, new List<Course> {ETY155,PRG155,LIN155,ICO155,MTH155,COM101 });
            Semester ECTSemester2 = new Semester(2, new List<Course> {PRG255,HSI255,LNX255,APL255,MTH255,IPS255});
            Semester ECTSemester3 = new Semester(3, new List<Course> {MCO455,DGS255,APL355,NET455,PRG355});
            Semester ECTSemester4 = new Semester(4, new List<Course> {TEC400,ECP455,NSP655,PRG455,MTH356});
            Semester ECTSemester5 = new Semester(5, new List<Course> {PRG550,NET556,SEC555,WCM555,ETD555 });
            Semester ECTSemester6 = new Semester(6, new List<Course> {TPJ655,MCO556,PRG650,AMT453});

            CollegeProgram ECT = new CollegeProgram("ECT", new List<Semester> { Semester1, ECTSemester2, ECTSemester3, ECTSemester4, ECTSemester5, ECTSemester6 });


            Course EEN_ELD255 = new Course("ELD255", new List<Course> {LIN155,ETY155});
            Course EEN_MIR355 = new Course("MIR355", new List<Course> {ICO155});
            Course EEN_PRG255 = new Course("PRG255", new List<Course> {ICO155,PRG155});

            Course EEN_MTH255 = new Course("MTH255", new List<Course> { MTH155});
            Course EEN_ECR255 = new Course("ECR255", new List<Course> { LIN155, ETY155 });
            EEN_ECR255.AddCorerequisite(EEN_MTH255);

            Course EEN_IPS255 = new Course("IPS255", new List<Course> {LIN155});
            
            Course EEN_COM455 = new Course("COM455", new List<Course> { EEN_ECR255,EEN_ELD255,EEN_MTH255});

            Course EEN_DGS255 = new Course("DGS255", new List<Course> { EEN_ELD255});
            Course EEN_MCO455 = new Course("MCO455", new List<Course> { EEN_PRG255 });
            EEN_DGS255.AddCorerequisite(EEN_MCO455);

            Course EEN_NET455 = new Course("NET455", new List<Course> { EEN_MIR355});
            Course EEN_MEC300 = new Course("MEC300", new List<Course> {EEN_ECR255,EEN_ELD255 });
            Course EEN_TEC400 = new Course("TEC400", new List<Course> { COM101});
            Course EEN_TPJ452 = new Course("TPJ452", new List<Course> { EEN_MCO455,EEN_DGS255});
            EEN_TEC400.AddCorerequisite(EEN_TPJ452);


            Course EEN_ECP455 = new Course("ECP455", new List<Course> { COM101,EEN_IPS255});

            Semester EENSemester2 = new Semester(2,new List<Course> {EEN_ECR255,EEN_ELD255,EEN_MIR355,EEN_PRG255,EEN_MTH255,EEN_IPS255 });
            Semester EENSemester3 = new Semester(3, new List<Course> {EEN_MCO455,EEN_COM455,EEN_DGS255,EEN_NET455,EEN_MEC300});
            Semester EENSemester4 = new Semester(4, new List<Course> {EEN_TEC400,EEN_TPJ452,EEN_ECP455});

            CollegeProgram EEN = new CollegeProgram("EEN", new List<Semester> {Semester1,EENSemester2,EENSemester3,EENSemester4 });
            */

            //new CoursesFile().UpdateFile(new List<CollegeProgram> { ECT, EEN });

            //XmlSerializer ser = new XmlSerializer(typeof(List<CollegeProgram>));
            //TextWriter writer = new StreamWriter("blahagstgh.xml");// "CollegeProgram.txt");
            //ser.Serialize(writer, new List<CollegeProgram> {ECT,EEN });

            //writer.Close();





            /*

            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });
            Course EET_ECR255 = new Course("____55", new List<Course> { });

            CollegeProgram EET = new CollegeProgram("EET", new List<Semester> { Semester1 });




            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            Course EMA_ECR255 = new Course("____55", new List<Course> { });
            

            //CollegeProgram EMA = new CollegeProgram("EMA", new List<Semester> { Semester1 });
            ECT.AddToTreeView(CourseTreeView);
            EEN.AddToTreeView(CourseTreeView);

            */
            /*
            List<Course> allCourses = new List<Course> { TPJ655,MCO556,PRG650,AMT453,PRG550,NET556,SEC555,
                WCM555,ETD555,MTH356,PRG455,NSP655,ECP455,TEC400,PRG355,NET455,APL355,
            DGS255,MCO455,IPS255,MTH255,APL255,LNX255,HSI255,PRG255,COM101,MTH155,ICO155,LIN155,PRG155,ETY155};
            */

            //new CoursesFile().UpdateFile(allCourses);

            //List<Course> allCourses = new CoursesFile().AllCourses;



            //TreeNode temp = CourseTreeView.Nodes.Add("Semester1");

            //ECT.AddToTreeView(CourseTreeView);

            //new CoursesFile().AllPrograms[0].AddToTreeView(CourseTreeView);



            //new CoursesFile().UpdateFile(new List<CollegeProgram> { ECT });


            //foreach (Course course in allCourses)
            //{
                //course.AddToTreeView(CourseTreeView);//temp);//CourseTreeView);
                

            //}

            //TreeNode node = CourseTreeView.Nodes.Add("ECT");

            //node.Nodes.Add("esgg");

            //node.Name
            //TreeNode nofffde = CourseTreeView.Nodes.Add(node.Name);


            //HSI255.AddToTreeView(CourseTreeView);
            //DGS255.AddToTreeView(CourseTreeView);



            //TPJ655.AddToTreeView(CourseTreeView);
            //MCO556.AddToTreeView(CourseTreeView);
            //PRG650.AddToTreeView(CourseTreeView);
            //AMT453.AddToTreeView(CourseTreeView);



            //PRG255.AddToTreeView(CourseTreeView);


            //ETY155.AddToTreeView(CourseTreeView);

            //DGS255.AddToTreeView(CourseTreeView);

            //TPJ655.AddToTreeView(CourseTreeView);

            //XmlSerializer ser = new XmlSerializer(typeof(List<Room>));
            //TextWriter writer = new StreamWriter("test.txt");
            //ser.Serialize(writer, AllRooms);


        }




    }
}
