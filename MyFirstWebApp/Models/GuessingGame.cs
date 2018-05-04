using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstWebApp.Models
{
    public class GuessingGame
    {
        static int idCount = 0;
        public int Id { get; set; }
        public int Num { get; set; }
        public string msg { get; set; }

        public GuessingGame()
        {
            Id = idCount++;
        }
    }
}