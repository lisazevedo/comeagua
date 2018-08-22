using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Guest
    {
        public int ID { get; set; }

        public int EventID { get; set; }

        public string AspNetUserID { get; set; }
    }
}