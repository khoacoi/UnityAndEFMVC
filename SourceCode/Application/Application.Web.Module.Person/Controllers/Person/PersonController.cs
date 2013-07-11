using Application.Manager.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Web.Module.Person.Controllers.Person
{
    public class PersonController : Controller
    {
        public PersonController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }
        private readonly IContactManager _contactManager;

        //
        // GET: /Person/

        public ActionResult Index()
        {
            var list = _contactManager.FindProfiles(0, 10);
            var personTest = new ABC() { Name = "employee", Age = 23 };
            
            return View(personTest);
        }

    }

    public class ABC
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
