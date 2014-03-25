﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatimasSystem
{
    public class Event
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public override string ToString() 
        {
            return Year + "-" + Month + "-" + Day;
        }
    }
}
