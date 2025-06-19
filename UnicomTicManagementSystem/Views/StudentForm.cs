// In Views/StudentForm.cs

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Controllers;


namespace UnicomTicManagementSystem.Views
{
    // This inherits from Form, giving it all the properties of a window.
    public partial class StudentForm : Form
    {
        private readonly StudentController _studentController;

        public StudentForm()
        {
            InitializeComponent();
            _studentController = new StudentController();
        }

        #region Event Handlers

        private async void StudentForm_Load(object sender, EventArgs e)
        {
            await LoadCoursesIntoComboBoxAsync();
            await LoadStudentsAsync();
            ClearForm();
        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dgvStudents.SelectedRows[0];
                // Instead of getting from cells, get the whole object for type safety
                var student = selectedRow.DataBoundItem as Student;

                if (student != null)
                {
                    txtStudentId.Text = student.StudentID.ToString();
                    txtStudentName.Text = student.Name;
                    txtUsername.Text = student.Username;
                    cmbCourses.SelectedValue = student.CourseID;

                    // For security, clear and disable password box for existing users
                    txtPassword.Clear();
                    txtPassword.Enabled = false;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newStudent = new Student
                {
                    Name = txtStudentName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text,
                    CourseID = (int)cmbCourses.SelectedValue
                };

                await _studentController.AddStudentAsync(newStudent);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadStudentsAsync();
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
                var updatedStudent = new Student
                {
                    StudentID = Convert.ToInt32(txtStudentId.Text),
                    Name = txtStudentName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    CourseID = (int)cmbCourses.SelectedValue
                };

                await _studentController.UpdateStudentAsync(updatedStudent);
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadStudentsAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this student?\nThis will also delete all their marks.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int studentId = Convert.ToInt32(txtStudentId.Text);
                    await _studentController.DeleteStudentAsync(studentId);
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadStudentsAsync();
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

        private void ClearForm()
        {
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbCourses.SelectedIndex = -1;
            dgvStudents.ClearSelection();

            // Re-enable password box for a new entry
            txtPassword.Enabled = true;
            txtStudentName.Focus();
        }

        private async Task LoadStudentsAsync()
        {
            try
            {
                var students = await _studentController.GetAllStudentsAsync();
                // To prevent the SelectionChanged event from firing while loading
                dgvStudents.SelectionChanged -= dgvStudents_SelectionChanged;
                dgvStudents.DataSource = students;
                dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;

                // Hide columns we don't need
                if (dgvStudents.Columns["Password"] != null) dgvStudents.Columns["Password"].Visible = false;
                if (dgvStudents.Columns["CourseID"] != null) dgvStudents.Columns["CourseID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCoursesIntoComboBoxAsync()
        {
            try
            {
                cmbCourses.DataSource = await _studentController.GetAllCoursesAsync();
                cmbCourses.DisplayMember = "CourseName";
                cmbCourses.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load courses for dropdown: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}