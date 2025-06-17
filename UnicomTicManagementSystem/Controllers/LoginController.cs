using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;

namespace UnicomTicManagementSystem.Controllers
{
    public class LoginController
    {
        public async Task<object> AuthenticateAsync(string username, string password)
        {
            var user = await DatabaseManager.Instance.GetUserByUsernameAndPasswordAsync(username, password);
            if (user != null)
            {
                // If found, return the User object
                return user;
            }

            // If not found, try to find a student user
            var student = await DatabaseManager.Instance.GetStudentByUsernameAndPasswordAsync(username, password);
            if (student != null)
            {
                // If found, return the Student object
                return student;
            }

            // If neither was found, return null to indicate failure
            return null;
        }
    }
    
}
