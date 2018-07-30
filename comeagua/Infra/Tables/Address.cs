using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Address
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int y { get; set; }

        // [ForeignKey("Pub")]
        //public int PubID { get; set; }
        public virtual Pub Pub { get; set; }
    }
}