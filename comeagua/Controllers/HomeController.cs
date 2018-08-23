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
        static string codigoale;
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

        public ActionResult EnterEvent()
        {
            return View();
        }


        public ActionResult SearchPage(String busca)
        {
            ViewBag.Busca = busca;
            //Session["UserLOGIN"] = "Lis";
            return View();
        }

        public ActionResult CreateEvent(CreateEventViewModel model)
        {
            var db = new ApplicationDbContext();
            db.Start();
    
            var pub = (from p in db.Pubs where p.Name.Contains(model.BarName) select p).First();

            if (pub != null)
            {
                if (User.Identity.IsAuthenticated)
                {

                    //model.DateEvent.Hour = model.Hour;
                    var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();

                    var evento = new Event { PubID = pub.ID, Hour = model.Hour, Date = model.DateEvent, Code = codigoale, AspNetUserID = MyUser.Id };
                    db.Events.Add(evento);
                    db.SaveChanges(); //usuario 
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult FindEvent(CodeEventViewModel model)
        {
            var db = new ApplicationDbContext();

            db.Start();
            var evento = db.Events.Single(e => e.Code.Equals(model.codeEvent));

            if (User.Identity.IsAuthenticated && evento != null)
            {
                var maneger = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var MyUser = maneger.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();

                evento.AspNetUsers.Add(MyUser);
                db.SaveChanges(); //usuario 
            }

            return RedirectToAction("Index", "Home"); //evento nao existe ou user nao logado
        }
        public ActionResult Evento(CreateEventViewModel model)
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
                    codigoale = codigoaleatorio.ToString();
                }
                else
                {
                    ViewBag.CodigoEvento = codigoaleatorio;
                    codigoale = codigoaleatorio.ToString();
                }


                return View();
            }
           
            return View();

        }
    }
}