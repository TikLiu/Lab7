using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QUIZLANG_Web.Data;
using QUIZLANG_Web.Models;
using System.Text;

namespace QUIZLANG_Web.Views
{
    public partial class AddNewQuize : System.Web.UI.Page
    {

        quizlangEntities entities = new quizlangEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLanguage(dropDownListLearning);
                LoadLanguage(dropDownListNative);

            }
        }

        private void LoadLanguage(DropDownList listControl)
        {
            var languages = entities.Language.ToList();
            foreach (var item in languages)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(item.LanguageName);

                item.LanguageName = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }
            if (languages != null)
            {
                listControl.DataSource = languages;
                listControl.DataTextField = "LanguageName";
                listControl.DataValueField = "LanguageID";
                listControl.DataBind();
            }
        }

        private void LoadQuestions()
        {
            //query questions
            var questions = from a in entities.Directory
                            where a.Language1 == dropDownListLearning.SelectedItem.Text
                            && a.Language2 == dropDownListNative.SelectedItem.Text
                            select new DirectoryModel()
                            {
                                ID = a.ID,
                                Language1 = a.Language1,
                                Language2 = a.Language2,
                                WordsInLanguage1 = a.WordsInLanguage1,
                                WordsInLanguage2 = a.WordsInLanguage2,
                                Question = a.WordsInLanguage1 + " : " + a.WordsInLanguage2
                            };
            var questionList = questions.ToList();

            if (questionList != null)
            {
                listBoxQuestion.DataSource = questionList;
                listBoxQuestion.DataTextField = "Question";
                listBoxQuestion.DataValueField = "ID";
                listBoxQuestion.DataBind();
            }
        }

        protected void dropDownListNative_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownListLearning.SelectedItem != null && dropDownListNative.SelectedItem != null)
            {
                LoadQuestions();
            }
        }

        protected void dropDownListLearning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownListLearning.SelectedItem != null && dropDownListNative.SelectedItem != null)
            {
                LoadQuestions();
            }
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            if (listBoxQuestion.SelectedItem != null)
            {
                listBoxSelectQustion.Items.Add(listBoxQuestion.SelectedItem);
                listBoxQuestion.Items.Remove(listBoxQuestion.SelectedItem);
            }
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            if (listBoxSelectQustion.Items.Count > 0)
            {
                var questions = (from a in entities.Question
                                 select a.QuizID).Max();
                questions++;

                foreach (var item in listBoxSelectQustion.Items)
                {
                    Question model = new Question()
                    {
                        QuizID = questions,
                        DirectoryID = int.Parse(((ListItem)item).Value)
                    };

                    entities.Question.Add(model);
                }
                var result = entities.SaveChanges();
                if (result > 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert(' Add  new quiz Successful!');</script>");
                }
            }
        }
    }
}