using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class Photo
    {
        public int ID { get; set; }
        public byte[] Image { get; set; }

        public int PubID { get; set; }
    }
}