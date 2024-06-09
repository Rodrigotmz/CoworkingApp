using CoworkingApp.Data;
using CoworkingApp.Data.Enums;
using CoworkingApp.Data.Logic;
using CoworkingApp.Data.Tools;
using CoworkingApp.Model;
using static System.Console;
using static CoworkingApp.Data.Tools.MessageColors;


string rolSelected = "";
var listOption = new List<string> { "1", "2", "3", "4" };
UserData UserDataServicers = new UserData();
DeskData deskData = new DeskData();
var deskLogicServices = new DeskServices(deskData);
var adminLogicServices = new AdminServices(UserDataServicers);
var userActions = new UserServices(UserDataServicers, deskData);
string horaActual = DateTime.Now.ToString("hh:mm tt");
User Activeuser = new User();
do
{
    Clear();
    WriteLine($"[{horaActual}] Bienvenido a la app de Coworking");
    WriteLine("Por favor seleccione un rol: 1 - Admin, 2 - Usuario");
    rolSelected = ReadLine();

    if (Enum.Parse<UserRoles>(rolSelected) == UserRoles.Admin)
    {
        Activeuser = adminLogicServices.Login(true);

        string? menuAdminSelected = "0";
        while (true)
        {
            while (Enum.Parse<MenuAdmin>(menuAdminSelected) != MenuAdmin.AdministracionPuestos && Enum.Parse<MenuAdmin>(menuAdminSelected) != MenuAdmin.AdministracionUsuarios)
            {
                OkMessage("Bienvenido nuevamente");
                WriteLine("1 - Administracion de puestos, 2 - Administracion de usuarios");
                menuAdminSelected = ReadLine();
            }
            if (Enum.Parse<MenuAdmin>(menuAdminSelected) == MenuAdmin.AdministracionPuestos)
            {
                string menuPuestoSelected = "";
                while (!listOption.Contains(menuPuestoSelected))
                {
                    WriteLine("Administracion de puestos");
                    WriteLine("1 - Crear, 2 - Editar, 3 - Eliminar, 4 - Bloquear");
                    menuPuestoSelected = ReadLine();
                }

                AdminPuestos selectedAdminPuesto = Enum.Parse<AdminPuestos>(menuPuestoSelected);
                var deskInfo = deskLogicServices.ExecuteAction(selectedAdminPuesto);
                ConditionalMessage(deskInfo.Item2, deskInfo.Item1);

            }
            else if (Enum.Parse<MenuAdmin>(menuAdminSelected) == MenuAdmin.AdministracionUsuarios)
            {
                string menuUsuariosSelected = "0";
                while (!listOption.Contains(menuUsuariosSelected))
                {
                    Clear();
                    WriteLine("Administracion de usuarios");
                    WriteLine("1 - Crear, 2 - Editar, 3 - Eliminar, 4 - Cambiar contrasena");
                    menuUsuariosSelected = ReadLine();
                }
                AdminUser selectedUserOptions = Enum.Parse<AdminUser>(menuUsuariosSelected);
                var datos = adminLogicServices.ExecuteAction(selectedUserOptions);
                ConditionalMessage(datos.option, datos.message); 
            }
            menuAdminSelected = "0";
        }
    }
    else if (Enum.Parse<UserRoles>(rolSelected) == UserRoles.Usuario)
    {
        Activeuser = adminLogicServices.Login(false);
        string menuUsuarioSelec = "0";
        while (!listOption.Contains(menuUsuarioSelec))
        {
            WriteLine("1 - Reservar puesto, 2- Cancelar reserva, 3 - Ver el historial de reserva, 4 - Cambiar contraseña");
            menuUsuarioSelec = ReadLine();
        }
        MenuUser selectedUserMenu = Enum.Parse<MenuUser>(menuUsuarioSelec);
        userActions.ExecuteAction(selectedUserMenu,Activeuser);
    }

} while (Enum.Parse<UserRoles>(rolSelected) != UserRoles.Admin && Enum.Parse<UserRoles>(rolSelected) != UserRoles.Usuario);
WriteLine($"[{horaActual}] Programa terminado");