using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Data.Entity;
using QUIZLANG.Common;
using QUIZLANG.Models;

namespace QUIZLANG
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("User Name can not be empty!", "QUIZLANG", MessageBoxButtons.OK);
                txtUserName.Focus();
                return;
            }

            //check user state
            QUIZLANGEntities entitiess = new QUIZLANGEntities();
            var user = entitiess.UserInfo.Where(a => a.username == txtUserName.Text).FirstOrDefault();

            if (user != null)
            {
                StaticInfo.CurrentUserInfo = new Users()
                {
                    grade = user.grade,
                    learntLanguageID = user.learntLanguageID,
                    nativeLanguageID = user.nativeLanguageID,
                    teacherID = user.teacherID,
                    userID = user.userID,
                    username = user.username,
                  
                }; 

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignInForm signin = new SignInForm();
            signin.Show();
        }
    }
}
