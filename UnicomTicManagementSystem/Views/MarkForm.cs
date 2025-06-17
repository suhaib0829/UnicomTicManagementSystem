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

namespace UnicomTicManagementSystem.Views
{

    public partial class MarkForm : Form
    {
        private readonly User _currentUser;

        public MarkForm(User user)
        {
            InitializeComponent();
            _currentUser = user; // Store the user
            this.Text = $"Course Management - Logged in as: {_currentUser.Username}";
        }
    }
}
