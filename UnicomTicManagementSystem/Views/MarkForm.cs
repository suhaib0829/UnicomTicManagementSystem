// In Views/MarksForm.cs

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Services;


namespace UnicomTicManagementSystem.Views
{
    // It is public and partial.
    public partial class MarksForm : Form
    {
        // --- Fields for LOGIC ONLY ---
        private readonly ExamController _controller;
        private bool _isProgrammaticallyChanging = false;
        // NOTE: All the UI control declarations (like 'private DataGridView dgvMarks;') have been REMOVED from this file.
        // They correctly live in the Designer.cs file.

        // --- Constructor ---
        public MarksForm()
        {
            InitializeComponent();
            _controller = new ExamController();
        }

        #region Event Handlers
        private async void MarksForm_Load(object sender, EventArgs e)
        {
            SetupFormForRole();
            await LoadExamsIntoComboBoxAsync();
        }

        private async void cmbExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExams.SelectedValue is int examId && examId > 0)
            {
                await LoadMarksGridAsync(examId);
            }
            else
            {
                dgvMarks.DataSource = null;
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                var marksToSave = new List<Mark>();
                foreach (DataGridViewRow row in dgvMarks.Rows)
                {
                    if (row.Cells["Score"].Value != null && row.Cells["Score"].Value != DBNull.Value)
                    {
                        if (int.TryParse(row.Cells["Score"].Value.ToString(), out int score))
                        {
                            if (score >= 0 && score <= 100)
                            {
                                marksToSave.Add(new Mark
                                {
                                    StudentID = (int)row.Cells["StudentID"].Value,
                                    ExamID = (int)row.Cells["ExamID"].Value,
                                    Score = score
                                });
                            }
                            else
                            {
                                MessageBox.Show($"The score for {row.Cells["StudentName"].Value} must be between 0 and 100.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"The score for {row.Cells["StudentName"].Value} is not a valid number.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                if (marksToSave.Count == 0)
                {
                    MessageBox.Show("No scores were changed or entered to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var mark in marksToSave)
                {
                    await _controller.UpsertMarkAsync(mark);
                }
                MessageBox.Show("Marks saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving marks: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Helper Methods
        private void SetupFormForRole()
        {
            string role = UserSession.Role;

            if (role == "Student")
            {
                btnSaveChanges.Visible = false;
                dgvMarks.ReadOnly = true;
                this.Text = "View My Marks";
            }
            else
            {
                btnSaveChanges.Visible = true;
                dgvMarks.ReadOnly = false;
                this.Text = "Enter & Manage Marks";
            }
        }

        private async Task LoadExamsIntoComboBoxAsync()
        {
            try
            {
                cmbExams.DataSource = await _controller.GetAllExamsAsync();
                cmbExams.DisplayMember = "ExamName";
                cmbExams.ValueMember = "ExamID";
                cmbExams.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load exams: {ex.Message}", "Data Error");
            }
        }

        private async Task LoadMarksGridAsync(int examId)
        {
            try
            {
                _isProgrammaticallyChanging = true;
                List<Mark> marks = await _controller.GetMarksForExamAsync(examId);

                if (UserSession.Principal is Student student)
                {
                    marks = marks.FindAll(m => m.StudentID == student.StudentID);
                }

                dgvMarks.DataSource = marks;

                if (dgvMarks.Columns.Count > 0)
                {
                    dgvMarks.Columns["MarkID"].Visible = false;
                    dgvMarks.Columns["StudentID"].Visible = false;
                    dgvMarks.Columns["ExamID"].Visible = false;
                    dgvMarks.Columns["StudentName"].ReadOnly = true;
                    dgvMarks.Columns["ExamName"].ReadOnly = true;
                    dgvMarks.Columns["SubjectName"].ReadOnly = true;
                    dgvMarks.Columns["Score"].ReadOnly = (UserSession.Role == "Student");
                    dgvMarks.Columns["StudentName"].HeaderText = "Student Name";
                    dgvMarks.Columns["ExamName"].HeaderText = "Exam";
                    dgvMarks.Columns["SubjectName"].HeaderText = "Subject";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load marks: {ex.Message}", "Data Error");
            }
            finally
            {
                _isProgrammaticallyChanging = false;
            }
        }
        #endregion
    }
}