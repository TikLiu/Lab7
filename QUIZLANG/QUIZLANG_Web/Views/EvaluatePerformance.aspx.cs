using QUIZLANG_Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QUIZLANG_Web.Views
{
    public partial class EvaluatePerformance : System.Web.UI.Page
    {
        Data.quizlangEntities entities = new Data.quizlangEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStudents();
            }
            btnUpdate.Click += BtnUpdate_Click;
            dropDownListStudent.SelectedIndexChanged += DropDownListStudent_SelectedIndexChanged;

        }


        private void DropDownListStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownListStudent.SelectedValue != null)
            {
                int userid = int.Parse(dropDownListStudent.SelectedValue.ToString());
                BindGridViewData(userid);

                panelGrade.Visible = true;
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string grade = dropDownListGrade.SelectedValue.ToString();
            string studentID = dropDownListStudent.SelectedValue.ToString();

            UserInfo userInfo = new UserInfo()
            {
                userID = int.Parse(studentID),
                grade = int.Parse(grade)
            };

            entities.Entry(userInfo).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();

        }

        private void BindStudents()
        {
            //load students
            var students = from a in entities.UserInfo
                           join b in entities.Language on a.learntLanguageID equals b.LanguageID
                           join c in entities.Language on a.nativeLanguageID equals c.LanguageID
                           where a.teacherID == 0
                           select new Models.Users()
                           {
                               grade = a.grade,
                               learntLanguageID = a.learntLanguageID,
                               nativeLanguageID = a.nativeLanguageID,
                               teacherID = a.teacherID,
                               userID = a.userID,
                               username = a.username,
                               learntLanguage = b.LanguageName,
                               nativeLanguage = c.LanguageName,
                           };

            var studentList = students.ToList();
            if (studentList != null)
            {
                dropDownListStudent.DataSource = studentList;
                dropDownListStudent.DataTextField = "username";
                dropDownListStudent.DataValueField = "userID";
                dropDownListStudent.DataBind();

                if (dropDownListStudent.SelectedValue != null)
                {
                    int userid = int.Parse(dropDownListStudent.SelectedValue.ToString());
                    BindGridViewData(userid);

                    panelGrade.Visible = true;
                }
            }
        }

        private void BindGridViewData(int userid)
        {
            var history = entities.History.Where(a => a.userID == userid).ToList();
            if (history != null)
            {
                gridViewStudentDetail.DataSource = history;
                gridViewStudentDetail.DataBind();
            }
            else
            {
                gridViewStudentDetail.DataSource = null;
            }
        }
    }
}