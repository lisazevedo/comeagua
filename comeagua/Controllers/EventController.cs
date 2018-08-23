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
        public ActionResult CreateEvent(CreateEventViewModel model, string code)
        {
            var db = new ApplicationDbContext();
            db.Start();

            var pub = db.Pubs.Where(p => p.Name == model.BarName).FirstOrDefault();

            if (pub != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();

                    var evento = new Event { PubID = pub.ID, Hour = model.Hour, Date = model.DateEvent, Code = code, AspNetUserID = MyUser.Id };
                    db.Events.Add(evento);
                    db.SaveChanges(); //usuario 
                }
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

                evento.AspNetUsers.Add(MyUser);
                db.SaveChanges(); //usuario 
            }

            return View(); //evento nao existe ou user nao logado
        }
    }
}