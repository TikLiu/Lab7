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

namespace QUIZLANG
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        QUIZLANGEntities entites = new QUIZLANGEntities();

        private void SignInForm_Load(object sender, EventArgs e)
        {
            var nativeLanguages = entites.Language.ToList();
            var learntLanguages = entites.Language.ToList();
            if(nativeLanguages != null)
            {
                cbNative.DataSource = nativeLanguages;
                cbNative.DisplayMember = "LanguageName";
                cbNative.ValueMember = "LanguageID";
                cbNative.SelectionStart = 0;

                cbLearnt.DataSource = learntLanguages;
                cbLearnt.DisplayMember = "LanguageName";
                cbLearnt.ValueMember = "LanguageID";
                cbLearnt.SelectionStart = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sign in
            string username = txtUserName.Text.Trim();


            if (username == "")
            {
                MessageBox.Show("username can not be empty !", "QUIZLANG System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            UserInfo user = new UserInfo()
            {
                learntLanguageID = (int)cbLearnt.SelectedValue,
                nativeLanguageID = (int)cbNative.SelectedValue,
                username = txtUserName.Text
            };

             entites.UserInfo.Add(user);
            var result = entites.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show("Sign in user successful !", "QUIZLANG System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
