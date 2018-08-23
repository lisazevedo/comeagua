using comeagua.Infra.Tables;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using comeagua.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        //public static void UpdateEvent(Event evento, ApplicationUser user)
        //{
        //    var db = new ApplicationDbContext();
        //    db.Start();

        //    evento.Guests.Add(user);

        //    db.SaveChanges();
        //}

        public static List<Event> GetEvents(int idPub)
        {
            var db = new ApplicationDbContext();
            db.Start();

            var Query = (from e in db.Events where e.PubID == idPub && e.Date == DateTime.Now select e).ToList();

            if (Query != null) return Query;
            return new List<Event>();
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

        //public static bool FindEvent(string code)
        //{
        //    var db = new ApplicationDbContext();

        //    db.Start();
        //    var evento = db.Events.Single(e => e.Code.Equals(code));

        //    if (User.Identity.IsAuthenticated && evento != null)
        //    {
        //        var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //        var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
         
        //        evento.Guests.Add(MyUser);
        //        db.SaveChanges();

        //        return true;
        //    }
            
        //    return false; //evento nao existe ou user nao logado
        //}

    }
}