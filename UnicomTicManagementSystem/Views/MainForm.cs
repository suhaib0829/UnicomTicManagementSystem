// In Views/MainForm.cs

using System;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Views;
using UnicomTicManagementSystem.Services;



namespace UnicomTicManagementSystem.Views
{
    /// <summary>
    /// The main dashboard of the application.
    /// The controls and buttons displayed on this form change based on the logged-in user's role.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The constructor for the MainForm.
        /// It is now simpler because it doesn't need to receive any user information.
        /// </summary>
        public MainForm()
        {
            // This method (from the Designer.cs file) creates and draws all the controls.
            InitializeComponent();
        }

        /// <summary>
        /// This method runs automatically just before the form is displayed.
        /// It's the perfect place to set up the form's appearance based on the user role.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupDashboardForRole();
        }

        /// <summary>
        /// This method checks the UserSession for the logged-in user's role
        /// and configures the dashboard by showing or hiding the appropriate buttons.
        /// </summary>
        private void SetupDashboardForRole()
        {
            // --- 1. Get User Information from the Global Session ---
            // This is much cleaner than passing objects between forms.
            string role = UserSession.Role;
            string username = UserSession.Username;

            // --- 2. Customize the Welcome Message ---
            // Update the title label on our fancy title bar.
            lblTitle.Text = $"Welcome, {username} ({role})";

            // --- 3. Set Button Visibility Based on Role ---
            // First, hide all buttons that are role-dependent.
            btnManageCourses.Visible = false;
            btnManageStudents.Visible = false;
            btnManageExams.Visible = false;
            btnManageTimetable.Visible = false;

            // Use a switch statement to make the correct buttons visible.
            switch (role)
            {
                case "Admin":
                    // The Admin sees all four main module buttons.
                    btnManageCourses.Visible = true;
                    btnManageStudents.Visible = true;
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    break;

                case "Staff":
                    // Staff can manage exams/marks and view the timetable.
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    break;

                case "Lecturer":
                    // Lecturers can manage marks and view the timetable.
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    // Let's refine the button text for clarity.
                    btnManageExams.Text = "Enter/Edit Marks";
                    btnManageTimetable.Text = "View Timetable";
                    break;

                case "Student":
                    // Students can view their marks and the timetable.
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;
                    // Refine the button text for clarity.
                    btnManageExams.Text = "View My Marks";
                    btnManageTimetable.Text = "View My Timetable";
                    break;
            }
        }

        /// <summary>
        /// This event handler ensures that when the main dashboard is closed,
        /// the entire application exits properly, including the hidden login form.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clear the session data on exit.
            UserSession.EndSession();
            Application.Exit();
        }

        // --- All the Button Click Handlers ---
        // These methods define what happens when a user clicks a dashboard button.

        private void btnManageCourses_Click(object sender, EventArgs e)
        {
            using (var courseForm = new CourseForm())
            {
                courseForm.ShowDialog(this); // 'this' makes it open centered over the MainForm
            }
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            using (var studentForm = new StudentForm())
            {
                studentForm.ShowDialog(this);
            }
        }

        private void btnManageExams_Click(object sender, EventArgs e)
        {
            // The MarksForm now gets its user info from the global UserSession.
            using (var marksForm = new MarksForm())
            {
                marksForm.ShowDialog(this);
            }
        }

        private void btnManageTimetable_Click(object sender, EventArgs e)
        {
            // The TimetableForm also gets its user info from the global UserSession.
            using (var timetableForm = new TimetableForm())
            {
                timetableForm.ShowDialog(this);
            }
        }
    }
}