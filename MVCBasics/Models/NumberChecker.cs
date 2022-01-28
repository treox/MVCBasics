using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class NumberChecker
    {
        public static string message;
        public static int numberOfGuesses;

        public static string CheckNumber(int number, string generatedNumberStr)
        {
            if(generatedNumberStr != null)
            {
                int generatedNumber = int.Parse(generatedNumberStr);

                if(number < generatedNumber)
                {
                    message = "Numret är mindre än det genererade numret!";
                }
                else if(number > generatedNumber)
                {
                    message = "Numret är större än det genererade numret!";
                }
                else
                {
                    message = "Gratulerar! Dugissade rätt nummer! Se \"High scores\" för ditt resultat. Det genererade numret är: " + generatedNumber;
                }

                return message + " Du gissade på: " + number;
            }
            else
            {
                return "Ingen aktiv session! Aktivera en session genom att navigera till \"Aktivera session för Guessing Game\".";
            }
        }

        public static int CountGuesses(string messageInput, int guesses)
        {
            if(!messageInput.Contains("Gratulerar! Dugissade rätt nummer!") && messageInput != "Ingen aktiv session! Aktivera en session genom att navigera till \"Aktivera session för Guessing Game\".")
            {
                numberOfGuesses++;
            }
            else
            {
                numberOfGuesses = guesses;
            }

            return numberOfGuesses;
        } 
    }
}
