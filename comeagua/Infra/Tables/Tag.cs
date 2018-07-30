using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Tag
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual List<Pub> Pubs { get; set; }
    }
}