using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class DoctorController : Controller
    {

        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(int temperatureInput, string unit)
        {
            if (ModelState.IsValid)
            {
                string temperatureMessage = TemperatureChecker.CheckTemperature(temperatureInput, unit);

                if (temperatureMessage == null)
                    return NotFound();
                else
                    ViewBag.Message = temperatureMessage;

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
