
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Pub
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rate { get; set; }
        public string ImagePath { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}