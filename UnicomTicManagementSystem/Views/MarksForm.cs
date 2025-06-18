// In Views/MainForm.cs

using System;

namespace UnicomTicManagementSystem.Views
{
    internal class MarksForm : IDisposable
    {
        private object loggedInPrincipal;

        public MarksForm(object loggedInPrincipal)
        {
            this.loggedInPrincipal = loggedInPrincipal;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        internal void ShowDialog(MainForm mainForm)
        {
            throw new NotImplementedException();
        }
    }
}