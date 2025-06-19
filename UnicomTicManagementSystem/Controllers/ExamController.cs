// In Controllers/ExamController.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;
// Add the missing namespace or assembly reference for 'Repositories'

using UnicomTicManagementSystem.Repositories;


namespace UnicomTicManagementSystem.Controllers
{
    public class ExamController
    {
        // --- Exam Methods ---

        // CORRECTED: Removed 'async' and 'await'. This method now directly returns the Task from the database manager.
        public Task<List<Exam>> GetAllExamsAsync()
        {
            return DatabaseManager.Instance.GetAllExamsAsync();
        }

        // CORRECTED: Removed 'async' and 'await'.
        public Task<List<Subject>> GetAllSubjectsAsync()
        {
            return DatabaseManager.Instance.GetAllSubjectsForTimetableAsync();
        }

        public async Task AddExamAsync(Exam exam)
        {
            // This method has logic, so it stays async and awaits.
            if (string.IsNullOrWhiteSpace(exam.ExamName))
                throw new ArgumentException("Exam Name cannot be empty.");
            if (exam.SubjectID <= 0)
                throw new ArgumentException("Please select a subject for the exam.");

            await DatabaseManager.Instance.AddExamAsync(exam);
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            // This method has logic, so it stays async and awaits.
            if (exam.ExamID <= 0)
                throw new ArgumentException("Please select a valid exam to update.");
            if (string.IsNullOrWhiteSpace(exam.ExamName))
                throw new ArgumentException("Exam Name cannot be empty.");
            if (exam.SubjectID <= 0)
                throw new ArgumentException("Please select a subject for the exam.");

            await DatabaseManager.Instance.UpdateExamAsync(exam);
        }

        public async Task DeleteExamAsync(int examId)
        {
            // This method has logic, so it stays async and awaits.
            if (examId <= 0)
                throw new ArgumentException("Please select a valid exam to delete.");

            await DatabaseManager.Instance.DeleteExamAsync(examId);
        }

        // --- Marks Methods ---

        // CORRECTED: Removed 'async' and 'await'.
        public Task<List<Mark>> GetMarksForExamAsync(int examId)
        {
            if (examId <= 0)
            {
                // Return a Task containing an empty list if no exam is selected.
                return Task.FromResult(new List<Mark>());
            }
            return DatabaseManager.Instance.GetMarksForExamAsync(examId);
        }

        public async Task UpsertMarkAsync(Mark mark)
        {
            // This method has logic, so it stays async and awaits.
            if (mark.StudentID <= 0) throw new ArgumentException("Invalid Student ID.");
            if (mark.ExamID <= 0) throw new ArgumentException("Invalid Exam ID.");
            if (mark.Score.HasValue && (mark.Score < 0 || mark.Score > 100))
                throw new ArgumentException("Score must be between 0 and 100.");

            await DatabaseManager.Instance.UpsertMarkAsync(mark);
        }
    }
}