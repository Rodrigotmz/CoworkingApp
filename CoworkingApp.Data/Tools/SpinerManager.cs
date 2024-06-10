using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace CoworkingApp.Data.Tools
{
    public static class SpinerManager
    {
        public static void ShowSpinner()
        {
            ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < 50; i++)
            {
                switch (i%4)
                {
                    case 0:
                        Write("/");
                        break;
                    case 1:
                        Write("-");
                        break;
                    case 2:
                        Write("\\");
                        break;
                    case 3:
                        Write("|");
                        break;
                }
                SetCursorPosition(CursorLeft-1, CursorTop);
                Sleep(150);
            }
            ResetColor();
        }
    }
}