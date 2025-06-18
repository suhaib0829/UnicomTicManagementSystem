using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnicomTICManagementSystem.Repositories;

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

        internal async Task<object> AuthenticateAsync(object value, object text)
        {
            // Simulate asynchronous operation using Task.Run
            return await Task.Run(() =>
            {
                // Placeholder logic for authentication
                if (value != null && text != null)
                {
                    return new { Value = value, Text = text }; // Example return object
                }
                return null;
            });
        }
    }
    
}
