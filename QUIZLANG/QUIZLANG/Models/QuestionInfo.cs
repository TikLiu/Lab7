using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZLANG.Models
{
    public class QuestionInfo:Question
    {
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string WordsInLanguage1 { get; set; }
        public string WordsInLanguage2 { get; set; }

        private List<int> allAnswers = new List<int>();
        public List<int> AllAnswers { get { return allAnswers; } set { allAnswers = value; } }
    }
}
