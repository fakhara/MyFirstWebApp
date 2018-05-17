using MyFirstWebApp.Models;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc; 

namespace MyFirstWebApp.Controllers
{
    public class PeopleController : Controller
    {
      
        //GET: People
        public ActionResult People()
        {
            Person me = new Person();
     
            return View(Person.DBPeople);
        }
        
    
         public ActionResult Search(string Name, string City)
         {
            if(!string.IsNullOrEmpty(Name))
            {
                return View("People", Person.DBPeople.Where(m => m.Name.Contains(Name)));
            }
            if(!string.IsNullOrEmpty(City))
            {
                return View("People", Person.DBPeople.Where(m => m.City.Contains(City)));
            }
            return View();
         }
        public ActionResult Sort(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "City_desc" : "City";
            var person = from m in Person.DBPeople select m;
            switch(sortOrder)
            {
                case "Name_desc":
                 person = person.OrderByDescending(m => m.Name);
                    break;
                case "City":
                  person= person.OrderBy(m => m.City);
                    break;
                case "City_desc":
                    person =person.OrderByDescending(m => m.City);
                    break;
                default:
                   person = person.OrderBy(m => m.Name);
                    break;
            }
            return View("People",person);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "Id,Name, PhoneNO,City")]Person person )
         {
            if(ModelState.IsValid)
            {

                Person.DBPeople.Add(person);
                return RedirectToAction("People");
            }
            return View(person);
           
           
         }
         public ActionResult Delete(int id)
         {
            Person person = Person.DBPeople.SingleOrDefault(m => m.Id == id);
            Person.DBPeople.Remove(person);
            return RedirectToAction("People");
         }
      

    }
}