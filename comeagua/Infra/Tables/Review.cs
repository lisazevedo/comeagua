using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Review
    {
        public int ID { get; set; }
        public string Commentary { get; set; }
        public int Raiting { get; set; }

        public int UserID { get; set; }
        public int PubID { get; set; }
    }
}