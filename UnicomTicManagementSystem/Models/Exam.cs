using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManagementSystem.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int SubjectID { get; set; }
        public string SubjectName { get; internal set; }
    }
}
