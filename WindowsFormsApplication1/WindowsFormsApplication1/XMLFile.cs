using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public class XMLFile
    {
        private string fileName;
        //public List<Course> AllCourses;

        public List<CollegeProgram> AllPrograms;


        public XMLFile(string fileName) //Deserialize the file
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<CollegeProgram>));
            StreamReader reader = new StreamReader(fileName);//"CollegeProgram.txt");

            AllPrograms = (List<CollegeProgram>)ser.Deserialize(reader);

            this.fileName = fileName;

            reader.Close();
        }

        public void UpdateFile(List<CollegeProgram> AllPrograms)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<CollegeProgram>));
            TextWriter writer = new StreamWriter(fileName);// "CollegeProgram.txt");
            ser.Serialize(writer, AllPrograms);

            writer.Close();
        }


    }
}
