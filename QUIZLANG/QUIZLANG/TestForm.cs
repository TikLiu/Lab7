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
using QUIZLANG.Common;

namespace QUIZLANG
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        QUIZLANGEntities entities = new QUIZLANGEntities();

        private void TestForm_Load(object sender, EventArgs e)
        {
            //var user = from a in entities.UserInfo
            //           join b in entities.Language on  a.learntLanguageID  equals b.LanguageID 
            //           into u
            //           join c in entities.Language on a.nativeLanguageID equals c.LanguageID
            //           into d
            //           from b in d.DefaultIfEmpty()
            //           from c in d.DefaultIfEmpty()
            //           where a.userID == StaticInfo.CurrentUserInfo.userID
            //           select new QUIZLANG.Models.Users
            //           {
            //               userID = a.userID,
            //               username = a.username,
            //               grade = a.grade,
            //               learntLanguage = b.LanguageName,
            //               nativeLanguageID = a.nativeLanguageID,
            //               learntLanguageID = a.learntLanguageID,
            //               nativeLanguage = c.LanguageName,
            //               teacherID = a.teacherID, 
            //           };


            var search = entities.Language.Where(a => a.LanguageID != StaticInfo.CurrentUserInfo.nativeLanguageID).ToList();

            cbTestingLan.DataSource = search;
            cbTestingLan.DisplayMember = "LanguageName";
            cbTestingLan.ValueMember = "LanguageID";
            cbTestingLan.SelectionStart = 0;
            cbTestingLan.SelectedValue = StaticInfo.CurrentUserInfo.learntLanguageID;


            cbTestingLan.SelectedIndexChanged += CbTestingLan_SelectedIndexChanged;

            UpdateQuiz();
        }

        private void CbTestingLan_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateQuiz();
        }

        private void UpdateQuiz()
        {
            try
            {
                //update 
                int LanguageID = Convert.ToInt32(cbTestingLan.SelectedValue);
                string LearntLanName = entities.Language.Where(a => a.LanguageID == LanguageID).FirstOrDefault().LanguageName;
                string nativeLanName = entities.Language.Where(a => a.LanguageID == StaticInfo.CurrentUserInfo.nativeLanguageID).FirstOrDefault().LanguageName;

                var quizList = (from a in entities.Question
                                join b in entities.Directory on a.DirectoryID equals b.ID
                                where b.Language1 == nativeLanName && b.Language2 == LearntLanName
                                select a.QuizID)
                               .Distinct();

                cbChooseQuiz.DataSource = quizList.ToList();
            }
            catch (Exception)
            {
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            // 1 验证是否选择了测试语言
            if (Convert.ToInt32(cbTestingLan.SelectedValue) == 0)
            {
                MessageBox.Show("Please choice a language for testing ！", " Information !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTestingLan.Focus();
            }
            // 2 如果选择了
            else
            {

                if (cbChooseQuiz.SelectedValue != null) // 3 如果选择了对应语言的quiz
                {
                    int LanguageID = Convert.ToInt32(cbTestingLan.SelectedValue);

                    int QuizID = (int)cbChooseQuiz.SelectedValue;
                    string LearntLanName = entities.Language.Where(a => a.LanguageID == LanguageID).FirstOrDefault().LanguageName;
                    string nativeLanName = entities.Language.Where(a => a.LanguageID == StaticInfo.CurrentUserInfo.nativeLanguageID).FirstOrDefault().LanguageName;


                    StaticInfo.CurrentUserInfo.learntLanguage = LearntLanName;
                    StaticInfo.CurrentUserInfo.nativeLanguage = nativeLanName;
                    StaticInfo.CurrentQuiz = QuizID;

                    QuestionForm question = new QuestionForm();
                    question.Show();

                }
                else
                {
                    MessageBox.Show(" Please select your quize ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbChooseQuiz.Focus();
                }
            }
        }

    }
}
