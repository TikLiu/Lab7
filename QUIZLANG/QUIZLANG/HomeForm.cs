using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZLANG
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();

            //run login form
            LoginForm login = new LoginForm();
            login.ShowDialog(this);
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUserInfoForm signIn = new UpdateUserInfoForm();
            signIn.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void onlineTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm test = new TestForm();
            test.Show();
        }

        private void queryResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultForm resultForm = new ResultForm();
            resultForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }
    }
}
