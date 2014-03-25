using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatimasSystem
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int IdDepartment { get; set; }
        public string IdGuest { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int NumKids { get; set; }
        public int NumAdult { get; set; }
        public string Comment { get; set; }
    }
}
