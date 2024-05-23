using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoworkingApp.Data.Tools
{
    public static class MessageColors
    {
        public static void ErrorMessage(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ResetColor();
        }

        public static void WarningMessage(string message)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(message);
            ResetColor();
        }

        public static void OkMessage(string message)
        {
            ForegroundColor= ConsoleColor.Green;
            WriteLine(message);
            ResetColor();
        }
    }
}
