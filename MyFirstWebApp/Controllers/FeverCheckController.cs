using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class FeverCheckController : Controller
    {
        // GET: FeverCheck
        [HttpGet]
        public ActionResult FeverCheck()
        {
            Models.FeverCheck feverCheck = new Models.FeverCheck();
            return View(feverCheck);
        }
        [HttpPost]
        public ActionResult FeverCheck(int temp)
        {
            Models.FeverCheck feverCheck = new Models.FeverCheck();
            feverCheck.Temp = temp;
            if (temp > 95)
                feverCheck.msg = "you have high fever.";
            else if (temp == 95)
                feverCheck.msg = "you have not fever.";
           else if (temp < 95)
                feverCheck.msg = "You have a too low temperature.";
            return View(feverCheck);
        }
    }
}