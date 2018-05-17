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
       
       /* public ViewResult Index( string sortOrder,string currentFilter,string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var person = from s in Person.DBPeople
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                person = person.Where(s => s.Name.Contains(searchString)
                                       || s.City.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    person = person.OrderByDescending(s => s.Name);
                    break;
                case "City":
                    person = person.OrderBy(s => s.City);
                    break;
                case "city_desc":
                    person = person.OrderByDescending(s => s.City);
                    break;
                default:
                    person = person.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View("Index",person.ToPagedList(pageNumber, pageSize));
        }*/
    
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