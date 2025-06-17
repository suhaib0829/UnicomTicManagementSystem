using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;


namespace UnicomTICManagementSystem.Controllers
{
    public class ExamController
    {
        public Task<List<Exam>> GetAllExamsAsync()
        {
            return DatabaseManager.Instance.GetAllExamsAsync();
        }

        // We will need a list of all subjects to populate a dropdown on the Exam form.
        public Task<List<Subject>> GetAllSubjectsAsync()
        {
            // We can reuse the method we created for the TimetableController!
            return DatabaseManager.Instance.GetAllSubjectsForTimetableAsync();
        }

        public Task AddExamAsync(Exam exam)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(exam.ExamName))
                throw new ArgumentException("Exam Name cannot be empty.");
            if (exam.SubjectID <= 0)
                throw new ArgumentException("Please select a subject for the exam.");

            return DatabaseManager.Instance.AddExamAsync(exam);
        }

        public Task UpdateExamAsync(Exam exam)
        {
            // Validation
            if (exam.ExamID <= 0)
                throw new ArgumentException("Please select a valid exam to update.");
            if (string.IsNullOrWhiteSpace(exam.ExamName))
                throw new ArgumentException("Exam Name cannot be empty.");
            if (exam.SubjectID <= 0)
                throw new ArgumentException("Please select a subject for the exam.");

            return DatabaseManager.Instance.UpdateExamAsync(exam);
        }

        public Task DeleteExamAsync(int examId)
        {
            if (examId <= 0)
                throw new ArgumentException("Please select a valid exam to delete.");

            return DatabaseManager.Instance.DeleteExamAsync(examId);
        }

        // We will add methods for MARKS management here later.
    }
}
