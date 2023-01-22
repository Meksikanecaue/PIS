using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiwi
{
    static class Program
    {
        public static string id = "";
        public static string login = "";
        public static string password = "";
        public static string phone_number = "";
        public static string adress = "";
        internal static string idUsers;
        internal static string Фамилия;
        internal static string Имя;
        internal static string Пароль;
        internal static string Отчество;
        internal static string Элпочта;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
