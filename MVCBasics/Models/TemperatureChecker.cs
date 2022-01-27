using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class TemperatureChecker
    {
        public static string CheckTemperature(int temperature, string chosenUnit)
        {
            string message;

            if (chosenUnit == "celcius")
            {
                if(temperature >= 38)
                {
                    message = "Temperatur: " + temperature + "°C. Du har feber!";
                }
                else if(temperature < 35)
                {
                    message = "Temperatur: " + temperature + "°C. Du har hypotermi!";
                }
                else
                {
                    message = "Temperatur: " + temperature + "°C. Du har inte feber eller hypotermi!";
                }
            }
            else
            {
                if (temperature >= 99)
                {
                    message = "Temperatur: " + temperature + "°F. Du har feber!";
                }
                else if(temperature < 95)
                {
                    message = "Temperatur: " + temperature + "°F. Du har hypotermi!";
                }
                else
                {
                    message = "Temperatur: " + temperature + "°F. Du har inte feber eller hypotermi!";
                }
            }

            return message;
        }
    }
}
