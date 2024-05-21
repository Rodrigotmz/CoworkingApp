using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingApp.Data.Tools
{
    public static class EncryptData
    {
        public static string EncryptText(string text) 
        {
            using(var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                var has = BitConverter.ToString(hashBytes).Replace("-","").ToLower();
                return has;
            }
        }
    }
}
