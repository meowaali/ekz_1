using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17
{
    internal static class Program
    {
        //public static int CurrentUser { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
        }
        public static NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=5432;UserName=postgres;Password=avemelissa;Database=ekz");
    }
}
