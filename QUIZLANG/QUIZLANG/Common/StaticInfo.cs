using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using QUIZLANG.Models;

namespace QUIZLANG.Common
{
    public static class StaticInfo
    {
        public static Users CurrentUserInfo
        {
            get; set;
        }

        public static int CurrentQuiz
        {
            get;
            set;
        }

        public const int TotoalSecond = 1800; 

    }
}
