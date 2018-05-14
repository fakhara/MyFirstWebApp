using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class Person
    {

        static int idCount = 0;
        public static List<Person> DBPeople = new List<Person>();
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Person Name is Mandatory")]
        [StringLength(10)]
        [Display(Name =" Person Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phone No is Mandatory")]
        [StringLength(10)]
        [Display(Name ="Phone NO")]
        public string PhoneNO { get; set; }
        [Required(ErrorMessage ="City Name is Mandatory")]
        [StringLength(20)]
        [Display(Name ="City")]
        public string City { get; set; }
        public Person()
        {
            Id = idCount++;
            
        }
        public void personlist()
        {
            if (Id == 0)
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
                Person.DBPeople.Add(new Person { Name = "Farhat", PhoneNO = "0721237605", City = "Vitlanda" });
                Person.DBPeople.Add(new Person { Name = "Hufsa", PhoneNO = "0721456789", City = "Växjö" });
                Person.DBPeople.Add(new Person { Name = "Sana", PhoneNO = "0729876542", City = "Lamhult" });
                Person.DBPeople.Add(new Person { Name = "Amna", PhoneNO = "07232244567", City = "Vislanda" });
                Person.DBPeople.Add(new Person { Name = "Ayesha", PhoneNO = "0726643219", City = "Sandbro" });
            }
        }
    }
    
}