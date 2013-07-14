using Application.Manager.Contract;
using Application.Manager.Contract.ContactModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IContactManager _contactManager;
        //public HomeController(IContactManager contactManager)
        //{
        //    _contactManager = contactManager;
        //}

        public IContactManager ContactManager { get; set; }

        public ActionResult Index()
        {
            //ContactManager.FindProfiles(0, 10);
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
