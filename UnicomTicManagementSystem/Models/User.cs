using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomTicManagementSystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public object UserName { get; internal set; }
        public string Password { get; set; } // Plain text as per requirements
        public string Role { get; set; }
    }
}
