using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class RegexTest
    {
        public void Test()
        {
            var someTextwithEmail = "jsworkshoptext@gmail.com";

            // (?<uzytkownik>[A-z0-9\.]+)@(?<domena>[a-z]+)\.(?<globalna>[a-z]*)

            var match = Regex.Match(someTextwithEmail, "(?<uzytkownik>[A-z0-9\\.]+)@(?<domena>[a-z]+)\\.(?<globalna>[a-z]*)");

            if (match != null)
            {
                Console.WriteLine(match.Value);
                Console.WriteLine($"\tuzytkownik: {match.Groups["uzytkownik"]}");
                Console.WriteLine($"\tdomena: {match.Groups["domena"]}");
                Console.WriteLine($"\tglobalna: {match.Groups["globalna"]}");
            }
        }
    }
}
