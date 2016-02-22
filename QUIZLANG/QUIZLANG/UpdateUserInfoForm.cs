using DAL;
using QUIZLANG.Common;
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
    public partial class UpdateUserInfoForm : Form
    {
        public UpdateUserInfoForm()
        {
            InitializeComponent();
        }
        QUIZLANGEntities entites = new QUIZLANGEntities();

        private void UpdateUserInfoForm_Load(object sender, EventArgs e)
        {
            txtUserName.Text = StaticInfo.CurrentUserInfo.username;

            var nativeLanguages = entites.Language.ToList();
            var learntLanguages = entites.Language.ToList();
            if (nativeLanguages != null)
            {
                cbNative.DataSource = nativeLanguages;
                cbNative.DisplayMember = "LanguageName";
                cbNative.ValueMember = "LanguageID";
                cbNative.SelectedValue = StaticInfo.CurrentUserInfo.nativeLanguageID;

                cbLearnt.DataSource = learntLanguages;
                cbLearnt.DisplayMember = "LanguageName";
                cbLearnt.ValueMember = "LanguageID";
                cbLearnt.SelectedValue = StaticInfo.CurrentUserInfo.learntLanguageID;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                userID = StaticInfo.CurrentUserInfo.userID,
                learntLanguageID = (int)cbLearnt.SelectedValue,
                nativeLanguageID = (int)cbNative.SelectedValue,
                username = txtUserName.Text,
            };

            entites.Entry(user).State = System.Data.Entity.EntityState.Modified;
            var result = entites.SaveChanges();
            if (result > 0)
            {
                StaticInfo.CurrentUserInfo.learntLanguageID = user.learntLanguageID;
                StaticInfo.CurrentUserInfo.nativeLanguageID = user.nativeLanguageID;
                StaticInfo.CurrentUserInfo.username = user.username;

                MessageBox.Show("Update user successful !", "QUIZLANG System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
