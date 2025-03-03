using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Model
{
    internal class Student
    {
        public string StudentName { get; set; }
        public string StudentCourseName { get; set; }

        public Student(string name, string coursName)
        {
            this.StudentName = name;
            this.StudentCourseName = coursName;
        }
    }
}