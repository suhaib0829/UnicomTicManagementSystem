// In Views/MainForm.cs

using System;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTICManagementSystem.Views;


namespace UnicomTicManagementSystem.Views
{
    // The 'partial class' means this file and the Designer.cs file combine to make one class.
    public partial class MainForm : Form
    {
        // Private fields to store information about the logged-in user
        private readonly object _loggedInPrincipal;
        private string _loggedInUserRole = "";

        // The constructor that receives the logged-in user object from the LoginForm
        public MainForm(object principal)
        {
            // This special method (from the Designer.cs file) creates and draws all the controls.
            InitializeComponent();

            _loggedInPrincipal = principal;
        }

        // This method runs automatically just before the form is shown
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupDashboardForRole();
        }

        // This method checks the user's role and shows/hides the correct buttons
        private void SetupDashboardForRole()
        {
            // First, hide all buttons that are role-dependent.
            // We will make them visible again based on the role.
            btnManageCourses.Visible = false;
            btnManageStudents.Visible = false;
            btnManageExams.Visible = false;
            btnManageTimetable.Visible = false; // Start with everything hidden

            string role = "";
            string username = "";

            // Determine the role and username from the principal object
            if (_loggedInPrincipal is User user)
            {
                role = user.Role;
                username = user.Username;
            }
            else if (_loggedInPrincipal is Student student)
            {
                role = "Student";
                username = student.Username;
            }

            _loggedInUserRole = role; // Store the role for use by other buttons

            // Update the title label on our fancy title bar
            lblTitle.Text = $"Welcome, {username} ({_loggedInUserRole})";

            // Use a switch statement to control button visibility
            switch (_loggedInUserRole)
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

                    // Let's refine the text for the lecturer
                    btnManageExams.Text = "Enter/Edit Marks";
                    btnManageTimetable.Text = "View Timetable";
                    break;

                case "Student":
                    btnManageExams.Visible = true;
                    btnManageTimetable.Visible = true;

                    // Refine the text for the student
                    btnManageExams.Text = "View My Marks";
                    btnManageTimetable.Text = "View My Timetable";
                    break;
            }
        }

        // This ensures the entire application closes when this form is closed.
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // --- All the Button Click Handlers ---
        // These methods define what happens when a button is clicked.

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
            // We open the MarksForm and pass the entire logged-in user object to it.
            using (var marksForm = new MarksForm(_loggedInPrincipal))
            {
                marksForm.ShowDialog(this);
            }
        }

        private void btnManageTimetable_Click(object sender, EventArgs e)
        {
            // We pass the user's role to the TimetableForm's constructor.
            using (var timetableForm = new TimetableForm(_loggedInUserRole))
            {
                timetableForm.ShowDialog(this);
            }
        }
    }
}