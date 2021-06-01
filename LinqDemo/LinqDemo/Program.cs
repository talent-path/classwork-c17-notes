using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Java

            //.filter()     //provide a "predicate" (method that returns true or false)
            //to decide to keep or remove the items

            //.map()        //provide a method to convert our items into something else
            //NOTE: can "convert" from something into itself

            //.sorted()       //provide a method to compare two items, to be used
            //for ordering the collection
            // -  a before b
            // 0  a == b
            // +  a after b

            //.foreach()    //provide a method to "consume" an item, and output nothing
                            //typically used for printing logic


            //C#

            List<int> nums = new List<int>{ 6, 7, 3, 4, 5, 1, 2 };

            //filtering

            var evens = nums.Where(x => x % 2 == 0);

            var useless = nums.Where(SomePredicate);


            //foreach (var even in evens) Console.WriteLine(even);

            //var odds = nums.Where(x => x % 2 == 1);
            var odds = nums.Except(evens);

            var allNums = evens.Union(odds);

            //foreach (var num in allNums) Console.WriteLine(num);

            //converting
            //Console.WriteLine("new odds:");
            var evensPlusOne = evens.Select(x => x + 1);
            //foreach (var newOdds in evensPlusOne) Console.WriteLine(newOdds);

            var oddsPlusOne = odds.Select(x => x + 1);
            //foreach (var newEvens in oddsPlusOne) Console.WriteLine(newEvens);


            var anonObjects = nums.Select(x =>
                new
                {
                    ID = x,
                    SomeOtherProp = x * 2
                }
            );

            //foreach (var anonObject in anonObjects) Console.WriteLine(anonObject);

            //Query syntax

            //1. start "from" a variable "in" the collection
            //2. filtering
            //3. "select" at the end always (even if we're not converting)
            Console.WriteLine("trying query syntax: ");
            var oddsByQuery = from x in nums
                              where x % 2 == 1
                              select x;

            //foreach (var oddByQuery in oddsByQuery) Console.WriteLine(oddByQuery);


            //sorting
            var sortedAsc = nums.OrderBy(x => x);

            //foreach (var x in sortedAsc) Console.WriteLine(x);

            IEnumerable<int> sortedDesc = nums.OrderByDescending(x => x);

            //foreach (var x in sortedDesc) Console.WriteLine(x);


            //Console.WriteLine( "writing using .Reverse()" );
            sortedDesc = sortedAsc.Reverse();
            //foreach (var x in sortedDesc) Console.WriteLine(x);

            //Console.WriteLine("original collection unchanged:" );
            //foreach (var x in sortedAsc) Console.WriteLine(x);


            //only grab some number of elements

            //get the top 3 numbers
            var topThree = sortedDesc.Take(3);

            //another approach (numbers will be in the opposite order)
            topThree = sortedAsc.TakeLast(3);


            //take until we hit a number less than 3

            var untilLessThanThree = nums.TakeWhile(x => x >= 3);
            //foreach (var x in untilLessThanThree) Console.WriteLine(x);


            //grab every number AFTER the top 3
            var bottomFour = sortedDesc.Skip(3);
            //foreach (var x in bottomFour) Console.WriteLine(x);


            List<string> names = new List<string> { "Alice", "Bob", "Charles", "Danielle", "Evan" };

            //assuming a = 1, b = 2, c = 3
            //find the "sum" of each name (each name is a "sum" of the letters)




            //alice  1 + 12 + 9 + 3 + 5 = 30

            //Console.WriteLine( "alice".Sum( c => (c - 'a') + 1 ));

            var sum = names.Sum(name =>


                     //string are IEnumerables of char
                     //so we can use linq on them too

                     name.ToLower().Sum(c => (c - 'a') + 1)

                 );

            var nameSums = names.Select(name =>


                    //string are IEnumerables of char
                    //so we can use linq on them too

                    name.ToLower().Sum(c => (c - 'a') + 1));

            foreach (var nameSum in nameSums) Console.WriteLine(nameSum );
            Console.WriteLine(sum);

            var avgNameSum = names.Average(name => name.ToLower().Sum(c => (c - 'a') + 1));
            Console.WriteLine(avgNameSum);



            //now we'll compute the harmonic sum (sum of 1/x for each x)
            var harmSum = nums.Aggregate(0.0, (acc, x) => acc + 1.0 / x );

            //1/1 + 1/2 + 1/3 + 1/4 + 1/5 + 1/6 + 1/7 = 2.592857142857143

            Console.WriteLine(harmSum);

            var allNames = names.Aggregate("", (acc, name) => name + acc);

            Console.WriteLine(allNames);


            //grouping

            //previously produced Dictionary<string, List<City>>

            List<Widget> allWidgets = new List<Widget>
            {
                new Widget { Name = "bicycle", Category = "transport", Price = 150m },
                new Widget { Name = "concrete", Category = "building supplies", Price = 25m },
                new Widget { Name = "bread", Category = "food", Price = 3m },
                new Widget { Name = "train", Category = "transport", Price = 15000000m },
                new Widget { Name = "eggs", Category = "food", Price = 1.5m },
                new Widget { Name = "lumber", Category = "building supplies", Price = 50m },
                new Widget { Name = "car", Category = "transport", Price = 15000m },
                new Widget { Name = "milk", Category = "food", Price = 4m },
            };

            //group widgets by category

            var widgetsByCategory = allWidgets.GroupBy(w => w.Category);

            foreach( var widgetCategory in widgetsByCategory)
            {
                Console.WriteLine( widgetCategory.Key );
                foreach( var widget in widgetCategory )
                {
                    Console.WriteLine(widget.Name + ": " + widget.Price);
                }
            }


            var divisibilityByThree = nums.GroupBy(n => n % 3);

            foreach (var nGroup in divisibilityByThree)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(nGroup.Key);
                foreach (var n in nGroup)
                {
                    Console.WriteLine(n);
                }
            }


            string ipsum = @"Bacon ipsum dolor amet shankle shank ground round tail pork, shoulder sirloin doner. Ham hock burgdoggen ribeye, beef ribs jerky beef meatloaf pancetta cow. Bresaola meatloaf ham hock, t-bone bacon jerky tail shank ball tip landjaeger rump. Pork belly jowl prosciutto ground round cupim fatback kevin pig turkey shoulder shankle landjaeger beef ribs flank sirloin. Meatball swine beef ribs filet mignon, frankfurter shankle strip steak capicola fatback turkey pastrami cupim brisket. Pastrami ham hock kevin buffalo. Cow shank prosciutto chuck ball tip brisket meatball short ribs meatloaf.

