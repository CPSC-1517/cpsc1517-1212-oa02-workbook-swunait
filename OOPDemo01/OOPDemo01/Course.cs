using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo01
{
    public class Course
    {
        #region Readonly Data Fields
        public readonly string CourseNo;

        //// Define a backing field for CourseName
        //private string _CourseName;
        //// Define a private set property for CourseNae
        //public string CourseName
        //{
        //    get { return _CourseName; }
        //    private set // can only be changed by methods within this class. External code will not be allowed to change this value.
        //    {
        //        // Validate that courseName is not null or an empty string
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            throw new ArgumentNullException("Course CourseName value is required.");
        //        }
        //        _CourseName = value.Trim();
        //    }
        //}
        public string CourseName { get; private set; }


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


        public override string ToString()
        {
            return $"{CourseNo},{CourseName}";
        }

    }

 
}
