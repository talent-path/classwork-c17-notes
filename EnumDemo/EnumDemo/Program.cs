using System;

namespace EnumDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            //for (var light = TrafficLight.EXCLUSIVE_MIN + 1; light < TrafficLight.EXCLUSIVE_MAX; light++)
            //{
            //    Console.WriteLine(light);
            //}

            //foreach (string lightName in Enum.GetNames(typeof( TrafficLight))){
            //    Console.WriteLine(lightName);
            //}


            Console.WriteLine("Please enter traffic light state: ");
            string userInput = Console.ReadLine();
            TrafficLight userLight = (TrafficLight)Enum.Parse(typeof(TrafficLight), userInput);


            Console.WriteLine((int)userLight);

        }
    }
}
