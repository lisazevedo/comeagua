using comeagua.Infra.Tables;
using comeagua.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace comeagua.Controllers
{
    public class EventController : Controller
    {
        public ActionResult CreateEvent(Event evento)
        {
            var db = new ApplicationDbContext();
            db.Start();

            var pub = db.Pubs.Single(p => p.ID == evento.PubID);

            if(pub != null)
            {
                db.Events.Add(evento);
                db.SaveChanges();
            }
            
            return View(); 
        }

        public ActionResult FindEvent(string code)
        {
            var db = new ApplicationDbContext();

            db.Start();
            var evento = db.Events.Single(e => e.Code.Equals(code));

            if (User.Identity.IsAuthenticated && evento != null)
            {
                var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();

                evento.Guests.Add(MyUser);
                db.SaveChanges(); //usuario 
            }

            return View(); //evento nao existe ou user nao logado
        }
    }
}