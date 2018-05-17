using MyFirstWebApp.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            Person person = new Person();
             return View(Person.DBPeople);
        }
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var person = Person.DBPeople.Where(m => searchTerm == null|| m.Name.StartsWith(searchTerm)).ToPagedList(page,10);
           
            if(Request.IsAjaxRequest())
            {
                return PartialView("_listPerson", person);
            }
            return View(person);
        }
       
    
        public ActionResult ListItemPerson(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);

            return PartialView("_listPerson", person);
        }
        public ActionResult EditPerson(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);

            return PartialView("_EditSave", person);
        }
        public ActionResult EditSave(Person person)
        {
           Person OldPerson = Person.DBPeople.SingleOrDefault(m => m.Id == person.Id);
            OldPerson.Name = person.Name;
            OldPerson.PhoneNO = person.PhoneNO;
            OldPerson.City = person.City;

            return PartialView("_listPerson", OldPerson);
        }
        public ActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                Person.DBPeople.Add(person);
                return PartialView("_listPerson", person);
               // return RedirectToAction("Index");
            }
            return new HttpStatusCodeResult(400);
            // return Content("");
        }
        public ActionResult Delete(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);
            Person.DBPeople.Remove(person);
            return Content("");

            //return RedirectToAction("Index");

        }
    }
}