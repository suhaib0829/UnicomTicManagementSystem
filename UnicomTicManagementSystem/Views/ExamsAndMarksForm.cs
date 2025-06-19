// In Views/ExamsAndMarksForm.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Models;
using UnicomTicManagementSystem.Services;


namespace UnicomTicManagementSystem.Views
{
    public partial class ExamsAndMarksForm : Form
    {
        private readonly ExamController _controller;
        private bool _isProgrammaticallyChanging = false;

        public ExamsAndMarksForm()
        {
            InitializeComponent();
            _controller = new ExamController();
        }

        private async void ExamsAndMarksForm_Load(object sender, EventArgs e)
        {
            // Load everything needed for both tabs
            SetupFormForRole();
            await LoadExamsGridAsync();
            await LoadSubjectsIntoExamComboBoxAsync();
            await LoadExamsIntoMarksComboBoxAsync();
            ClearExamForm();
        }

        #region Manage Exams Tab Logic

        private void dgvExams_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExams.SelectedRows.Count > 0)
            {
                var exam = dgvExams.SelectedRows[0].DataBoundItem as Exam;
                if (exam != null)
                {
                    txtExamId.Text = exam.ExamID.ToString();
                    txtExamName.Text = exam.ExamName;
                    cmbSubjects.SelectedValue = exam.SubjectID;
                }
            }
        }

        private async void btnAddExam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExamName.Text))
            {
                MessageBox.Show("Please enter a name for the new exam.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExamName.Focus();
                return;
            }

            if (cmbSubjects.SelectedValue == null)
            {
                MessageBox.Show("Please select a subject for this exam.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                await _controller.AddExamAsync(new Exam { ExamName = txtExamName.Text.Trim(), SubjectID = (int)cmbSubjects.SelectedValue });
                MessageBox.Show("Exam added successfully!", "Success");
                await RefreshAllExamData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private async void btnUpdateExam_Click(object sender, EventArgs e)
        {
            try
            {
                await _controller.UpdateExamAsync(new Exam { ExamID = Convert.ToInt32(txtExamId.Text), ExamName = txtExamName.Text.Trim(), SubjectID = (int)cmbSubjects.SelectedValue });
                MessageBox.Show("Exam updated successfully!", "Success");
                await RefreshAllExamData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private async void btnDeleteExam_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Delete this exam and all associated marks?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await _controller.DeleteExamAsync(Convert.ToInt32(txtExamId.Text));
                    MessageBox.Show("Exam deleted successfully!", "Success");
                    await RefreshAllExamData();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            }
        }

        private void btnClearExam_Click(object sender, EventArgs e) => ClearExamForm();

        #endregion

        #region Enter Marks Tab Logic

        private async void cmbExamsForMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExamsForMarks.SelectedValue is int examId && examId > 0)
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
            foreach (DataGridViewRow row in dgvMarks.Rows)
            {
                var scoreCell = row.Cells["Score"];
                if (scoreCell.Value != null && scoreCell.Value != DBNull.Value && !string.IsNullOrEmpty(scoreCell.Value.ToString()))
                {
                    // Check if the value is a valid integer.
                    if (!int.TryParse(scoreCell.Value.ToString(), out int score))
                    {
                        MessageBox.Show($"The score '{scoreCell.Value}' for student '{row.Cells["StudentName"].Value}' is not a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop the entire process
                    }
                    // Check if the number is within the valid range.
                    if (score < 0 || score > 100)
                    {
                        MessageBox.Show($"The score '{score}' for student '{row.Cells["StudentName"].Value}' must be between 0 and 100.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop the entire process
                    }
                }
            }
            // --- END: VALIDATION BLOCK ---

            // If all validations pass, proceed with saving.
            try
            {
                var marksToSave = new List<Mark>();
                foreach (DataGridViewRow row in dgvMarks.Rows)
                {
                    if (row.Cells["Score"].Value != null && row.Cells["Score"].Value != DBNull.Value)
                    {
                        marksToSave.Add(new Mark
                        {
                            StudentID = (int)row.Cells["StudentID"].Value,
                            ExamID = (int)row.Cells["ExamID"].Value,
                            Score = Convert.ToInt32(row.Cells["Score"].Value)
                        });
                    }
                }

                if (marksToSave.Count == 0)
                {
                    MessageBox.Show("No scores were entered or changed to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var mark in marksToSave)
                {
                    await _controller.UpsertMarkAsync(mark);
                }
                MessageBox.Show("Marks saved successfully!", "Success");
            }
            catch (Exception ex) { MessageBox.Show($"Error saving marks: {ex.Message}", "Error"); }
        }

        #endregion

        #region Helper Methods

        private async Task RefreshAllExamData()
        {
            await LoadExamsGridAsync();
            await LoadExamsIntoMarksComboBoxAsync();
            ClearExamForm();
        }

        private void SetupFormForRole()
        {
            bool canManageExams = UserSession.Role == "Admin" || UserSession.Role == "Staff";
            bool canManageMarks = UserSession.Role != "Student";

            // Hide or show the "Manage Exams" editing controls
            groupBoxExams.Visible = canManageExams;

            // Hide or show the "Save Changes" button on the marks tab
            btnSaveChanges.Visible = canManageMarks;

            // Make marks grid read-only for students
            dgvMarks.ReadOnly = !canManageMarks;
        }

        private void ClearExamForm()
        {
            txtExamId.Clear();
            txtExamName.Clear();
            cmbSubjects.SelectedIndex = -1;
            dgvExams.ClearSelection();
        }

        private async Task LoadExamsGridAsync()
        {
            dgvExams.DataSource = await _controller.GetAllExamsAsync();
            if (dgvExams.Columns.Count > 0)
            {
                dgvExams.Columns["ExamID"].Visible = false;
                dgvExams.Columns["SubjectID"].Visible = false;
            }
        }

        private async Task LoadSubjectsIntoExamComboBoxAsync()
        {
            cmbSubjects.DataSource = await _controller.GetAllSubjectsAsync();
            cmbSubjects.DisplayMember = "SubjectName";
            cmbSubjects.ValueMember = "SubjectID";
        }

        private async Task LoadExamsIntoMarksComboBoxAsync()
        {
            cmbExamsForMarks.DataSource = await _controller.GetAllExamsAsync();
            cmbExamsForMarks.DisplayMember = "ExamName";
            cmbExamsForMarks.ValueMember = "ExamID";
            cmbExamsForMarks.SelectedIndex = -1;
        }

        private async Task LoadMarksGridAsync(int examId)
        {
            // ... (Full LoadMarksGridAsync logic from MarksForm goes here) ...
            try
            {
                _isProgrammaticallyChanging = true;
                List<Mark> marks = await _controller.GetMarksForExamAsync(examId);
                if (UserSession.Principal is Student student) { marks = marks.FindAll(m => m.StudentID == student.StudentID); }
                dgvMarks.DataSource = marks;
                if (dgvMarks.Columns.Count > 0)
                {
                    dgvMarks.Columns["MarkID"].Visible = false;
                    dgvMarks.Columns["StudentID"].Visible = false;
                    dgvMarks.Columns["ExamID"].Visible = false;
                    dgvMarks.Columns["Score"].ReadOnly = (UserSession.Role == "Student");
                }
            }
            finally { _isProgrammaticallyChanging = false; }
        }

        #endregion
    }
}