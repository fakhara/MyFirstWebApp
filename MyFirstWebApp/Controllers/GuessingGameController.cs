using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApp.Controllers
{
    public class GuessingGameController : Controller
    {
        // GET: GussingGame
        public ActionResult GuessingGame()
        {
            Models.GuessingGame guessingGame = new Models.GuessingGame();
            return View(guessingGame);
        }
        [HttpPost]
        public ActionResult GuessingGame(int guess)
        {
            Models.GuessingGame guessingGame = new Models.GuessingGame();
            //Initialize random Number variable
            if(guessingGame.Num == 0)
            {
                Random rnd = new Random();
                guessingGame.Num = rnd.Next(1, 100);
            }
            int num = guessingGame.Num;
            if (guess == num)
            {
                guessingGame.msg = "congratulation, You WIN.";
            }
            else if (guess != num)
            {
                guessingGame.msg = " You Lose  try again next time.";
            }
             List<string> guesses = new List<string>();
                if (Session["guessSession"] != null)
                {
                    guesses = (List<string>)Session["guessSession"];
                }
                guesses.Add(guess.ToString());
                Session["guessSession"] = guesses;
                return View(guessingGame);
            }
    }
 }
