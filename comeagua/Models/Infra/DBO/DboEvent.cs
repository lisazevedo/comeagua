using comeagua.Infra.Tables;
using Microsoft.AspNet.Identity.EntityFramework;
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
            db.Start();
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


        public static void UpdateEvent(Event evento, ApplicationUser user)
        {
            var db = new ApplicationDbContext();
            db.Start();

            evento.Guests.Add(user);

            db.SaveChanges();
        }

        public static List<Event> ListEvents(string FirstNameCreator, string LastNameCreator)
        {
            var db = new ApplicationDbContext();

            db.Start();

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var EventCreator = manager.Users.Single(ec => ec.FirstName.Equals(FirstNameCreator) && ec.LastName.Equals(LastNameCreator));

            List<Event> eventos = (from ev in db.Events where (ev.AspNetUserID.Equals(EventCreator.Id)) select ev).ToList();

            return eventos;
        }

    }
}