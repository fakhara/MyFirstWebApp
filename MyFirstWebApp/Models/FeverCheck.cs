using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class FeverCheck
    {
        public int Temp { get; set; }
        public string msg { get; set; }

        public FeverCheck()
        {
            Temp = 95;
        }
        
    }
}