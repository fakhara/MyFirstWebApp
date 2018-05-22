using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            PersonPartialVM vm = new PersonPartialVM(Person.DBPeople);
            
            return View(vm);
        }
        public ActionResult PartIndex()
        {
            PersonPartialVM vm = new PersonPartialVM(Person.DBPeople);
            return View(vm);
        }
            public ActionResult PartPerson(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(x => x.Id == id);
            if (person == null)
            {
                //error handelning
            }
            return PartialView("_PartPerson");
        }
    }
}