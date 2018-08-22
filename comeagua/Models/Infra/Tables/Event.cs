using comeagua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Event
    {
        public int ID { get; set; }
        //public string Name { get; set; }
        //public bool Private { get; set; }

        public int PubID { get; set; }
        public string AspNetUserID { get; set; }
        public DateTime Hour { get; set; }
        public DateTime Date { get; set; }

        public virtual List<ApplicationUser> Guests { get; set; }
    }
}