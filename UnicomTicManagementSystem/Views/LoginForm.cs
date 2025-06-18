// In Views/LoginForm.cs

using System;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;

namespace UnicomTicManagementSystem.Views
{
    // This correctly inherits from Form.
    public partial class LoginForm : Form
    {
        // NOTE: We have removed the incorrect declarations of txtUsername and txtPassword.
        // The real controls are defined in the Designer.cs file.

        // This is the constructor. It calls the method that draws the controls.
        public LoginForm()
        {
            InitializeComponent();
        }

        // This is the logic for the login button click event.
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Now, this code will correctly find the 'Text' property because
            // it's referring to the real TextBox controls.
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var loginController = new LoginController();
                object principal = await loginController.AuthenticateAsync(txtUsername.Text.Trim(), txtPassword.Text);

                if (principal != null)
                {
                    // If login is successful, create the MainForm
                    var mainForm = new MainForm(principal);
                    mainForm.Show();
                    this.Hide(); // Hide the login form
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A system error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}