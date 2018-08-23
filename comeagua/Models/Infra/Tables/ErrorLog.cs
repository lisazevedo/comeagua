using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables
{
    public class ErrorLog
    {
        public int ID { get; set; }
        public string Error { get; set; }
        public DateTime Date { get; set; }
        
    }
}