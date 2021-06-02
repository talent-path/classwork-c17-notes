using System;
using System.Collections.Generic;
using LinkedList;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DavidLinkedList<string> firstList = new DavidLinkedList<string>();

            firstList.Add("Alice");
            firstList.Add("Bob");
            firstList.Add("Clarice");
            firstList.Add("David");
            firstList.Add("Elizabeth");

            foreach (string temp in firstList)
            {
                Console.WriteLine(temp);
            }

            foreach (string temp in firstList)
            {
                Console.WriteLine(temp);
            }


            foreach (string temp in firstList)
            {
                Console.WriteLine(temp);
            }


        }
    }
}
