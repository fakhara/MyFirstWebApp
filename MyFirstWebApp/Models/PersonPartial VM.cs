using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class PersonPartialVM
    {
        public List<Person> persons;
        public PersonPartialVM(List<Person> persons)
        {
            this.persons = persons;
            persons.Add(new Person() { Name = "sadia", PhoneNO = "0721237605", City = "Växjö" });
            persons.Add(new Person() { Name = "Hina", PhoneNO = "0723456543", City = "Vitlanda" });
            persons.Add(new Person() { Name = "Sahbana", PhoneNO = "0721765789", City = "Stockholm" });
            persons.Add(new Person() { Name = "faiza", PhoneNO = "0721237605", City = "Malmo" });
            persons.Add(new Person() { Name = "Nabeha", PhoneNO = "072122775", City = "Älmult" });
            persons.Add(new Person() { Name = "Fatima", PhoneNO = "0721278984", City = "Växjö" });
            persons.Add(new Person() { Name = "Aleha", PhoneNO = "0721237605", City = "Vitlanda" });
            persons.Add(new Person() { Name = "Eman", PhoneNO = "0729876542", City = "Lamhult" });

        }
    }
}