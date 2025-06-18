using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManagementSystem.Models
{
    public class Mark
    {
        public int MarkID { get; set; }
        public int StudentID { get; set; }
        public int ExamID { get; set; }
        public int? Score { get; set; }// Can be null

        // Extra properties for easy display
        public string StudentName { get; set; }
        public string ExamName { get; set; }
        public string SubjectName { get; set; }



    }
}
