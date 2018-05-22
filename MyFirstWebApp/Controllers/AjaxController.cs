using MyFirstWebApp.Models;
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
            }
            return new HttpStatusCodeResult(400);
           
        }
        public ActionResult Delete(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);
            Person.DBPeople.Remove(person);
            return Content("");
        }
        
        public ActionResult Search(string filterName, string currentFilter,int? page)
        {
            var personse = from m in Person.DBPeople select m;
            if (!string.IsNullOrEmpty(filterName))
            {
                personse = personse.Where(i => i.Name.ToLower().Contains(filterName) || i.City.ToLower().Contains(filterName));
            }
                return PartialView("_SearchPersonList", personse.ToList());
        }
    }
}
