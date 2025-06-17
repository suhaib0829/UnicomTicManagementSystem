using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Views;
using UnicomTICManagementSystem.Views;

namespace UnicomTicManagementSystem.Views
{
    // A private field to store the user who logged in
    //private readonly User _currentUser;
    public partial class MainForm : Form
    {
        private string _loggedInUserRole = "";
        private readonly object _loggedInPrincipal;

        // THIS IS THE CONSTRUCTOR that fixes our error.
        // It accepts one argument, which we name 'principal'.
        public MainForm(object principal)
        {
            InitializeComponent();

            // We take the passed-in object and store it in our private field.
            _loggedInPrincipal = principal;
        }
        private readonly User _currentUser;
        public MainForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            this.Text = $"Course Management - Logged in as: {_currentUser.Username}";

        }
        // Inside the MainForm class
        private void SetupDashboardForRole()
        {
            // Start by hiding all management buttons. This is a "secure by default" approach.
            manageCoursesButton.Visible = false;
            manageStudentsButton.Visible = false;
            manageExamsButton.Visible = false;
            manageTimetableButton.Visible = false;
            viewTimetableButton.Visible = false;
            viewMarksButton.Visible = false;

            // Use a switch statement to show buttons based on the user's role.
            switch (_currentUser.Role)
            {
                case "Admin":
                    // Admin sees all management buttons.
                    manageCoursesButton.Visible = true;
                    manageStudentsButton.Visible = true;
                    manageExamsButton.Visible = true;
                    manageTimetableButton.Visible = true;
                    break;

                case "Staff":
                    // Staff can view timetables and manage exams/marks.
                    viewTimetableButton.Visible = true;
                    manageExamsButton.Visible = true; // As per spec: "add/edit exams and marks"
                    break;

                case "Student":
                    // Student can view their timetable and marks.
                    viewTimetableButton.Visible = true;
                    viewMarksButton.Visible = true;
                    break;

                case "Lecturer":
                    // Lecturer can view timetables and add/edit marks.
                    viewTimetableButton.Visible = true;
                    manageExamsButton.Visible = true; // We'll give them access to the same form as staff
                    break;
            }
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            string role = "";
            if (_loggedInPrincipal is User user)
            {
                role = user.Role;
            }
            else if (_loggedInPrincipal is Student)
            {
                role = "Student";
            }
            _loggedInUserRole = role;
        }

        private void ManageCoursesButton_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();
            // Show it to the user.
            courseForm.ShowDialog();
        }

        private void ManageStudentsButton_Click(object sender, EventArgs e)
        {
            var studentForm = new StudentForm(_currentUser);
            studentForm.Show();
        }

        private void ManageExamsButton_Click(object sender, EventArgs e)
        {
            var examForm = new ExamForm(_currentUser);
            examForm.Show();
        }

        private void ManageTimetableButton_Click(object sender, EventArgs e)
        {
            var timetableForm = new TimetableForm(_currentUser);
            timetableForm.Show();
        }

        private void ViewTimetableButton_Click(object sender, EventArgs e)
        {
            var timetableForm = new TimetableForm(_currentUser);
            timetableForm.Show();
        }

        private void ViewMarksButton_Click(object sender, EventArgs e)
        {
            var markForm = new MarkForm(_currentUser);
            markForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
