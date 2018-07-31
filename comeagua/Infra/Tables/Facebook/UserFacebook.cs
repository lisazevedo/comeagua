using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Infra.Tables.Facebook
{
    public class UserFacebook
    {
        //public int AppID { get; set; }
        public string id { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public Picture picture { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
    }
}