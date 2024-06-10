using CoworkingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingApp.Data
{
    public class ReservationData
    {
        private JsonManager<Reservation> jsonManager {  get; set; }
        public ReservationData()
        {
            jsonManager = new JsonManager<Reservation>();
        }
        public (string, bool) CreateReservation(Reservation reserv)
        {
            var reservCollection = jsonManager.GetCollection();
            reservCollection.Add(reserv);
            jsonManager.SaveCollection(reservCollection);
            return ("Se creo la reservacion con exito", true);
        }
        public (string, bool) CancelReservation(Guid reservationId)
        {
            var reservCollection = jsonManager.GetCollection();
            var indexReservation = reservCollection.FindIndex(p => p.ReservationId == reservationId);
            reservCollection.RemoveAt(indexReservation);
            jsonManager.SaveCollection(reservCollection);
            return ("Se creo la reservacion con exito", true);
        }
        public IEnumerable<Reservation> GetReservationByUser(Guid userId)
        {
            var reservCollection = jsonManager.GetCollection();
            jsonManager.SaveCollection(reservCollection);
            return reservCollection.Where(p => p.UserId == userId && p.ReservationDate.Date >= DateTime.Now.Date);
        }
        public IEnumerable<Reservation> GetReservationsHistoryByUser(Guid userId)
        {
            var reservCollection = jsonManager.GetCollection();
            jsonManager.SaveCollection(reservCollection);
            return reservCollection.Where(p => p.UserId == userId);
        }
    }
    
}
