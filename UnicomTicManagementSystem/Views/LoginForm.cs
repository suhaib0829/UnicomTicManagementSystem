// In Views/LoginForm.cs

using System;
using System.Windows.Forms;
using UnicomTicManagementSystem.Controllers;
using UnicomTicManagementSystem.Services;

namespace UnicomTicManagementSystem.Views
{
    // This correctly inherits from Form.
    public partial class LoginForm : Form
    {
        // The constructor for the form
        public LoginForm()
        {
            // This method (defined in LoginForm.Designer.cs) creates and draws all the controls.
            InitializeComponent();
        }

        /// <summary>
        /// This method is the event handler for the Login button's Click event.
        /// </summary>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // --- 1. Client-Side Validation ---
            // Check if the user has entered text in both fields before proceeding.
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus(); // Set the cursor to the username field
                return; // Stop the method here
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus(); // Set the cursor to the password field
                return; // Stop the method here
            }

            // --- 2. Attempt Authentication ---
            // Use a try-catch block to handle any potential errors during the login process.
            try
            {
                // Create an instance of our controller to handle the business logic.
                var loginController = new LoginController();

                // Call the controller's AuthenticateAsync method and await the result.
                // This will check both the Users and Students tables.
                object principal = await loginController.AuthenticateAsync(txtUsername.Text.Trim(), txtPassword.Text);

                // --- 3. Handle the Result ---
                if (principal != null)
                {
                    // Login was successful!

                    // IMPROVEMENT: Start the global user session.
                    // This stores the logged-in user's information so any form can access it.
                    UserSession.StartSession(principal);

                    // Create an instance of the main dashboard.
                    // We no longer need to pass the 'principal' object to its constructor.
                    var mainForm = new MainForm();

                    // Show the main dashboard.
                    mainForm.Show();

                    // Hide the login form so it disappears from view.
                    this.Hide();
                }
                else
                {
                    // If the principal object is null, the username/password was incorrect.
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // This catch-all block handles any unexpected system errors (e.g., database file is missing or corrupt).
                MessageBox.Show($"A critical system error occurred: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}