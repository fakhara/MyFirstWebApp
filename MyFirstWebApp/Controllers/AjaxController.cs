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
            Person me = new Person();
            me.personlist();
            return View(Person.DBPeople);
        }
       
       /* public ActionResult Index(string searchBy,string search, int? page)
        {
            if (searchBy == "Name")
            {
                return View("People", Person.DBPeople.Where(m => m.Name == search || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
            else
            {
                return View("People", Person.DBPeople.Where(m => m.City == search|| search == null).ToList().ToPagedList(page ?? 1,10));
            }
         }*/
        public ActionResult ListItemPerson(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);

            return PartialView("_listPerson", person);
        }
        public ActionResult DetailPerson(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);

            return PartialView("_DetailPerson", person);
        }
        public ActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                Person.DBPeople.Add(person);
                return PartialView("_listPerson", person);
            }
            return new HttpStatusCodeResult(400);
            // return Content("");
        }
        public ActionResult Delete(int id)
        {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);
            Person.DBPeople.Remove(person);
            return RedirectToAction("Index");

        }
    }
}