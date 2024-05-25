using CoworkingApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CoworkingApp.Data.Methods;

namespace CoworkingApp.Data.Logic
{
    public class UserServices
    {
        private UserData _data { get; set; }
        public UserServices(UserData userData)
        {
            _data = userData;
        }

        public (string, bool) ExecuteAction(AdminUser selectedAdminPuesto)
        {
            var menuSelected = selectedAdminPuesto switch
            {
                AdminUser.Crear => _data.CreateUser(MethodsUser.CreateNewUser()),
                AdminUser.Editar => EditUsers(),
                AdminUser.Eliminar => RemoveUsers(),
                AdminUser.CambiarPassword => ChangePassword(),
                _ => ("No se ha seleccionado ninguna opcion", false)
            };
            return menuSelected;
        }
        public (string, bool) EditUsers()
        {
            WriteLine("Escriba el correo del usuario a editar");
            var userFound = _data.FindUser(ReadLine());
            if (userFound == null)
            {
                WriteLine("No se encuentra el correo del usuario ingresado, favor de escibrir un correo valido");
                userFound = _data.FindUser(ReadLine());
            }
            var editData = MethodsUser.EditUser(userFound);
            var data = _data.EditUser(editData);

            return (data.Item1, data.Item2);
        }

        public (string, bool) ChangePassword()
        {
            WriteLine("Escriba el correo del usuario a editar");
            var userFound = _data.FindUser(ReadLine());
            if (userFound == null)
            {
                WriteLine("No se encuentra el correo del usuario ingresado, favor de escibrir un correo valido");
                userFound = _data.FindUser(ReadLine());
            }
            var editData = MethodsUser.ChangePassword(userFound);
            var data = _data.EditUser(editData);

            return (data.Item1, data.Item2);
        }

        public (string,bool) RemoveUsers()
        {
            (string, bool) data = ("",false);
            WriteLine("Escriba el correo del usuario a eliminar");
            var userFound = _data.FindUser(ReadLine());
            if (userFound == null)
            {
                WriteLine("No se encuentra el correo del usuario ingresado, favor de escibrir un correo valido");
                userFound = _data.FindUser(ReadLine());
            }
            WriteLine($"¿Esta seguro de querer eliminar a {userFound.Name} {userFound.LastName} - SI / NO?");
            string opcion = ReadLine();
            if (opcion.ToUpper() == "SI" || opcion.ToUpper() == "S")
            {
                (data.Item1,data.Item2) = _data.RemoveUser(userFound.UserId);
            }
            else
            {
                data = ("No se elimino ningun usuario", false);
            }
            return (data.Item1, data.Item2);
        }
    }
}
