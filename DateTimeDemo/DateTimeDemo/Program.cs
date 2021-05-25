using System;

namespace DateTimeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime today = new DateTime();

            //today = today.AddYears(1000);

            today = DateTime.Now;

            DateTime birthday = new DateTime(1983, 7, 25);

            TimeSpan age = today - birthday;

            TimeSpan hourAndAHalf = new TimeSpan(1, 30, 0);

            DateTime hourAndAHalfInTheFuture = DateTime.Now + hourAndAHalf;


            //we're going to print day of week starting at birthday going every 6 years (kinda)
            TimeSpan sixYears = new TimeSpan(365 * 6 + 1, 0, 0, 0, 0);


            for( DateTime currentDate = birthday; currentDate <= DateTime.Now; currentDate += sixYears)
            {
                Console.WriteLine(currentDate);
                Console.WriteLine(currentDate.DayOfWeek);
                Console.WriteLine(currentDate.DayOfYear);
            }

            //input from the user
            Console.Write("Please enter a date (yyyy, M/dd");
            string userInput = Console.ReadLine();

            DateTime userDate = DateTime.ParseExact(userInput, "yyyy, M/dd", null);

            Console.WriteLine(userDate.ToString("yy-MMM-dd"));

        }
    }
}
