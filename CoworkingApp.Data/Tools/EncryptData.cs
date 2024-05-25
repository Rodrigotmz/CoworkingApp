using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoworkingApp.Data.Tools
{
    public static class EncryptData
    {
        public static string EncryptText(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                var has = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return has;
            }
        }
        public static string GetPassword()
        {
            string passwordInput = "";
            while (true)
            {
                var keyPress = ReadKey(true);
                if (keyPress.Key == ConsoleKey.Enter)
                {
                    WriteLine(" ");
                    break;
                }
                else
                {
                    Write("*");
                    passwordInput += keyPress.KeyChar;
                }
            }
            return passwordInput;
        }
    }
}
