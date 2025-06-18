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

namespace UnicomTicManagementSystem.Views
{
    public partial class ExamForm : Form
    {
        // --- 1. DECLARE ALL OUR CONTROLS AS PRIVATE FIELDS ---
        private System.Windows.Forms.DataGridView dgvExams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtExamId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSubjects;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private User currentUser;

        // Controller and Role fields
        private readonly ExamController _controller;
        private readonly string _userRole;

        // Constructor
        public ExamForm(string userRole)
        {
            InitializeComponent(); // This method is in the Designer.cs file. We'll edit it next.
            _controller = new ExamController();
            _userRole = userRole;
        }

        public ExamForm(User currentUser)
        {
            this.currentUser = currentUser;
        }

        // Add this code inside the ExamForm class in Views/ExamForm.cs

        // --- EVENT HANDLERS ---

        private async void ExamForm_Load(object sender, EventArgs e)
        {
            SetupFormForRole();
            await LoadExamsAsync();

            if (_userRole == "Admin" || _userRole == "Staff")
            {
                await LoadSubjectsIntoComboBoxAsync();
            }
            ClearForm();
        }

        private void dgvExams_SelectionChanged(object sender, EventArgs e)
        {
            if (!IsUserAllowedToEdit()) return;

            if (dgvExams.SelectedRows.Count > 0)
            {
                var selectedRow = dgvExams.SelectedRows[0];
                var exam = selectedRow.DataBoundItem as Exam;

                if (exam != null)
                {
                    txtExamId.Text = exam.ExamID.ToString();
                    txtExamName.Text = exam.ExamName;
                    cmbSubjects.SelectedValue = exam.SubjectID;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newExam = new Exam
                {
                    ExamName = txtExamName.Text.Trim(),
                    SubjectID = (int)cmbSubjects.SelectedValue
                };

                await _controller.AddExamAsync(newExam);
                MessageBox.Show("Exam added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadExamsAsync();
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
                var updatedExam = new Exam
                {
                    ExamID = Convert.ToInt32(txtExamId.Text),
                    ExamName = txtExamName.Text.Trim(),
                    SubjectID = (int)cmbSubjects.SelectedValue
                };

                await _controller.UpdateExamAsync(updatedExam);
                MessageBox.Show("Exam updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadExamsAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this exam?\nThis will also delete all associated marks.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int examId = Convert.ToInt32(txtExamId.Text);
                    await _controller.DeleteExamAsync(examId);
                    MessageBox.Show("Exam deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadExamsAsync();
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

        private bool IsUserAllowedToEdit()
        {
            return _userRole == "Admin" || _userRole == "Staff";
        }

        private void SetupFormForRole()
        {
            if (!IsUserAllowedToEdit())
            {
                groupBox1.Visible = false; // Hide editing controls
                this.Text = "View Exams";
            }
        }

        private void ClearForm()
        {
            txtExamId.Clear();
            txtExamName.Clear();
            cmbSubjects.SelectedIndex = -1;
            dgvExams.ClearSelection();
            txtExamName.Focus();
        }

        private async Task LoadExamsAsync()
        {
            try
            {
                dgvExams.DataSource = await _controller.GetAllExamsAsync();

                // Hide columns for a cleaner view
                if (dgvExams.Columns["ExamID"] != null) dgvExams.Columns["ExamID"].Visible = false;
                if (dgvExams.Columns["SubjectID"] != null) dgvExams.Columns["SubjectID"].Visible = false;

                // Rename columns for readability
                if (dgvExams.Columns["ExamName"] != null) dgvExams.Columns["ExamName"].HeaderText = "Exam Name";
                if (dgvExams.Columns["SubjectName"] != null) dgvExams.Columns["SubjectName"].HeaderText = "Subject";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load exams: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtExamName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
