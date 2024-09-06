using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static LinqExamples.Coffee;

namespace LinqExamples
{

    public class Program
    {
        static List<Brew> AllBrews() => Enum.GetValues(typeof(Brew)).Cast<Brew>().ToList();
        static List<Flavor> AllFlavors() => Enum.GetValues(typeof(Flavor)).Cast<Flavor>().ToList();
        static List<Size> AllSizes() => Enum.GetValues(typeof(Size)).Cast<Size>().ToList();
       
        public static void Main(string[] args)
        {
            //Fake DB list
            List<Coffee> allCoffees = new List<Coffee>();

            //Populate fake DB with random data
            while(allCoffees.Count < 1000000)
            {
                allCoffees.Add(GeneratedCoffee() );
            }

            Stopwatch timer = new Stopwatch();

            //---------------------------------
            // Exammple 1: Count vs Any
            //---------------------------------

            timer.Start();
            if (allCoffees.Count(x => x.CoffeeSize == Size.Large) > 0)
            {
                timer.Stop();
                Console.WriteLine($"Count: {timer.ElapsedTicks}");
            }
            
            timer.Restart();
            if (allCoffees.Any(x => x.CoffeeSize == Size.Large))
            {
                timer.Stop();
                Console.WriteLine($"Any: {timer.ElapsedTicks}");
            }


            //---------------------------------
            // Exammple 2: firstOrDefault vs Find
            //---------------------------------

            timer.Restart();
            if (allCoffees.FirstOrDefault(x => x.CoffeeBrew == Brew.Latte && x.CoffeeFlavor == Flavor.PumpkinSpice 
                                          &&  x.CoffeeSize == Size.Medium) != null)
            {
                timer.Stop();
                Console.WriteLine($"FirstOrDefault: {timer.ElapsedTicks}");
            }
            
            timer.Restart();
            if (allCoffees.Find(x => x.CoffeeBrew == Brew.Latte && x.CoffeeFlavor == Flavor.PumpkinSpice 
                                &&  x.CoffeeSize == Size.Medium) != null)
            {
                timer.Stop();
                Console.WriteLine($"Find: {timer.ElapsedTicks}");
            }


            //---------------------------------
            // Exammple 3: When not to use LINQ
            //---------------------------------


            var testList = allCoffees.Count;
            
            timer.Restart();
            var s = Enumerable.Range(1, testList)
                                .Select(n => n * 2)
                                .Select(n => n * 100)
                                .Select(n => Math.Pow(n, 3))
                                .Sum();
            timer.Stop();
            Console.WriteLine($"LINQ: {timer.ElapsedTicks}");

            timer.Restart();
            double sum = 0;
            for (int n = 1; n <= testList; n++)
            {
              int a = n * 2;
              double b = a * 100;
              double c = Math.Pow(b, 3);
              sum += c;
            }
            timer.Stop();
            Console.WriteLine($"For loop: {timer.ElapsedTicks}");
        }

        //Generate random coffee objects
        static Coffee GeneratedCoffee()
        {
            Random randomBrew = new Random();
            Random randomFlavor = new Random();
            Random randomSize = new Random();

            return new Coffee(AllBrews()[ randomBrew.Next(0, 6) ],
                              AllFlavors()[ randomFlavor.Next(0, 9) ],
                              AllSizes()[ randomSize.Next(0, 3) ] );
        }

    }
}