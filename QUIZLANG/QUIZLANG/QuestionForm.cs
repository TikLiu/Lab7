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
using QUIZLANG.Models;
using System.Collections;

namespace QUIZLANG
{
    public partial class QuestionForm : Form
    {
        public QuestionForm()
        {
            InitializeComponent();

            panel1.Visible = false;

        }
        QUIZLANGEntities entities = new QUIZLANGEntities();

        private List<QuestionInfo> questionList = new List<QuestionInfo>();
        private List<Directory> directoryList = new List<Directory>();

        private int currentIndex = 0;
        private Timer timer;

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            var questions = from a in entities.Question
                            join b in entities.Directory on a.DirectoryID equals b.ID
                            into c
                            from b in c.DefaultIfEmpty()
                            where b.Language1 == StaticInfo.CurrentUserInfo.nativeLanguage
                            && b.Language2 == StaticInfo.CurrentUserInfo.learntLanguage
                            && a.QuizID == StaticInfo.CurrentQuiz
                            select new QuestionInfo()
                            {
                                QuizID = a.QuizID,
                                DirectoryID = a.DirectoryID,
                                QuestionID = a.QuestionID,
                                Language1 = b.Language1,
                                Language2 = b.Language2,
                                WordsInLanguage1 = b.WordsInLanguage1,
                                WordsInLanguage2 = b.WordsInLanguage2
                            };

            directoryList = entities.Directory.ToList();

            questionList = questions.ToList();

            Random random = new Random();

            foreach (var item in questionList)
            {
                item.AllAnswers.Add(item.DirectoryID);

                for (int i = 0; i < 100; i++)
                {
                    int j = random.Next(questionList.Count);

                    if (questionList[j].DirectoryID != item.DirectoryID && item.AllAnswers.Count < 3)
                    {
                        while (!item.AllAnswers.Contains(questionList[j].DirectoryID))
                        {
                            item.AllAnswers.Add(questionList[j].DirectoryID);
                        }
                    }

                }

            }

            scorePerQuestion = 100 / questionList.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (GetSelectedAnswer() == -1)
            {
                //弹出消息提醒用户选择答案
                MessageBox.Show("Please choose the answer.", "QUIZLANG", MessageBoxButtons.OK);
                return;
            }
            else
            {
                //判断当前答案是否正确
                int answer = GetSelectedAnswer();
                if (currentIndex < questionList.Count)
                {
                    if (questionList[currentIndex].DirectoryID == answer)
                    {
                        totalScore += scorePerQuestion;
                    }

                    currentIndex++;

                    if (currentIndex < questionList.Count)
                        ShowQuestion();
                }
                else
                {
                    btnNext.Enabled = false;
                }

            }
        }

        private int GetSelectedAnswer()
        {
            if (rbtnA.Checked)
                return (int)rbtnA.Tag;
            else if (rbtnB.Checked)
                return (int)rbtnB.Tag;
            else if (rbtnC.Checked)
                return (int)rbtnC.Tag;
            else
                return -1;
        }

        private int scorePerQuestion = 0;
        private int totalScore = 0;


        private void btnStart_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            btnStart.Enabled = false;


            ShowQuestion();

            timer = new Timer()
            {
                Interval = 1000,
            };

            timer.Tick += Timer_Tick;

            timer.Start();
        }
        int i = StaticInfo.TotoalSecond;
        private void Timer_Tick(object sender, EventArgs e)
        {
            i--;

            lbTime.Text = string.Format("{0:T}", TimeSpan.FromSeconds(i));

            if (i == 0)
            {
                timer.Stop();

                btnNext.Enabled = false;
            }
        }

        private void InitButtonState(RadioButton btn)
        {
            btn.Text = string.Empty;
            btn.Tag = null;
            btn.Checked = false;
        }
        private void ShowQuestion()
        {
            InitButtonState(rbtnA);
            InitButtonState(rbtnB);
            InitButtonState(rbtnC);

            //所有问题的集合
            var allAnswers = (from a in entities.Question
                              join b in entities.Directory on a.DirectoryID equals b.ID
                              where b.Language1 == StaticInfo.CurrentUserInfo.nativeLanguage && b.Language2 == StaticInfo.CurrentUserInfo.learntLanguage
                              select b.ID).Distinct().ToList();

            //得到当前集合
            var currentQuestion = questionList[currentIndex];

            //set question
            lbQuestionDetail.Text = currentQuestion.WordsInLanguage1;

            Random random = new Random();

            //确定正确答案的索引位置
            int currectIndex = random.Next(0, (currentQuestion.AllAnswers.Count));

            switch (currectIndex)
            {
                case 0:

                    SetRadioValue(rbtnA, 0, 0, currentQuestion);
                    SetRadioValue(rbtnB, 1, 1, currentQuestion);
                    SetRadioValue(rbtnC, 2, 2, currentQuestion);

                    break;
                case 1:
                    SetRadioValue(rbtnA, 0, 1, currentQuestion);
                    SetRadioValue(rbtnB, 1, 0, currentQuestion);
                    SetRadioValue(rbtnC, 2, 2, currentQuestion);
                    break;
                case 2:
                    SetRadioValue(rbtnA, 0, 1, currentQuestion);
                    SetRadioValue(rbtnB, 1, 2, currentQuestion);
                    SetRadioValue(rbtnC, 2, 0, currentQuestion);
                    break;
                default:
                    break;
            }
        }

        private void SetRadioValue(RadioButton rbtn, int index, int answerIndex, QuestionInfo currentQuestion)
        {

            rbtn.Tag = currentQuestion.AllAnswers[answerIndex];
            QuestionInfo info = questionList.Where(a => a.DirectoryID == currentQuestion.AllAnswers[answerIndex]).FirstOrDefault();


            switch (index)
            {
                case 0:
                    rbtn.Text = string.Format("A.{0}", info.WordsInLanguage2);
                    break;
                case 1:
                    rbtn.Text = string.Format("B.{0}", info.WordsInLanguage2);
                    break;
                case 2:
                    rbtn.Text = string.Format("C.{0}", info.WordsInLanguage2);
                    break;

                default:
                    break;
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            History history = new History()
            {
                userID = StaticInfo.CurrentUserInfo.userID,
                learntLanName = StaticInfo.CurrentUserInfo.learntLanguage,
                nativeLanName = StaticInfo.CurrentUserInfo.nativeLanguage,
                result = totalScore,
                time = DateTime.Now,
            };
            entities.History.Add(history);
            //返回受影响的行数
            int result = entities.SaveChanges();
            if (result > 0)
            {
                MessageBox.Show(" The result Score " + totalScore + " has been add into History", "QUIZLANG", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


    }
}
