using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Stopwatch watch = new Stopwatch();


            watch.Start();
            Task<int> longJob = Task<int>.Factory.StartNew(() => Count(100_000_000, 200_000_000));
            Task<int> shortJob = Task<int>.Factory.StartNew(() =>  Count(1, 10));

            List<Task<int>> tasks = new List<Task<int>> { longJob, shortJob };


            long lastTime = watch.ElapsedMilliseconds;

            //we'll try checking each task as it finishes

            //while( tasks.Count > 0)
            //{

            //    Task<int> justCompleted = await Task.WhenAny(tasks);

            //    var currentTime = watch.ElapsedMilliseconds;

            //    int answer = justCompleted.Result;

            //    Console.WriteLine("the just computed answer is " + answer);
            //    Console.WriteLine("milliseconds since last thread finished: " + (currentTime - lastTime));
            //    tasks.Remove(justCompleted);
            //}


            //now we'll try just waiting for all the results

            //int[] results = await Task.WhenAll(tasks);

            //foreach( int result in results)
            //{
            //    Console.WriteLine(result + "!");
            //}


            //now we'll try setting up a task to run when all results are complete

            await Task.Factory.ContinueWhenAll(tasks.ToArray(),
                (allTasks) => Console.WriteLine("we're done"));



            //Task.WaitAll(new Task[] { longJob, shortJob });




            watch.Stop();




            //Console.WriteLine("Total calc time: " + watch.Elapsed.TotalSeconds);

        }


        static int Count( int from, int to)
        {
            
            //Console.WriteLine($"counting from {from} to {to}");
            int sum = 0;
            for( int i = from; i <= to; i++)
            {
                sum++;
            }

            //Console.WriteLine($"count from {from} to {to} equals {sum}");

            return sum;
        }
    }
}
