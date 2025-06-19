using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;


namespace UnicomTicManagementSystem.Services
{
    /// <summary>
    /// A static class to hold information about the currently logged-in user.
    /// This acts as a global session state for the application.
    /// </summary>
    public static class UserSession
    {
        // 'private set' means only this class can change the values.
        public static object Principal { get; private set; }
        public static string Role { get; private set; }
        public static int Id { get; private set; }
        public static string Username { get; private set; }

        /// <summary>
        /// Call this method upon successful login to store user data.
        /// </summary>
        public static void StartSession(object principal)
        {
            Principal = principal;
            if (principal is User user)
            {
                Id = user.UserID;
                Username = user.Username;
                Role = user.Role;
            }
            else if (principal is Student student)
            {
                Id = student.StudentID;
                Username = student.Username;
                Role = "Student";
            }
        }

        /// <summary>
        /// Call this method on logout to clear all session data.
        /// </summary>
        public static void EndSession()
        {
            Principal = null;
            Role = null;
            Id = 0;
            Username = null;
        }
    }
}
