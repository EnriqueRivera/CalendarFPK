using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatimasSystem
{
    public class Guest
    {
        public string IdGuest { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SLastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public override bool Equals(object obj)
        {
            return ((Guest)obj).IdGuest.Equals(IdGuest);
        }
    }
}
