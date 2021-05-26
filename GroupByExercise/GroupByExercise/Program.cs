using System;
using System.Collections.Generic;

namespace GroupByExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = new List<Person>();
            Random rng = new Random();
            for( int i = 0; i < 1000000; i++)
            {
                allPeople.Add(new Person(rng.Next(), (City)rng.Next(81)));
            }

            var groupedPeopleByCity = GroupByCity(allPeople);



        }

        private static Dictionary<City, List<Person>> GroupByCity(List<Person> allPeople)
        {
            throw new NotImplementedException();
        }
    }
}
