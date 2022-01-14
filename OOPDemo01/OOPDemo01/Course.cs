using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo01
{
    internal class Course
    {
        #region Readonly Data Fields
        public readonly string CourseNo;
        public readonly string CourseName;
        //public readonly List<string> Students = new List<string>();
        public readonly List<string> Students = new List<string>();
        #endregion

        #region Readonly Property
        public int StudentCount
        {
            get { return Students.Count; }
        }
        #endregion

        #region Constructors
        public Course(string courseNo, string courseName)
        {
            // Validate that courseNo is not null,
            // or an empty string
            // and must contains exactly 8 characters
            // where the first 4 characters are letters and the last 4 characters
            // are digits
            if ( string.IsNullOrEmpty( courseNo ) )
            {
                throw new ArgumentNullException("CourseNo is required.");
            }
            if ( courseNo.Length != 8)
            {
                throw new ArgumentException("CourseNo contain exactly 8 characters.");
            }
            
            CourseNo = courseNo;
                     

            // Validate that courseName is not null or an empty string
            if ( string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentNullException("CourseName is required.");
            }
            CourseName = courseName;   
            
        }
        #endregion

        #region Instance-Level Methods
        public void AddStudent(string name)
        {
            Students.Add(name);
        }
        public void RemoveStudent(string name)
        {
            Students.Remove(name);
        }

        public bool SaveToFile(string filePath)
        {
            bool success;

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write to the file the CourseNo and CourseName
                    writer.WriteLine($"{CourseNo}");
                    writer.WriteLine($"{CourseName}");
                    // Write to the file the name of all the students in the course
                    foreach (var student in Students)
                    {
                        writer.WriteLine(student);
                    }
                    writer.Close();
                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            
            return success;
        }

        public bool LoadFromFile(string filePath)
        {
            bool success = false;

            try
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    // Read the CourseNo and CourseName from the file
                    var CourseNo = reader.ReadLine();
                    var CourseName = reader.ReadLine();
                    // Read the student names from the file
                    while (reader.EndOfStream == false)
                    {
                        string? lineData = reader.ReadLine();
                        if (!string.IsNullOrEmpty(lineData))
                        {
                            Students.Add(lineData);
                        }
                        //Students.Add(reader.ReadLine());    
                    }

                }
                success = true;
            }
            catch
            {
                success = false;
            }
           

            
            return success;
        }
        #endregion

    }
}
