// In Views/CourseForm.cs

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;

namespace UnicomTicManagementSystem.Views
{
    // This inherits from Form, giving it all the properties of a window.
    public partial class CourseForm : Form
    {
        // Private fields for the controller and to store the selected course ID
        private readonly CourseController _courseController;
        private int _selectedCourseId = 0;

        // The constructor for the form
        public CourseForm()
        {
            // This method (from the Designer.cs file) creates and draws all the controls.
            InitializeComponent();
            _courseController = new CourseController();
        }

        #region Event Handlers

        // This method runs once, just before the form is displayed.
        private async void CourseForm_Load(object sender, EventArgs e)
        {
            await LoadCoursesAsync();
        }

        // This method runs when the user selects a different course in the main grid.
        // It now has the added responsibility of loading the subjects for that course.
        private async void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCourses.SelectedRows[0];
                txtCourseId.Text = selectedRow.Cells["CourseID"].Value.ToString();
                txtCourseName.Text = selectedRow.Cells["CourseName"].Value.ToString();

                // Store the selected ID so we can use it later when adding a subject.
                _selectedCourseId = Convert.ToInt32(txtCourseId.Text);

                // Load the subjects for this newly selected course.
                await LoadSubjectsAsync(_selectedCourseId);
            }
            else
            {
                // If no course is selected, clear the subjects grid.
                _selectedCourseId = 0;
                dgvSubjects.DataSource = null;
            }
        }

        #region Course Button Clicks
        private async void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please enter a course name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCourseName.Focus();
                return;
            }
            try
            {
                await _courseController.AddCourseAsync(txtCourseName.Text.Trim());
                await LoadCoursesAsync();
                ClearCourseForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private async void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            try
            {
                await _courseController.UpdateCourseAsync(Convert.ToInt32(txtCourseId.Text), txtCourseName.Text.Trim());
                await LoadCoursesAsync();
                ClearCourseForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this course?\nThis will also delete ALL associated subjects, students, and timetable entries.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _courseController.DeleteCourseAsync(Convert.ToInt32(txtCourseId.Text));
                    await LoadCoursesAsync();
                    ClearCourseForm();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
        }
        private void btnClearCourse_Click(object sender, EventArgs e)
        {
            ClearCourseForm();
        }
        #endregion

        #region Subject Button Click
        // This method runs when the "Add Subject" button is clicked.
        private async void btnAddSubject_Click(object sender, EventArgs e)
        {
            // Rule 1: A course must be selected first.
            if (_selectedCourseId <= 0)
            {
                MessageBox.Show("Please select a course from the list before adding a subject.", "Course Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Rule 2: The subject name cannot be empty.
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Please enter a name for the new subject.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectName.Focus();
                return;
            }
            try
            {
                // Call the controller, passing the new subject name and the currently selected course ID.
                await _courseController.AddSubjectAsync(txtSubjectName.Text.Trim(), _selectedCourseId);

                // Refresh the subjects list to show the newly added one.
                await LoadSubjectsAsync(_selectedCourseId);
                txtSubjectName.Clear();
                txtSubjectName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Adding Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region Helper Methods
        // This helper method clears the input fields.
        private void ClearCourseForm()
        {
            txtCourseId.Clear();
            txtCourseName.Clear();
            dgvCourses.ClearSelection();
            txtSubjectName.Clear();
        }

        // This helper method loads the main courses grid.
        private async Task LoadCoursesAsync()
        {
            try
            {
                dgvCourses.DataSource = await _courseController.GetAllCoursesAsync();
            }
            catch (Exception ex) { MessageBox.Show($"Failed to load courses: {ex.Message}", "Database Error"); }
        }

        // This is the NEW helper method to load the subjects grid.
        private async Task LoadSubjectsAsync(int courseId)
        {
            try
            {
                dgvSubjects.DataSource = await _courseController.GetSubjectsForCourseAsync(courseId);

                // Hide unnecessary columns for a cleaner look.
                if (dgvSubjects.Columns["SubjectID"] != null) dgvSubjects.Columns["SubjectID"].Visible = false;
                if (dgvSubjects.Columns["CourseID"] != null) dgvSubjects.Columns["CourseID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load subjects: {ex.Message}", "Database Error");
            }
        }
        #endregion
    }
}