using comeagua.Models.Infra.Tables;
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

        //public int Tag_PubID { get; set; }
        [Index(IsUnique = true)]
        //public int AddressID { get; set; }
        //public virtual Address Address { get; set; }
        public int ReviewID { get; set; }

        //public virtual List<Address>Addresses  { get; set; }
        public virtual List<Photo> Photos { get; set; }
        public virtual List<Operation> Operations { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}