using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Repositories;


namespace UnicomTicManagementSystem.Controllers
{
    public class TimetableController
    {
        // --- Timetable Entry Management ---

        public Task<List<Timetable>> GetAllTimetableEntriesAsync()
        {
            return DatabaseManager.Instance.GetAllTimetableEntriesAsync();
        }

        public Task AddTimetableEntryAsync(Timetable entry)
        {
            // Validation
            if (entry.SubjectID <= 0) throw new ArgumentException("Please select a subject.");
            if (string.IsNullOrWhiteSpace(entry.TimeSlot)) throw new ArgumentException("Time Slot cannot be empty.");
            if (entry.RoomID <= 0) throw new ArgumentException("Please select a room.");

            return DatabaseManager.Instance.AddTimetableEntryAsync(entry);
        }

        public Task UpdateTimetableEntryAsync(Timetable entry)
        {
            // Validation
            if (entry.TimetableID <= 0) throw new ArgumentException("Please select a valid timetable entry to update.");
            if (entry.SubjectID <= 0) throw new ArgumentException("Please select a subject.");
            if (string.IsNullOrWhiteSpace(entry.TimeSlot)) throw new ArgumentException("Time Slot cannot be empty.");
            if (entry.RoomID <= 0) throw new ArgumentException("Please select a room.");

            return DatabaseManager.Instance.UpdateTimetableEntryAsync(entry);
        }

        public Task DeleteTimetableEntryAsync(int timetableId)
        {
            if (timetableId <= 0) throw new ArgumentException("Please select a valid timetable entry to delete.");
            return DatabaseManager.Instance.DeleteTimetableEntryAsync(timetableId);
        }

        // --- Data for Dropdowns ---

        // This method gets all subjects for the dropdown.
        // We need to create a new method in DatabaseManager for this.
        public Task<List<Subject>> GetAllSubjectsAsync()
        {
            return DatabaseManager.Instance.GetAllSubjectsForTimetableAsync(); // We will create this method next.
        }

        // This method gets all rooms for the dropdown.
        public Task<List<Room>> GetAllRoomsAsync()
        {
            return DatabaseManager.Instance.GetAllRoomsForTimetableAsync(); // And this one too.
        }
    }
}
