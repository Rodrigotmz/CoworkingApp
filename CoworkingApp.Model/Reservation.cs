using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingApp.Model
{
    public class Reservation
    {
        public Guid ReservationId { get; set; } = Guid.NewGuid();
        public DateTime ReservationDate { get; set; }
        public Guid DeskId { get; set; }
        public Guid UserId { get; set; }
    }
}
