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
            if (string.IsNullOrWhiteSpace(txtExamId.Text)) { MessageBox.Show("Please select an exam to update.", "Selection Required"); return; }
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
            if (string.IsNullOrWhiteSpace(txtExamId.Text)) { MessageBox.Show("Please select an exam to delete.", "Selection Required"); return; }
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
                    if (!int.TryParse(scoreCell.Value.ToString(), out int score) || score < 0 || score > 100)
                    {
                        MessageBox.Show($"The score for {row.Cells["StudentName"].Value} must be a whole number between 0 and 100.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            try
            {
                var marksToSave = new List<Mark>();
                foreach (DataGridViewRow row in dgvMarks.Rows)
                {
                    if (row.Cells["Score"].Value != null && row.Cells["Score"].Value != DBNull.Value)
                    {
                        marksToSave.Add(new Mark { StudentID = (int)row.Cells["StudentID"].Value, ExamID = (int)row.Cells["ExamID"].Value, Score = Convert.ToInt32(row.Cells["Score"].Value) });
                    }
                }
                if (marksToSave.Count == 0) { MessageBox.Show("No scores were entered or changed to save.", "Information"); return; }
                foreach (var mark in marksToSave) { await _controller.UpsertMarkAsync(mark); }
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

            groupBoxExams.Visible = canManageExams;
            btnSaveChanges.Visible = canManageMarks;
            dgvMarks.ReadOnly = !canManageMarks;

            if (!canManageExams && !canManageMarks)
            {
                // If a user has no edit rights at all (e.g., a future role), hide the entire tab control.
                // For now, we just disable tabs they can't use.
                if (!canManageExams) tabControlMain.TabPages.Remove(tabPageExams);
            }
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
            try
            {
                dgvExams.DataSource = await _controller.GetAllExamsAsync();
                if (dgvExams.Columns.Count > 0)
                {
                    dgvExams.Columns["ExamID"].Visible = false;
                    dgvExams.Columns["SubjectID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Failed to load exams: {ex.Message}", "Data Error"); }
        }

        private async Task LoadSubjectsIntoExamComboBoxAsync()
        {
            try
            {
                cmbSubjects.DataSource = await _controller.GetAllSubjectsAsync();
                cmbSubjects.DisplayMember = "SubjectName";
                cmbSubjects.ValueMember = "SubjectID";
            }
            catch (Exception ex) { MessageBox.Show($"Failed to load subjects: {ex.Message}", "Data Error"); }
        }

        private async Task LoadExamsIntoMarksComboBoxAsync()
        {
            try
            {
                cmbExamsForMarks.DataSource = await _controller.GetAllExamsAsync();
                cmbExamsForMarks.DisplayMember = "ExamName";
                cmbExamsForMarks.ValueMember = "ExamID";
                cmbExamsForMarks.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show($"Failed to load exams for marks tab: {ex.Message}", "Data Error"); }
        }

        private async Task LoadMarksGridAsync(int examId)
        {
            try
            {
                _isProgrammaticallyChanging = true;
                List<Mark> marks = await _controller.GetMarksForExamAsync(examId);
                if (UserSession.Principal is Student student) { marks = marks.FindAll(m => m.StudentID == student.StudentID); }
                dgvMarks.DataSource = marks;
                if (dgvMarks.Columns.Count > 0)
                {
                    // Hide internal IDs
                    dgvMarks.Columns["MarkID"].Visible = false;
                    dgvMarks.Columns["StudentID"].Visible = false;
                    dgvMarks.Columns["ExamID"].Visible = false;

                    // Set ReadOnly status for columns
                    dgvMarks.Columns["StudentName"].ReadOnly = true;
                    dgvMarks.Columns["ExamName"].ReadOnly = true;
                    dgvMarks.Columns["SubjectName"].ReadOnly = true;
                    dgvMarks.Columns["Score"].ReadOnly = (UserSession.Role == "Student");

                    // Set user-friendly header text
                    dgvMarks.Columns["StudentName"].HeaderText = "Student Name";
                    dgvMarks.Columns["ExamName"].HeaderText = "Exam";
                    dgvMarks.Columns["SubjectName"].HeaderText = "Subject";
                }
            }
            catch (Exception ex) { MessageBox.Show($"Failed to load marks: {ex.Message}", "Data Error"); }
            finally { _isProgrammaticallyChanging = false; }
        }
        #endregion
    }
}