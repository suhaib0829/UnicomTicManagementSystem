using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Models;
using UnicomTICManagementSystem.Controllers;

namespace UnicomTicManagementSystem.Views
{
    public partial class CourseForm : Form
    {
        private readonly CourseController _courseController;

        public CourseForm()
        {
            InitializeComponent();
            _courseController = new CourseController();
        }

        private async void CourseForm_Load(object sender, EventArgs e)
        {
            await LoadCoursesAsync();
        }

        private void DgvCourses_SelectionChanged(object sender, EventArgs e)
        {
            // Check if any row is selected.
            if (dgvCourses.SelectedRows.Count > 0)
            {
                // Get the first selected row.
                var selectedRow = dgvCourses.SelectedRows[0];

                // Get the data from the cells of that row.
                txtCourseId.Text = selectedRow.Cells["CourseID"].Value.ToString();
                txtCourseName.Text = selectedRow.Cells["CourseName"].Value.ToString();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private async void BtnAddCourse_Click(object sender, EventArgs e)
        {
            try
            {
                // Call the controller to perform the add operation.
                await _courseController.AddCourseAsync(txtCourseName.Text);
                MessageBox.Show("Course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the grid to show the new data.
                await LoadCoursesAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                // If the controller threw an error, we catch it and show it.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDeleteCourse_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this course?\nThis will also delete all associated subjects, students, and timetable entries.",
                                     "Confirm Deletion",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int courseId = Convert.ToInt32(txtCourseId.Text);
                    await _courseController.DeleteCourseAsync(courseId);
                    MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCoursesAsync();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnUpdateCourse_Click(object sender, EventArgs e)
        {
            try
            {
                int courseId = Convert.ToInt32(txtCourseId.Text);
                await _courseController.UpdateCourseAsync(courseId, txtCourseName.Text);
                MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadCoursesAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClearCourse_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            txtCourseId.Clear();
            txtCourseName.Clear();
            dgvCourses.ClearSelection();
        }

        private void TxtCourseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private async Task LoadCoursesAsync()
        {
            try
            {
                // Get the list of courses from the controller.
                var courses = await _courseController.GetAllCoursesAsync();

                // Set the DataSource of the grid. This automatically creates columns and rows.
                dgvCourses.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load courses: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
