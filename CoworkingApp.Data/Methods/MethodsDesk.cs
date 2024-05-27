using CoworkingApp.Model;
using CoworkingApp.Model.Enumerations;
using System.Xml;
using static System.Console;

namespace CoworkingApp.Data.Methods
{
    public class MethodsDesk
    {
        public static Desk CreateDesk()
        {
            Desk newDesk = new Desk();
            try
            {
                WriteLine("Ingrese por favor el numero, ejemplo: A-001 ");
                newDesk.Number = ReadLine();
                WriteLine("Por favor ingrese una descripcion");
                newDesk.Description = ReadLine();
                return newDesk;
            }
            catch { return newDesk; }
        }
        public static Desk EditDesk(Desk editDesk)
        {
            try
            {
                WriteLine("Ingrese el nuevo numero, ejemplo: A-002");
                editDesk.Number = ReadLine();
                WriteLine("Por favor ingrese una nueva descripcion");
                string newDescription = ReadLine();
                WriteLine("Ingrese estado de puesto, 1= activo, 2 = inactivo, 3 = bloqueado");
                string status = ReadLine();
                while (status != null && status != "1" && status != "2" && status != "3")
                {
                    WriteLine("El número ingresado para el estado del puesto no es valido, de escoger entre 1= activo, 2 = inactivo, 3 = bloqueado");
                    status = ReadLine();
                }
                editDesk.DeskStatus = Enum.Parse<DeskStatus>(status);
                editDesk.Description = newDescription == "" || newDescription == null ? editDesk.Description : newDescription;
                return editDesk;
            }
            catch { return editDesk; }
        }
    }
}
