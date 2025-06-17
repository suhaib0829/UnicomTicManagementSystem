using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManagementSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int CourseID { get; set; }

        public string CourseName { get; set; }
        public object Password { get; internal set; }
    }
}
