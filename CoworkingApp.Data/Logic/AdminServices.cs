using System.Runtime.Intrinsics.X86;
using CoworkingApp.Data.Enums;
using CoworkingApp.Data.Methods;
using CoworkingApp.Data.Tools;
using CoworkingApp.Model;
using static System.Console;
using static CoworkingApp.Data.Tools.MessageColors;


namespace CoworkingApp.Data.Logic
{
    public class AdminServices
    {
        private UserData _data { get; set; }
        private Response _response {  get; set; }
        public AdminServices(UserData userData)
        {
            _data = userData;
            _response = new Response() { 
                message = "Opcion invalida"
            };
        }

        public Response ExecuteAction(AdminUser selectedAdminPuesto)
        {
            Response menuSelected = selectedAdminPuesto switch
            {
                AdminUser.Crear => _data.CreateUser(MethodsUser.CreateNewUser()),
                AdminUser.Editar => EditUsers(),
                AdminUser.Eliminar => RemoveUsers(),
                AdminUser.CambiarPassword => ChangePassword(),
                _ => _response 
            };
            return menuSelected;
        }
        public Response EditUsers()
        {
            WriteLine("Escriba el correo del usuario a editar");
            var userFound = _data.FindUser(ReadLine());
            if (userFound == null)
            {
                WriteLine("No se encuentra el correo del usuario ingresado, favor de escibrir un correo valido");
                userFound = _data.FindUser(ReadLine());
            }
            var editData = MethodsUser.EditUser(userFound);
            _response = _data.EditUser(editData);
            return _response;
        }

        public Response ChangePassword()
        {
            WriteLine("Escriba el correo del usuario a editar");
            var userFound = _data.FindUser(ReadLine());
            if (userFound == null)
            {
                WriteLine("No se encuentra el correo del usuario ingresado, favor de escibrir un correo valido");
                userFound = _data.FindUser(ReadLine());
            }
            var editData = MethodsUser.ChangePassword(userFound);
            _response = _data.EditUser(editData);
            return _response;
        }

        public Response RemoveUsers()
        {
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
                _response = _data.RemoveUser(userFound.UserId);
            }
            else
            {
                _response.message = "No se elimino ningun usuario";
            }

            return _response;
        }
       
        public User Login(bool isAdmin)
        {
            bool loginResult = false;
            while (!loginResult)
            {
                WriteLine("Ingrese usuario");
                var userLogin = ReadLine();
                WriteLine("Ingrese la contrasena");
                var passwordLogin = EncryptData.GetPassword();
                var userLogged = _data.Login(userLogin, passwordLogin, isAdmin);
                loginResult = userLogged != null;
                if (!loginResult) ErrorMessage("Usuario o contrasena equivocados");
                else return userLogged;
            }
            return null;
        }
    }
}
