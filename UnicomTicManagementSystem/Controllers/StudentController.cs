using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;


namespace UnicomTicManagementSystem.Controllers
{
    public class StudentController
    {
        // For reading, we just pass the request along.
        public Task<List<Student>> GetAllStudentsAsync()
        {
            return DatabaseManager.Instance.GetAllStudentsAsync();
        }

        // We also need a way to get all courses to populate a dropdown list on our form.
        public Task<List<Course>> GetAllCoursesAsync()
        {
            // We can reuse the method we already created!
            return DatabaseManager.Instance.GetAllCoursesAsync();
        }

        public Task AddStudentAsync(Student student)
        {
            // Business Logic and Validation
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Student Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(student.Username))
                throw new ArgumentException("Username cannot be empty.");
            if (string.IsNullOrWhiteSpace((string)student.Password))
                throw new ArgumentException("Password cannot be empty for a new student.");
            if (student.CourseID <= 0)
                throw new ArgumentException("Please select a course for the student.");

            return DatabaseManager.Instance.AddStudentAsync(student);
        }

        public Task UpdateStudentAsync(Student student)
        {
            // Business Logic and Validation
            if (student.StudentID <= 0)
                throw new ArgumentException("Please select a valid student to update.");
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Student Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(student.Username))
                throw new ArgumentException("Username cannot be empty.");
            if (student.CourseID <= 0)
                throw new ArgumentException("Please select a course for the student.");

            return DatabaseManager.Instance.UpdateStudentAsync(student);
        }

        public Task DeleteStudentAsync(int studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Please select a valid student to delete.");

            return DatabaseManager.Instance.DeleteStudentAsync(studentId);
        }
    }
}
