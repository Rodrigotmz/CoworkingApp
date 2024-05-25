using CoworkingApp.Data;
using CoworkingApp.Data.Enums;
using CoworkingApp.Data.Logic;
using CoworkingApp.Data.Tools;
using static System.Console;
using static CoworkingApp.Data.Tools.MessageColors;


string rolSelected = "";
var listOption = new List<string> { "1", "2", "3", "4" };
UserData UserDataServicers = new UserData();
var userLogicServices = new UserServices(UserDataServicers);
string horaActual =  DateTime.Now.ToString("hh:mm tt");
do
{
    Clear();
    WriteLine($"[{horaActual}] Bienvenido a la app de Coworking");
    WriteLine("Por favor seleccione un rol: 1 - Admin, 2 - Usuario");
    rolSelected = ReadLine();

    if (Enum.Parse<UserRoles>(rolSelected) == UserRoles.Admin)
    {
        bool loginResult = false;
        while (!loginResult)
        {
            WriteLine("Ingrese usuario");
            var userLogin = ReadLine();
            WriteLine("Ingrese la contrasena");
            var passwordLogin = EncryptData.GetPassword();
            loginResult = UserDataServicers.Login(userLogin, passwordLogin);

            if (!loginResult)
            {
                ErrorMessage("Usuario o contrasena equivocados");
            }
        }

        string? menuAdminSelected = "0";
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
                Clear();
                WriteLine("Administracion de puestos");
                WriteLine("1 - Crear, 2 - Editar, 3 - Eliminar, 4 - Bloquear");
                menuPuestoSelected = ReadLine();
            }

            AdminPuestos selectedAdminPuesto = Enum.Parse<AdminPuestos>(menuPuestoSelected);

            var menuSelected = selectedAdminPuesto switch
            {
                AdminPuestos.Crear => "Opcion de Crear",
                AdminPuestos.Editar => "Opcion Editar",
                AdminPuestos.Eliminar => "Opcion Eliminar",
                AdminPuestos.Bloquear => "Opcion Bloquear",
                _ => "No se ha seleccionado ninguna opcion"
            };
            WriteLine(menuSelected);
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
            var datos = userLogicServices.ExecuteAction(selectedUserOptions);
            ConditionalMessage(datos.Item2, datos.Item1);
        }
    }
    else if (Enum.Parse<UserRoles>(rolSelected) == UserRoles.Usuario)
    {
        string menuUsuarioSelec = "0";
        while (!listOption.Contains(menuUsuarioSelec))
        {
            WriteLine("1 - Reservar puesto, 2- Cancelar reserva, 3 - Ver el historial de reserva, 4 - Cambiar contraseña");
            menuUsuarioSelec = ReadLine();
        }
        MenuUser selectedUserMenu = Enum.Parse<MenuUser>(menuUsuarioSelec);
        var menuUsarioSelected = selectedUserMenu switch
        {
            MenuUser.ReservarPuesto => "Opcion de Reservar puesto",
            MenuUser.CancelarReserva => "Opcion Cancelar reserva",
            MenuUser.VerHistorialReserva => "Opcion Ver el historial de reserva",
            MenuUser.CambiarPassword => "Opcion Cambiar contraseña",
            _ => "No se ha seleccionado ninguna opcion"
        };
        WriteLine(menuUsarioSelected);

    }

} while (Enum.Parse<UserRoles>(rolSelected) != UserRoles.Admin && Enum.Parse<UserRoles>(rolSelected) != UserRoles.Usuario);
WriteLine($"[{horaActual}] Programa terminado");