using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoworkingApp.Data.Tools
{
    public static class MethodsGen
    {
        public static void BorderLine()
        {
            int codigoWidth = 10;
            int nombreWidth = 20;
            int estatusWidth = 10;
            // Crear la línea de borde
            string borderLine = "+" + new string('-', codigoWidth) + "+" + new string('-', nombreWidth) + "+" + new string('-', estatusWidth) + "+";
            WriteLine(borderLine);
        }
        public static void PrintWithColor(string number, string descript, int codeWidth)
        {
            Write("|");
            ForegroundColor = ConsoleColor.Green;
            Write($"{number.PadRight(codeWidth)}");
            ResetColor();
            Write("|");
            ForegroundColor = ConsoleColor.Green;
            Write($"{descript.PadRight(codeWidth)}");
            ResetColor();
            Write("|");
            WriteLine();
        }
        public static void PrintWithColors(string number, string fecha,string active, bool color,int longitud)
        {
            ConsoleColor colorConsole = color == true ? ConsoleColor.Green: ConsoleColor.DarkGray;
            Write("|");
            ForegroundColor = colorConsole;
            Write($"{number.PadRight(longitud)}");
            ResetColor();
            Write("|");
            ForegroundColor = colorConsole;
            Write($"{fecha.PadRight(longitud)}");
            ResetColor();
            Write("|");
            ForegroundColor = colorConsole;
            Write($"{active.PadRight(longitud)}");
            ResetColor();
            Write("|");
            WriteLine();
        }
    }
}
