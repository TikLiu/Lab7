using QUIZLANG_Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QUIZLANG_Web.Models
{
    public class Users : UserInfo
    {
        public string nativeLanguage { get; set; }

        public string learntLanguage { get; set; }
    

    }
}