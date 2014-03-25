using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FatimasSystem
{
    class FromToDate
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private int _department;

        public FromToDate(DateTime fromDate, DateTime toDate, int department)
        {
            _fromDate = fromDate;
            _toDate = toDate;
            _department = department;
        }

        public int Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }

        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }
    }
}
