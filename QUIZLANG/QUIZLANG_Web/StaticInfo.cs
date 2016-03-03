using QUIZLANG_Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUIZLANG_Web
{
    public static class StaticInfo
    {
        public static UserInfo CurrentUserInfo{ get; set; }

        public static quizlangEntities Entities
        {
            get; set;
        }
    }
}