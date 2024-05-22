using CoworkingApp.Data;
using static System.Console;

string rolSelected = "";
do
{
    Clear();
    WriteLine("Bienvenido a la app de Coworking");
    WriteLine("Por favor seleccione un rol: 1 - Admin, 2 - Usuario");
    rolSelected = ReadLine();

    if (rolSelected == "1")
    {
        string menuAdminSelected = "";
        while (menuAdminSelected != "1" && menuAdminSelected != "2")
        {
            WriteLine("1 - Administracion de puestos, 2 - Administracion de usuarios");
            menuAdminSelected = ReadLine();
        }
        if (menuAdminSelected == "1")
        {
            string menuPuestoSelected = "";
            while (menuPuestoSelected != "1" && menuPuestoSelected != "2" && menuPuestoSelected != "3" && menuPuestoSelected != "4")
            {
                Clear();
                WriteLine("Administracion de puestos");
                WriteLine("1 - Crear, 2 - Editar, 3 - Eliminar, 4 - Bloquear");
                menuPuestoSelected = ReadLine();
            }
            var menuSelected = menuPuestoSelected switch
            {
                "1" => "Opcion de Crear",
                "2" => "Opcion Editar",
                "3" => "Opcion Eliminar",
                "4" => "Opcion Bloquear",
                _ => "No se ha seleccionado ninguna opcion"
            };
            WriteLine(menuSelected);
        }
        else if (menuAdminSelected == "2")
        {
            string menuUsuariosSelected = "";
            while (menuUsuariosSelected != "1" && menuUsuariosSelected != "2" && menuUsuariosSelected != "3" && menuUsuariosSelected != "4")
            {
                Clear();
                WriteLine("Administracion de puestos");
                WriteLine("1 - Crear, 2 - Editar, 3 - Eliminar, 4 - Bloquear");
                menuUsuariosSelected = ReadLine();
            }
            var menuSelected = menuUsuariosSelected switch
            {
                "1" => "Opcion de Crear usuario",
                "2" => "Opcion Editar usuario",
                "3" => "Opcion Eliminar usuario",
                "4" => "Opcion Bloquear usuario",
                _ => "No se ha seleccionado ninguna opcion"
            };
            WriteLine(menuSelected);
        }
    }
    else if(rolSelected == "2")
    {
        string menuAdminSelected = "";
        while (menuAdminSelected != "1" && menuAdminSelected != "2")
        {
            WriteLine("1 - Administracion de puestos, 2 - Administracion de usuarios");
            menuAdminSelected = ReadLine();
        }
    }

} while (rolSelected != "1" && rolSelected != "2");
WriteLine("Programa terminado");
