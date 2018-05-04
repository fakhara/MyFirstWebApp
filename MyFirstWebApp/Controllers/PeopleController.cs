using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace MyFirstWebApp.Controllers
{
    public class PeopleController : Controller
    {
      
        //GET: People
        public ActionResult People()
        {

            Person.DBPeople.Add(new Person { Name = "Fakhara", PhoneNO = "0721237605", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Sadiqa", PhoneNO = "0721567625", City = "Malmo" });
            Person.DBPeople.Add(new Person { Name = "Hina", PhoneNO = "072122775", City = "Älmult" });
            Person.DBPeople.Add(new Person { Name = "Maryyram", PhoneNO = "0721278984", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Erum", PhoneNO = "0721237605", City = "Vitlanda" });
            Person.DBPeople.Add(new Person { Name = "Rafia", PhoneNO = "0721456789", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Wajeeha", PhoneNO = "0729876542", City = "Lamhult" });
            Person.DBPeople.Add(new Person { Name = "Huma", PhoneNO = "07232244567", City = "Vislanda" });
            Person.DBPeople.Add(new Person { Name = "Nazish", PhoneNO = "0726643219", City = "Sandbro" });
            Person.DBPeople.Add(new Person { Name = "Adeela", PhoneNO = "0721237605", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Farzana", PhoneNO = "0721237605", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Sadia", PhoneNO = "0721567625", City = "Malmo" });
            Person.DBPeople.Add(new Person { Name = "Hina", PhoneNO = "072122775", City = "Älmult" });
            Person.DBPeople.Add(new Person { Name = "Misbah", PhoneNO = "0721278984", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Amara", PhoneNO = "0721237605", City = "Vitlanda" });
            Person.DBPeople.Add(new Person { Name = "Rahat", PhoneNO = "0721456789", City = "Växjö" });
            Person.DBPeople.Add(new Person { Name = "Nabeeha", PhoneNO = "0729876542", City = "Lamhult" });
            Person.DBPeople.Add(new Person { Name = "Humna", PhoneNO = "07232244567", City = "Vislanda" });
            Person.DBPeople.Add(new Person { Name = "Naila", PhoneNO = "0726643219", City = "Sandbro" });
            Person.DBPeople.Add(new Person { Name = "Amna", PhoneNO = "0721237605", City = "Växjö" });
            return View(Person.DBPeople);
        }
        
         public ActionResult Search(string searching,string sorting)
         {
            return View("People", Person.DBPeople.Where(m => m.Name.StartsWith(searching)|| m.City == searching).ToList());
            
         }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
         public ActionResult Create(string Name, string PhoneNO,string City )
         {
            Person person = new Person();
            person.Name = Name;
            person.PhoneNO = PhoneNO;
            person.City = City;
            Person.DBPeople.Add(person);
            return View("Create",Person.DBPeople);
           // return RedirectToAction("People");
            
         }
        /*[HttpPost]
        public ActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                Person.DBPeople.Add(person);
                return RedirectToAction("People");
            }
            return View(person);

        }*/

        [HttpGet]
        public ActionResult Remove(String Name)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Remove(String Name, List<Person> DBPeople)
        {
           try
            {
                return RedirectToAction("People");
            }
            catch
            {
                return View("Remove");
            }
        }

    }
}