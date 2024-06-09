using CoworkingApp.Data.Enums;
using CoworkingApp.Model;
using System.Globalization;
using static System.Console;
using static CoworkingApp.Data.Methods.MethodsDesk;
using CoworkingApp.Data.Methods;

namespace CoworkingApp.Data.Logic
{
    public class UserServices
    {
        private UserData _data { get; set; }
        private DeskData _deskData { get; set; }
        private ReservationData reservationData { get; set; }
        private Response response { get; set; }

        public UserServices(UserData dataServices, DeskData deskData)
        {
            _data = dataServices;
            _deskData = deskData;
            reservationData = new ReservationData();
            response = new Response() { 
                message = "Opcion no encontrada"
            };
        }
        public Response ExecuteAction(MenuUser menuUser, User user)
        {
            response = menuUser switch
            {
                MenuUser.ReservarPuesto => ReserveDesk(user),
                MenuUser.CancelarReserva => CancelReserv(user),
                MenuUser.VerHistorialReserva => HistoryUser(user),
                MenuUser.CambiarPassword => ChangePassword(user),
                _ => response
            };
            return response;
        }
        public Response ReserveDesk(User user)
        {
            string deskReservation = string.Empty;
            var dateSelected = new DateTime();
            var deskList = _deskData.GetAvaibleDeskList();
            WriteLine("Puestos disponibles");
            foreach (var item in deskList)
            {
                WriteLine($"Puesto: {item.Number} - {item.Description}");
            }
            WriteLine("Ingrese el numero del puesto a reservar");
            var deskFound = _deskData.FindDesk(ReadLine());
            while(deskFound == null)
            {
                WriteLine("No se encontro el puesto ingresado, favor de ingresa un numero de puesto correcto");
                deskFound = _deskData.FindDesk(ReadLine());
            }
            while(dateSelected.Year == 0001)
            {
                WriteLine("Ingrese la fecha de reserva en formato (dd-mm-yyyy)");
                DateTime.TryParseExact(ReadLine(), "dd-MM-yyyy", null, DateTimeStyles.None, out dateSelected);
            }
            reservationData.CreateReservation(Createreservation(user.UserId,deskFound.DeskId, dateSelected));

            return response;
        }
        public Response CancelReserv(User user)
        {
            WriteLine("Estas son las resevaciones disponibles");
            var userReservations = reservationData.GetReservationByUser(user.UserId).ToList();
            var deskUserList = _deskData.GetAvaibleDeskList().ToList();
            int indexResevation = 1;
            foreach (var item in userReservations)
            {
                WriteLine($"{indexResevation} - {deskUserList.FirstOrDefault(p => p.DeskId == item.DeskId).Number} - {item.ReservationDate.ToString("dd-MM-yyyy")}");
                indexResevation++;
            }
            WriteLine("Ingrese el numero del puesto");
            var indexReservationSelected = int.Parse(ReadLine());
            while (indexReservationSelected < 1 || indexReservationSelected > indexResevation)
            {
                WriteLine("Ingrese el numero de la reservacion que desea eliminar:");
                indexReservationSelected = int.Parse(ReadLine());
            }
            var reservationToDelete = userReservations[indexReservationSelected];
            reservationData.CancelReservation(reservationToDelete.ReservationId);
            WriteLine();
            return response;
        }
        public Response HistoryUser(User user)
        {
            var historyReservationUser = reservationData.GetReservationsHistoryByUser(user.UserId).ToList();
            var deskHistoryList = _deskData.GetAllDeskList().ToList();
            WriteLine("Tus reservas");
            foreach (var item in historyReservationUser)
            {
                WriteLine($"{deskHistoryList.FirstOrDefault(p => p.DeskId == item.DeskId).Number} - {item.ReservationDate.ToString("dd-MM-yyyy")} - {(item.ReservationDate > DateTime.Now.Date ? "(Activa)": "(Inactivo)")}");
            }
            return response;
        }
        public Response ChangePassword(User user)
        {
            var editData = MethodsUser.ChangePassword(user);
            response = _data.EditUser(editData);
            return response;
        }
    }
}
