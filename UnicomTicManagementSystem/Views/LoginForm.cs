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
using UnicomTicManagementSystem.Views;

namespace UnicomTicManagementSystem
{
    public partial class LoginForm : Form
    {
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            // 1. Get the input from the text boxes.
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Basic validation: make sure fields are not empty.
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop the method here
            }

            try
            {
                // 2. Create an instance of our controller.
                LoginController loginController = new LoginController();

                // 3. Use the controller to attempt the login.
                var loggedInPrincipal = await loginController.AuthenticateAsync(username, password);

                // 4. Check the result.
                if (loggedInPrincipal is User user) // Ensure the object is of type 'User'
                {
                    // Login was successful!
                    _ = MessageBox.Show(text: $"Welcome, {user.UserName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Create the main form, passing the logged-in user's information.
                    var mainForm = new MainForm(user);
                    mainForm.Show(); // Show the new form.

                    this.Hide(); // Hide the login form.
                }
                else
                {
                    // Login failed.
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the login process.
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
