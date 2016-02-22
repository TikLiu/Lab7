using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DAL;

namespace QUIZLANG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            HomeForm mainform = new HomeForm();
            Application.Run(mainform);


            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<QUIZLANGEntities>());
        }
    }
}
