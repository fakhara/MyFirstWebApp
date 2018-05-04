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
        Person person = new Person();

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
        
       public ActionResult index(string searching)
        {
            List<Person> PeopleList = new List<Person>();
            if (searching == "Name")
            {
                return View(PeopleList.Where(m => m.Name.Contains(searching) || searching == null).ToList());

            }
            else
            {
                return View(PeopleList.Where(m => m.City.Contains(searching )|| searching == null).ToList());
            }
        }
        [HttpGet]
        public ActionResult AddPeople()
        {
            return View();
        }
        
        [HttpPost]
         public ActionResult AddPeople(string Name, string PhoneNO, string City )
         {
            Person preson = new Person();
            preson.Name = Name;
            preson.PhoneNO = PhoneNO;
            preson.City = City;
            Person.DBPeople.Add(person);
            //return View("People",Person.DBPeople);
            return RedirectToAction("AddPeople");
            
         }
        [HttpPost]
        public ActionResult AddPeople([Bind(Include = "Name,PhoneNo,City")]Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddPeople");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Remove(String Name)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Remove(String Name, List<Person> PeopleList)
        {
           try
            {
                return RedirectToAction("People");
            }
            catch
            {
                return View();
            }
        }

    }
}