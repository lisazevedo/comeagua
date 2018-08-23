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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
                ViewBag.ImageProfile = MyUser.Image;
            }
            //ViewBag.Log = Session["UserLOGIN"] == null ? "Nao logado" : Session["UserLOGIN"].ToString();
            // Para deslogar coloca Sesson.Abort ou 
            // Session.Abandon();

            return View();
        }

     
        public ActionResult SearchPage(String busca)
        {
            ViewBag.Busca = busca;
            //Session["UserLOGIN"] = "Lis";
            return View();
        }

        public ActionResult CreateEvent(CreateEventViewModel model, string code)
        {
            var db = new ApplicationDbContext();
            db.Start();

            var pub = db.Pubs.Where(p => p.Name == model.BarName).FirstOrDefault();


            //var pub = db.Pubs.Where(p => p.ID == evento.PubID).FirstOrDefault();

            if (pub != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();

                    var evento = new Event { PubID = pub.ID, Hour = model.Hour, Date = model.DateEvent, Code = code, AspNetUserID = MyUser.Id };
                    db.Events.Add(evento);
                    db.SaveChanges(); //usuario 
                    return RedirectToAction("Index", "Home");
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
        public ActionResult Evento(String nome_bar, String data, String time)
        {
            if (User.Identity.IsAuthenticated)
            {
                var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
                ViewBag.ImageProfile = MyUser.Image;

                var codigos = new List<int>();
                Random random = new Random();
                var codigoaleatorio = random.Next(0, 1000);
                if (codigos.Contains(codigoaleatorio))
                {
                    codigoaleatorio = random.Next(0, 1000);
                    ViewBag.CodigoEvento = codigoaleatorio;

                }
                else
                {
                    ViewBag.CodigoEvento = codigoaleatorio;
                }
            }
            return View();
        }
      
    }
}