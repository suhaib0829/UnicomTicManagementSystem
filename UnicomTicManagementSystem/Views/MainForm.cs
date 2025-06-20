// In Views/MainForm.cs

using System;
using System.Windows.Forms;
using UnicomTicManagementSystem.Services; // For UserSession
using UnicomTicManagementSystem.Models; // For User and Student types

namespace UnicomTicManagementSystem.Views
{
    public partial class MainForm : Form
    {
        // A flag to determine if the form is closing because of logout or the 'X' button.
        private bool _isLoggingOut = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupDashboardForRole();
        }

        private void SetupDashboardForRole()
        {
            string role = UserSession.Role;
            string username = UserSession.Username;
            lblTitle.Text = $"Welcome, {username} ({role})";

            // Hide all buttons first
            btnManageCourses.Visible = false;
            btnManageStudents.Visible = false;
            btnManageExams.Visible = false;
            btnManageTimetable.Visible = false;

            // Show buttons based on role
            switch (role)
            {
                case "Admin":
                    btnManageCourses.Visible = true;
                    btnManageStudents.Visible = true;
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    break;
                case "Staff":
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    break;
                case "Lecturer":
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    btnManageExams.Text = "Enter/Edit Marks";
                    btnManageTimetable.Text = "View Timetable";
                    break;
                case "Student":
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    btnManageExams.Text = "View My Marks";
                    btnManageTimetable.Text = "View My Timetable";
                    break;
            }
        }

        // --- CORRECTED AND FINAL Button Click Handlers ---

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            using (var courseForm = new CourseForm()) { courseForm.ShowDialog(this); }
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            using (var studentForm = new StudentForm()) { studentForm.ShowDialog(this); }
        }

        private void btnManageExams_Click(object sender, EventArgs e)
        {
            // Use ExamsAndMarksForm for the combined UI
            using (var examsAndMarksForm = new ExamsAndMarksForm()) { examsAndMarksForm.ShowDialog(this); }
        }

        private void btnManageTimetable_Click(object sender, EventArgs e)
        {
            using (var timetableForm = new TimetableForm()) { timetableForm.ShowDialog(this); }
        }

        // The new Logout button handler
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                UserSession.EndSession();

                // Set the flag to true so the FormClosing event knows we are logging out.
                _isLoggingOut = true;

                // Create the new LoginForm.
                LoginForm newLoginForm = new LoginForm(); // Using a different name 'newLoginForm' to avoid ambiguity.
                newLoginForm.Show();

                // Close the current dashboard.
                this.Close();
            }
        }

        // The one and only FormClosing event handler
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the _isLoggingOut flag is true, just let the form close without exiting the app.
            if (_isLoggingOut)
            {
                return;
            }

            // Otherwise, the user clicked the 'X' button, so exit the entire application.
            Application.Exit();
        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}