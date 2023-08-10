using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Random rng = new Random();

            bool cont = true;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Laser Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? type true if yes/ type false if no:");
            cont = bool.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age?");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? type 'true' for Sure/type 'false' for No thanks: ");
            bool seeList = bool.Parse(Console.ReadLine());
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? type 'true' for yes/type 'false' for no: ");
                bool addToList = bool.Parse(Console.ReadLine());
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? type 'true' for yes/type 'false' for no: ");
                    addToList = bool.Parse(Console.ReadLine());
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? type 'true' for Keep/type 'false' for Redo: ");
                Console.WriteLine();
                cont = bool.Parse(Console.ReadLine());
            }

        }
    }
}