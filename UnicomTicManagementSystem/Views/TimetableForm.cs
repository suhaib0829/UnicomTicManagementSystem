// In Views/TimetableForm.cs

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Services;


namespace UnicomTicManagementSystem.Views
{
    public partial class TimetableForm : Form
    {
        private readonly TimetableController _controller;
        // NOTE: The _userRole field is removed. We'll get the role from UserSession.

        // The constructor is now simple and takes no arguments.
        public TimetableForm()
        {
            InitializeComponent();
            _controller = new TimetableController();
        }

        #region Event Handlers
        private async void TimetableForm_Load(object sender, EventArgs e)
        {
            SetupFormForRole();
            await LoadTimetableAsync();

            // Only load data for dropdowns if user is an Admin.
            if (UserSession.Role == "Admin")
            {
                await LoadSubjectsIntoComboBoxAsync();
                await LoadRoomsIntoComboBoxAsync();
            }

            ClearForm();
        }

        private void dgvTimetable_SelectionChanged(object sender, EventArgs e)
        {
            // This code only matters for the Admin who can edit.
            if (UserSession.Role != "Admin") return;

            if (dgvTimetable.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTimetable.SelectedRows[0];
                var entry = selectedRow.DataBoundItem as Timetable;

                if (entry != null)
                {
                    txtTimetableId.Text = entry.TimetableID.ToString();
                    txtTimeSlot.Text = entry.TimeSlot;
                    cmbSubjects.SelectedValue = entry.SubjectID;
                    cmbRooms.SelectedValue = entry.RoomID;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newEntry = new Timetable
                {
                    SubjectID = (int)cmbSubjects.SelectedValue,
                    TimeSlot = txtTimeSlot.Text.Trim(),
                    RoomID = (int)cmbRooms.SelectedValue
                };

                await _controller.AddTimetableEntryAsync(newEntry);
                MessageBox.Show("Timetable entry added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadTimetableAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var updatedEntry = new Timetable
                {
                    TimetableID = Convert.ToInt32(txtTimetableId.Text),
                    SubjectID = (int)cmbSubjects.SelectedValue,
                    TimeSlot = txtTimeSlot.Text.Trim(),
                    RoomID = (int)cmbRooms.SelectedValue
                };

                await _controller.UpdateTimetableEntryAsync(updatedEntry);
                MessageBox.Show("Timetable entry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadTimetableAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this timetable entry?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int timetableId = Convert.ToInt32(txtTimetableId.Text);
                    await _controller.DeleteTimetableEntryAsync(timetableId);
                    MessageBox.Show("Timetable entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTimetableAsync();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        #endregion

        #region Helper Methods
        private void SetupFormForRole()
        {
            // Get the role directly from the global session.
            if (UserSession.Role != "Admin")
            {
                // If not an admin, hide the GroupBox containing all editing controls.
                groupBox1.Visible = false;
                this.Text = "View Timetable";
            }
        }

        private void ClearForm()
        {
            txtTimetableId.Clear();
            txtTimeSlot.Clear();
            cmbSubjects.SelectedIndex = -1;
            cmbRooms.SelectedIndex = -1;
            dgvTimetable.ClearSelection();
            txtTimeSlot.Focus();
        }

        private async Task LoadTimetableAsync()
        {
            try
            {
                dgvTimetable.DataSource = await _controller.GetAllTimetableEntriesAsync();

                if (dgvTimetable.Columns.Count > 0)
                {
                    dgvTimetable.Columns["TimetableID"].Visible = false;
                    dgvTimetable.Columns["SubjectID"].Visible = false;
                    dgvTimetable.Columns["RoomID"].Visible = false;
                    dgvTimetable.Columns["SubjectName"].HeaderText = "Subject";
                    dgvTimetable.Columns["TimeSlot"].HeaderText = "Time Slot";
                    dgvTimetable.Columns["RoomName"].HeaderText = "Room / Hall";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load timetable: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadSubjectsIntoComboBoxAsync()
        {
            try
            {
                cmbSubjects.DataSource = await _controller.GetAllSubjectsAsync();
                cmbSubjects.DisplayMember = "SubjectName";
                cmbSubjects.ValueMember = "SubjectID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load subjects: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRoomsIntoComboBoxAsync()
        {
            try
            {
                cmbRooms.DataSource = await _controller.GetAllRoomsAsync();
                cmbRooms.DisplayMember = "RoomName";
                cmbRooms.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load rooms: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}