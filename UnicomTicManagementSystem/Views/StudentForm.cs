using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Models;
using UnicomTICManagementSystem.Controllers; // We need our controller


namespace UnicomTicManagementSystem.Views
{
    public partial class StudentForm : Form
    {
        // We have one controller for this form.
        private readonly StudentController _studentController;

        public StudentForm(User currentUser)
        {
            InitializeComponent();
            _studentController = new StudentController();
        }

        public StudentForm()
        {
        }

        // --- EVENT HANDLERS ---

        // This runs when the form first loads.
        // It's responsible for loading ALL initial data.
        private async void StudentForm_Load(object sender, EventArgs e)
        {
            await LoadStudentsAsync();
            await LoadCoursesIntoComboBoxAsync();
            ClearForm();
        }

        // When a user clicks a row in the grid...
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                var selectedRow = dgvStudents.SelectedRows[0];
                var student = selectedRow.DataBoundItem as Student; // Get the full Student object

                if (student != null)
                {
                    // Populate the form fields from the selected student object
                    txtStudentId.Text = student.StudentID.ToString();
                    txtStudentName.Text = student.Name;
                    txtUsername.Text = student.Username;

                    // Select the correct course in the ComboBox
                    cmbCourses.SelectedValue = student.CourseID;

                    // For security, we don't show the existing password.
                    // We also disable the password box for existing users.
                    txtPassword.Clear();
                    txtPassword.Enabled = false;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new Student object from the form data
                var newStudent = new Student
                {
                    Name = txtStudentName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text, // Get password for new student
                    CourseID = (int)cmbCourses.SelectedValue
                };

                await _studentController.AddStudentAsync(newStudent);
                MessageBox.Show("Student added successfully!", "Success", (MessageBoxButtons)MessageBoxIcon.Information);

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
                MessageBox.Show("Student updated successfully!", "Success", (MessageBoxButtons)MessageBoxIcon.Information);
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
            var confirmResult = MessageBox.Show("Are you sure you want to delete this student?\nThis will also delete all their marks.",
                                     "Confirm Deletion",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int studentId = Convert.ToInt32(txtStudentId.Text);
                    await _studentController.DeleteStudentAsync(studentId);
                    MessageBox.Show("Student deleted successfully!", "Success", (MessageBoxButtons)MessageBoxIcon.Information);
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

        // --- HELPER METHODS ---

        // This method clears the form for a new entry.
        private void ClearForm()
        {
            txtStudentId.Clear();
            txtStudentName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cmbCourses.SelectedIndex = -1; // Deselect any course
            dgvStudents.ClearSelection();
            txtPassword.Enabled = true; // Re-enable password box for new entry
            txtStudentName.Focus(); // Set the cursor to the Name field
        }

        // This method fetches the student data and populates the grid.
        private async Task LoadStudentsAsync()
        {
            try
            {
                var students = await _studentController.GetAllStudentsAsync();
                dgvStudents.DataSource = students;

                // Hide columns we don't need to see in the grid
                dgvStudents.Columns["Password"].Visible = false;
                dgvStudents.Columns["CourseID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load students: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // This method fetches the list of courses and populates our dropdown menu.
        private async Task LoadCoursesIntoComboBoxAsync()
        {
            try
            {
                var courses = await _studentController.GetAllCoursesAsync();

                // Set the data source for the ComboBox
                cmbCourses.DataSource = courses;
                // Tell the ComboBox WHAT to SHOW the user
                cmbCourses.DisplayMember = "CourseName";
                // Tell the ComboBox WHAT to USE as the hidden value
                cmbCourses.ValueMember = "CourseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load courses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