Capicola turkey tenderloin picanha turducken strip steak.Pork burgdoggen andouille picanha. Burgdoggen brisket shoulder, pork leberkas landjaeger t-bone ham beef ribs bresaola andouille short ribs boudin sirloin flank.Jerky kevin meatball, drumstick picanha pastrami andouille spare ribs landjaeger prosciutto ball tip chuck ham hock swine. Ham hock rump boudin short ribs tenderloin hamburger, pancetta chuck corned beef.

Kevin porchetta shankle, tail chuck brisket pork frankfurter.Kevin salami tri - tip bresaola beef ribs, biltong tenderloin fatback ribeye hamburger burgdoggen pork loin. Chicken leberkas ground round filet mignon brisket strip steak ribeye jowl pig meatball burgdoggen meatloaf bresaola drumstick.Tenderloin chicken turkey sirloin short loin leberkas kevin biltong jowl ham landjaeger cupim flank meatball bacon. Pancetta jowl ribeye cupim, salami tongue drumstick.

Chicken pig ham venison landjaeger porchetta meatball kielbasa ham hock chuck ribeye t - bone.Frankfurter boudin tongue strip steak jerky beef kielbasa fatback. Pork loin rump cupim frankfurter, bacon ribeye corned beef leberkas salami alcatra pig. Meatloaf pork belly frankfurter ground round jerky leberkas, chuck buffalo bacon boudin beef capicola.Fatback prosciutto bacon pancetta. Alcatra hamburger bacon, spare ribs strip steak brisket chuck kielbasa kevin pastrami tail meatloaf burgdoggen shoulder tongue.

Alcatra sirloin venison ham hock sausage, swine boudin biltong cupim short ribs pork shankle. Jerky short ribs pork belly short loin turkey tri-tip ham, cupim kielbasa prosciutto shank ribeye tenderloin bacon leberkas. Kevin ham tri - tip corned beef. Burgdoggen doner tail ball tip prosciutto ham hock. Salami pastrami pork loin sausage, bresaola venison leberkas kevin landjaeger turkey pork tri-tip burgdoggen ribeye.";

            //get top 5 words and their counts

            var words = ipsum.ToLower()
                .Replace(" - ", "-")
                .Replace(",", "")
                .Split(' ', '.', '\n', '\r')
                .Where(w => !String.IsNullOrWhiteSpace(w))
                .GroupBy(w => w)
                .Select(g => new
                {
                    Word = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(wordReport => wordReport.Count)
                .Take(5);


            foreach( var wordReport in words)
            {
                Console.WriteLine( $"{wordReport.Word}: {wordReport.Count}" );
            }



            var letterGroups = ipsum.ToLower()
                .Replace(" - ", "-")
                .Replace(",", "")
                .Split(' ', '.', '\n', '\r')
                .Where(w => !String.IsNullOrWhiteSpace(w))
                .GroupBy(w => w[0])
                .Select(g => new
                {
                    Letter = g.Key,
                    Count = g.Count(),
                    OriginalWords = g.Distinct().OrderBy(w=>w).ToList()
                })
                .OrderByDescending(wordReport => wordReport.Count)
                .Take(5);

            foreach (var letterReport in letterGroups)
            {
                Console.WriteLine($"{letterReport.Letter}: {letterReport.Count}");
                foreach( var word in letterReport.OriginalWords)
                {
                    Console.WriteLine("\t" + word);
                }
            }


            //selecting an individual value



            var singleNum = nums.Where(n => n == 7).Single();

            singleNum = nums.Where(n => n == 8).SingleOrDefault();


            var firstNum = nums.Where(n => n > 2).First();
            //equivalent to:

            firstNum = nums.First(n => n > 2);

            //crashes

            //firstNum = nums.First(n => n < 0);

            firstNum = nums.FirstOrDefault(n => n < 0);

            int y = 5 + firstNum;


        }

        public static bool SomePredicate( int x)
        {
            return true;
        }
    }
}
