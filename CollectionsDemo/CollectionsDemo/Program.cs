using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> firstNames = new List<string>( new string[] { "Brendan",
                "Charles",
                "Jesse",
                "Stephen",
                "Yesrat",
                "Zach"});

            //iterate through the indices like an array

            for( int i = 0; i < firstNames.Count; i++)
            {
                Console.WriteLine(firstNames[i]);
            }

            IEnumerable<String> differentVariable = firstNames;

            foreach( string name in firstNames)
            {
                Console.WriteLine(name);
            }


            //Queues are FIFO
            //we enqueue, then dequeue

            Queue<string> cities = new Queue<string>();

            cities.Enqueue("Boston");
            cities.Enqueue("Los Angeles");
            cities.Enqueue("Houston");

            foreach( string cityName in cities)
            {
                Console.WriteLine(cityName);
            }

            while( cities.Count > 0)
            {
                Console.WriteLine(cities.Dequeue());
            }

            Dictionary<string, int> cityPopulations = new Dictionary<string, int>();
            cityPopulations.Add("Boston", 684000);
            cityPopulations.Add("Los Angeles", 3960000);
            cityPopulations.Add("Houston", 2300000);

            foreach( string key in cityPopulations.Keys)
            {
                Console.WriteLine(key);
                int population = cityPopulations[key];

                Console.WriteLine(population);


            }

            Console.WriteLine(cityPopulations.ContainsKey("Boston"));
            cityPopulations.Remove("Boston");
            bool hasBoston = cityPopulations.ContainsKey("Boston");
            Console.WriteLine(hasBoston);

            bool hasExactlyTwoMillion = cityPopulations.ContainsValue(2000000);

            HashSet<string> distinctNames = new HashSet<string>();

            //distinctNames.Add("Alice");
            //distinctNames.Add("Bob");
            //distinctNames.Add("Cynthia");
            //distinctNames.Add("Dave");
            //distinctNames.Add("Elizabeth");
            //distinctNames.Add("Frank");

            //bool success = distinctNames.Add("Bob");
            //Console.WriteLine("We were able to add Bob again: " + success);


            Random rng = new Random();

            for( int i = 0; i < 500000; i++)
            {
                string toAdd = "";
                while(!distinctNames.Add(toAdd))
                {
                    toAdd += (char)('a' + rng.Next(0, 26));
                }
            }



            DateTime start = DateTime.Now;
            bool contains = distinctNames.Contains("bob");
            DateTime end = DateTime.Now;

            Console.WriteLine("bob in collection: " + contains);
            Console.WriteLine("total time: " + (end - start));

        }
    }
}
