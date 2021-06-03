using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static Mutex _inputsLock = new Mutex();
        static Queue<int> _fromValues = new Queue<int>();
        static Queue<int> _toValues = new Queue<int>();


        //static List<int> _results = new List<int>();
        static Queue<int> _results = new Queue<int>();
        static Mutex _resultsLock = new Mutex();

        static async Task Main(string[] args)
        {

            Stopwatch watch = new Stopwatch();


            watch.Start();
            //Task<int> longJob = Task<int>.Factory.StartNew(() => Count(100_000_000, 200_000_000));
            //Task<int> shortJob = Task<int>.Factory.StartNew(() =>  Count(1, 10));

            //List<Task<int>> tasks = new List<Task<int>> { longJob, shortJob };


            List<Task<int>> tasks = new List<Task<int>>();

            for( int thread = 0; thread < 40; thread++)
            {
                _inputsLock.WaitOne();
                _fromValues.Enqueue(RNG.NextInt(10000, 20000));
                _toValues.Enqueue(RNG.NextInt(30000, 40000));
                _inputsLock.ReleaseMutex();
                var jobToAdd = Task<int>.Factory.StartNew(
                    () => Count());

                tasks.Add(jobToAdd);
            }

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
                (allTasks) => Console.WriteLine("we're done: " + watch.ElapsedMilliseconds));



            //Task.WaitAll(new Task[] { longJob, shortJob });




            watch.Stop();

            foreach( int result in _results)
            {
                Console.WriteLine(result);
            }




            //Console.WriteLine("Total calc time: " + watch.Elapsed.TotalSeconds);

        }


        static int Count()
        {
            int count = 0;


            bool inputLocked = _inputsLock.WaitOne();
            if (inputLocked)
            {
                int from = _fromValues.Dequeue();
                int to = _toValues.Dequeue();

                _inputsLock.ReleaseMutex();

                Console.WriteLine("Starting " + Thread.CurrentThread.Name + $"({from}, {to})");


                //Console.WriteLine($"counting from {from} to {to}");
                for (int i = from; i <= to; i++)
                {
                    count++;
                }


                bool securedLock = _resultsLock.WaitOne();
                if (securedLock)
                {
                    _results.Enqueue(count);
                    _resultsLock.ReleaseMutex();
                }
                Console.WriteLine("Stopping " + Thread.CurrentThread.Name + $"({from}, {to})");

            }

            //lock( _results)
            //{
            //    _results.Add(count);
            //}

            //this should only happen in this if
            //otherwise this thread doesn't "own" the mutex
            //and this line will cause an exception



            //Console.WriteLine($"count from {from} to {to} equals {sum}");

            return count;
        }
    }
}
