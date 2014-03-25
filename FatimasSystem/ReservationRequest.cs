using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatimasSystem
{
    public class ReservationRequest
    {
        public Event Ev { get; set; }
        public int Department { get; set; }

        public override string ToString()
        {
            return Ev.ToString() + " Departamento: " + Department;
        }
    }
}
