using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MVCBasics.Controllers
{
    public class GameController : Controller
    {
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }

        public IActionResult GuessingGame()
        {
            string playerName = HttpContext.Session.GetString("Name");
            ViewBag.WelcomeMessage = "Välkommen " + playerName + "!";
            ViewBag.Guesses = NumberChecker.numberOfGuesses;
            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(int guessInput)
        {
            if (ModelState.IsValid)
            {
                string numberFromSession = HttpContext.Session.GetString("Number");

                string message = NumberChecker.CheckNumber(guessInput, numberFromSession);

                int inputGuesses = NumberChecker.numberOfGuesses;
                int guesses = NumberChecker.CountGuesses(message, inputGuesses);

                string playerName = HttpContext.Session.GetString("Name");
                ViewBag.WelcomeMessage = "Välkommen " + playerName + "!";

                ViewBag.NumberMessage = message;
                ViewBag.Guesses = guesses;

                if(message.Contains("Gratulerar! Dugissade rätt nummer!"))
                {
                    string tempName = HttpContext.Session.GetString("Name");
                    string strGuesses = guesses.ToString();
                    Set(tempName, strGuesses, 20);
                    HttpContext.Session.Clear();
                    NumberChecker.numberOfGuesses = 0;
                }

                return View();
            }
            else
            {
                ViewBag.NumberMessage = "Fel: Mata in ett giltigt nummer!";

                return View();
            }
        }

        public IActionResult HighScores()
        {
            string[] allKeys = Request.Cookies.Keys.ToArray();
            string[] allValues = new string[0];

            for(int v = 0; v < allKeys.Length; v++)
            {
                Array.Resize(ref allValues, allValues.Length + 1);
                allValues[v] = Request.Cookies[allKeys[v]];
            }

            for (int c = 2; c < allKeys.Length; c++)
            {
                ViewBag.CookieValues += allKeys[c] + " " + allValues[c] + ",";
            }
            return View();
        }

        public IActionResult SetSessionForGame()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetSessionForGame(string name)
        {
            if (ModelState.IsValid && name != null)
            {
                Random rnd = new Random();
                int generatedNumber = rnd.Next(1, 101);

                HttpContext.Session.SetString("Number", generatedNumber.ToString());
                HttpContext.Session.SetString("Name", name);

                ViewBag.Number = generatedNumber;
                ViewBag.SessionMessage = "Din sessionen är aktiverad!";

                return View();
            }
            else
            {
                ViewBag.SessionMessage = "Skriv in ett giltigt namn!";
                return View();
            }
        }
    }
}
