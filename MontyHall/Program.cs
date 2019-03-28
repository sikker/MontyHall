using System;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1000;
            int stayWins = 0;
            int changeWins = 0;

            Console.WriteLine("Solving the Monty Hall Problem!");
            Console.WriteLine("");
            Console.WriteLine("A game show with three doors. Behind one door is a car,");
            Console.WriteLine("behind the other two are a goat each. You choose a door.");
            Console.WriteLine("The host now opens one of the goat doors and offers to");
            Console.WriteLine("let you change your choice before revealing which door is");
            Console.WriteLine("the one with the car. Is it better, worse, or the same to");
            Console.WriteLine("change your choice?");
            Console.WriteLine("");
            Console.WriteLine("Let's put it to the test!");

            while (i-- > 0)
            {
                if (SolveProblem(true))
                {
                    stayWins++;
                }

                if (SolveProblem(false))
                {
                    changeWins++;
                }
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Staying on first choice...");
            Console.WriteLine("Won the car " + stayWins + "/1000 times");
            Console.WriteLine("Changing our choice...");
            Console.WriteLine("Won the car " + changeWins + "/1000 times");
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("The winning move is...");
            if (changeWins > stayWins)
            {
                Console.WriteLine("Changing your choice!");
            }
            else if (stayWins > changeWins)
            {
                Console.WriteLine("Sticking with your first choice!");
            }
            else
            {
                Console.WriteLine("Not to play!");
            }
            Console.WriteLine("");
        }

        static bool SolveProblem(bool stay)
        {
            String[] doors = { "goat", "goat", "car" };
            Random rng = new Random();
            int initialChoice = rng.Next(doors.Length);
            int openedDoor;
            do
            {
                openedDoor = rng.Next(doors.Length);
            }
            while (openedDoor == initialChoice || doors[openedDoor] == "car" );

            if (stay)
            {
                return (doors[initialChoice] == "car");
            }
            else
            {
                int newChoice;
                do
                {
                    newChoice = rng.Next(doors.Length);
                }
                while (newChoice == initialChoice || newChoice == openedDoor);

                return (doors[newChoice] == "car");
            }
        }
    }
}
