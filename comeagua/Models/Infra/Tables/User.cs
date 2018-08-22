using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class User
    {
        public static object Identity { get; internal set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int ReviewID { get; set; }
        public string Password { get; set; }

        public virtual List<Photo> Photos { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}