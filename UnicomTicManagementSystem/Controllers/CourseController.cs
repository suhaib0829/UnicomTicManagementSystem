// In Controllers/CourseController.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;


namespace UnicomTicManagementSystem.Controllers
{
    public class CourseController
    {
        public Task<List<Subject>> GetSubjectsForCourseAsync(int courseId)
        {
            // Simple pass-through
            return DatabaseManager.Instance.GetSubjectsForCourseAsync(courseId);
        }

        public Task AddSubjectAsync(string subjectName, int courseId)
        {
            // Add validation
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                throw new ArgumentException("Subject name cannot be empty.");
            }
            if (courseId <= 0)
            {
                throw new ArgumentException("A course must be selected before adding a subject.");
            }
            return DatabaseManager.Instance.AddSubjectAsync(subjectName, courseId);
        }
        // This method simply passes the request along to the database manager.
        public Task<List<Course>> GetAllCoursesAsync()
        {
            return DatabaseManager.Instance.GetAllCoursesAsync();
        }

        // For adding a course, the controller adds some business logic: validation.
        public Task AddCourseAsync(string courseName)
        {
            // Rule: A course name cannot be empty or just spaces.
            if (string.IsNullOrWhiteSpace(courseName))
            {
                // We 'throw' an error. The form will 'catch' this and show it to the user.
                throw new ArgumentException("Course name cannot be empty.");
            }
            return DatabaseManager.Instance.AddCourseAsync(courseName);
        }

        // The controller also validates input for updating.
        public Task UpdateCourseAsync(int courseId, string courseName)
        {
            // Rule: A valid course must be selected.
            if (courseId <= 0)
            {
                throw new ArgumentException("Please select a valid course to update.");
            }
            // Rule: The new course name cannot be empty.
            if (string.IsNullOrWhiteSpace(courseName))
            {
                throw new ArgumentException("Course name cannot be empty.");
            }
            return DatabaseManager.Instance.UpdateCourseAsync(courseId, courseName);
        }

        // And for deleting.
        public Task DeleteCourseAsync(int courseId)
        {
            // Rule: A valid course must be selected.
            if (courseId <= 0)
            {
                throw new ArgumentException("Please select a valid course to delete.");
            }
            return DatabaseManager.Instance.DeleteCourseAsync(courseId);
        }
    }
}
