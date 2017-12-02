using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using System.Web;

namespace Oleg
{
    public partial class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        
        [STAThread]
        
        static void Main()
        {

            
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
