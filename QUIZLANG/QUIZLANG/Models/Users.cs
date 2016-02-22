
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZLANG.Models
{
    public class Users:UserInfo
    {
           
        public string nativeLanguage { get; set; }
  
        public string learntLanguage { get; set; }
        public string teacher { get; set; }
     
    }
}
