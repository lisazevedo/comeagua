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
        //public ActionResult SearchPage()
        //{
        //    return View();
        //}
        public ActionResult SearchPage(String busca)
        {
            ViewBag.Busca = busca;
            //Session["UserLOGIN"] = "Lis";
            return View();
        }
     
    }
}