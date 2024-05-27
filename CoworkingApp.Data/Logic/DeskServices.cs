using CoworkingApp.Data.Enums;
using CoworkingApp.Data.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CoworkingApp.Data.Logic
{
    public class DeskServices
    {
        private DeskData _data { get; set; }
        public DeskServices(DeskData deskData)
        {
            _data = deskData;
        }
        public (string, bool) ExecuteAction(AdminPuestos adminDeskAction)
        {
            var actionSelected = adminDeskAction switch
            {
                AdminPuestos.Crear => _data.CreateDesk(MethodsDesk.CreateDesk()),
                AdminPuestos.Editar => EditDesk(),
                AdminPuestos.Eliminar => RemoveDesk(),
                AdminPuestos.Bloquear => ("", false),
                _ => ("No se ha seleccionado ninguna opcion", false)
            };
            return actionSelected;
        }
        public (string, bool) EditDesk()
        {
            WriteLine("Escriba el numero del Desk");
            var deskFound = _data.FindDesk(ReadLine());
            if (deskFound == null)
            {
                WriteLine("No se encuentra el numero del Desk ingresado, favor de escribir correctamente el numero");
                deskFound = _data.FindDesk(ReadLine());
            }
            var editDesk = MethodsDesk.EditDesk(deskFound);
            var data = _data.EditDesk(editDesk);
            return (data.Item1, data.Item2);
        }
        public (string, bool) RemoveDesk()
        {
            (string, bool) dsk = ("", false);
            WriteLine("Escriba el numero del  Desk que desea borrar");
            var deskFound = _data.FindDesk(ReadLine());
            if(deskFound == null)
            {
                WriteLine("No se encuentra el numero del Desk ingresado, favor de escribir correctamente el numero");
                deskFound = _data.FindDesk(ReadLine());
            }
            WriteLine($"¿Esta seguro que desea eliminar el Desk {deskFound.Number}? SI/NO");
            string option = ReadLine();
            if (option.ToUpper() == "SI"|| option.ToUpper() == "S")
            {
                (dsk.Item1,dsk.Item2) = _data.DeleteDesk(deskFound.DeskId);
            }
            else
            {
                dsk = ("No se pudo eliminar el Desk, favor de intentar más tarde",false);
            }
            return dsk;
        }
        public (string, bool) BlockedDesk()
        {
            (string, bool) dsk = ("", false);
            WriteLine("Escriba el numero del  Desk que desea bloquear");
            var deskFound = _data.FindDesk(ReadLine());
            if (deskFound == null)
            {
                WriteLine("No se encuentra el numero del Desk ingresado, favor de escribir correctamente el numero");
                deskFound = _data.FindDesk(ReadLine());
            }
            deskFound.DeskStatus = Model.Enumerations.DeskStatus.Blocked;
            (dsk.Item1, dsk.Item2) = _data.EditDesk(deskFound);
            return dsk;

        }
    }
}
