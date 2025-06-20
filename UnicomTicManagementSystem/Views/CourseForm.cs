// In Views/CourseForm.cs

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;


namespace UnicomTicManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        private readonly CourseController _courseController;
        private int _selectedCourseId = 0;

        public CourseForm()
        {
            InitializeComponent();
            _courseController = new CourseController();
        }

        #region Event Handlers

        private async void CourseForm_Load(object sender, EventArgs e)
        {
            await LoadCoursesAsync();
        }

        private async void dgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCourses.SelectedRows[0];
                txtCourseId.Text = selectedRow.Cells["CourseID"].Value.ToString();
                txtCourseName.Text = selectedRow.Cells["CourseName"].Value.ToString();

                _selectedCourseId = Convert.ToInt32(txtCourseId.Text);
                await LoadSubjectsAsync(_selectedCourseId);
            }
            else
            {
                _selectedCourseId = 0;
                dgvSubjects.DataSource = null;
            }
        }

        #region Button Clicks
        private async void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please enter a course name.", "Input Required");
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
            if (string.IsNullOrWhiteSpace(txtCourseName.Text) || _selectedCourseId <= 0)
            {
                MessageBox.Show("Please select a course and enter a name.", "Input Required");
                return;
            }
            try
            {
                await _courseController.UpdateCourseAsync(_selectedCourseId, txtCourseName.Text.Trim());
                await LoadCoursesAsync();
                ClearCourseForm();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private async void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId <= 0) { MessageBox.Show("Please select a course to delete."); return; }

            var confirm = MessageBox.Show("Delete this course and ALL its subjects?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _courseController.DeleteCourseAsync(_selectedCourseId);
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

        private async void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (_selectedCourseId <= 0)
            {
                MessageBox.Show("Please select a course before adding a subject.", "Course Not Selected");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Please enter a subject name.", "Input Required");
                return;
            }

            try
            {
                await _courseController.AddSubjectAsync(txtSubjectName.Text.Trim(), _selectedCourseId);
                await LoadSubjectsAsync(_selectedCourseId);
                txtSubjectName.Clear();
                txtSubjectName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Adding Subject");
            }
        }
        #endregion

        #endregion

        #region Helper Methods
        private void ClearCourseForm()
        {
            txtCourseId.Clear();
            txtCourseName.Clear();
            dgvCourses.ClearSelection();
            txtSubjectName.Clear();
        }

        private async Task LoadCoursesAsync()
        {
            try
            {
                dgvCourses.DataSource = await _courseController.GetAllCoursesAsync();
            }
            catch (Exception ex) { MessageBox.Show($"Failed to load courses: {ex.Message}", "Database Error"); }
        }

        private async Task LoadSubjectsAsync(int courseId)
        {
            try
            {
                dgvSubjects.DataSource = await _courseController.GetSubjectsForCourseAsync(courseId);

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