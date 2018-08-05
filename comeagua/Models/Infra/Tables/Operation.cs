using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Operation
    {
        public int ID { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }

        public int WeekID { get; set; }
        public virtual Week Week { get; set; }
        public int PubID { get; set; }
    }
}