using comeagua.Infra.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comeagua.Models.Infra.DBO
{
    public static class DboEvent
    {
        public static bool CreateEvent(Event evento)
        {
            var db = new ApplicationDbContext();

            var Query = (from ev in db.Events where ev.Hour == evento.Hour select ev);

            if (Query is null)
            {
                db.SaveChanges();
                return true; //evento criado
            }
            return false; //evento ja existente
        }

        public static void DeleteEvent(Event evento)
        {

        }

        public static bool UpdateEvent(Event evento)
        {
            var db = new ApplicationDbContext();

            return true;
        }
    }
}