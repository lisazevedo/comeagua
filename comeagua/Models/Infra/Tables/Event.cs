using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Private { get; set; }

        public int PubID { get; set; }
        public int UserID { get; set; }

        public virtual List<Guest> Guests { get; set; }
    }
}