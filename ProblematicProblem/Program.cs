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

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes or no?:");
            var ans = Console.ReadLine().ToLower();
            cont = (ans == "yes"||ans == "sure" || ans == "ok");
            if (!cont)
            {
                Console.WriteLine("Goodbye");
                return;
            }
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? type 'yes' or 'no' ");
            var userInput = Console.ReadLine();

            if (userInput == "yes")

            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? type 'yes' or 'no' ");
                bool addToList = Console.ReadLine() == "yes";
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
                    Console.WriteLine("Would you like to add more? type 'yes' to add your own activity or 'no' to continue: ");
                    addToList = Console.ReadLine() == "yes";

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
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? type 'Keep' to keep your current random activy or 'Redo' to generate a new activity!: ");
                Console.WriteLine();
                cont = Console.ReadLine().ToLower() == "redo";
            }

        }
    }
}