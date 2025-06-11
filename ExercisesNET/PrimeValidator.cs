using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class PrimeValidator
    {
        public void Run()
        {
            var r = new Random();
            var tasks = new List<Task<bool>>();

            for (int i = 0; i < 50; i++)
            {
                //startujemy wątki
                int randNr = r.Next(10, 301);
                tasks.Add(Task.Run(() => IsPrimeNumber(randNr)));
            }

            //poczekać aż się watki skończa

            Task.WaitAll(tasks.ToArray());

            var count = tasks.Count(t => t.Result == true);
            Console.WriteLine($"Znaleziono {count} pierwszych."); // ile znależliśmy liczb pierwszych
        }

        public void RunWithLinq()
        {
            var r = new Random();

            var count = Enumerable.Range(0, 50)
                .AsParallel()
                .WithDegreeOfParallelism(4)
                .Select(i => r.Next(i))
                .Where(i => IsPrimeNumber(i))
                .Count();

            Console.WriteLine($"Znaleziono {count} pierwszych."); // ile znależliśmy liczb pierwszych
        }


        public bool IsPrimeNumber(int number)
        {
            if(number <= 1) return false;

            for (int i = 2; i < number; i++)
            {
                if(number % i == 0) return false;
            }

            return true;
        }
    }

}
