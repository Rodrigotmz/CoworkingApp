using CoworkingApp.Data.Tools;
using CoworkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoworkingApp.Data.Methods
{
    public static class MethodsUser
    {
        public static User CreateNewUser()
        {
            User newUser = new User();
            try
            {
                WriteLine("Escriba el nombre");
                newUser.Name = ReadLine();
                WriteLine("Escriba el apellido");
                newUser.LastName = ReadLine();
                WriteLine("Escriba el Email");
                newUser.Email = ReadLine();
                WriteLine("Escriba el password");
                newUser.Password = EncryptData.GetPassword();

                return newUser;
            }
            catch
            {
                return newUser;
            }
        }
        public static User EditUser(User editUser)
        {
            try
            {
                WriteLine("Escriba el nombre");
                editUser.Name = ReadLine();
                WriteLine("Escriba el apellido");
                editUser.LastName = ReadLine();
                WriteLine("Escriba el Email");
                editUser.Email = ReadLine();
                WriteLine("Escriba el password");
                editUser.Password = EncryptData.GetPassword();

                return editUser;
            }
            catch
            {
                return editUser;
            }
        }
        public static User ChangePassword(User newPassword)
        {
            try
            {
                WriteLine("Escriba el password");
                newPassword.Password = EncryptData.GetPassword();
                return newPassword;
            }
            catch
            {
                return newPassword;
            }
            
        }
    }
}
