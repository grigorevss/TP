using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            if (args.Length > 0)
            {
                ManageClass.index = Convert.ToInt32(args[0]);
            }
#endif
            Application.Run(new MainWindow());
        }
    }
}
