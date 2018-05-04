using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class Person
    {

        
        public static List<Person> DBPeople = new List<Person>();
        [Required(ErrorMessage ="Person Name is Mandatory")]
        [Display(Name =" Person Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phone No is Mandatory")]
        [Display(Name ="Phone NO")]
        public string PhoneNO { get; set; }
        [Required(ErrorMessage ="City Name is Mandatory")]
        [Display(Name ="City")]
        public string City { get; set; }
        
    }
    
     


}