using System;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            int stayWins = 0;
            int changeWins = 0;

            Console.WriteLine(
                "Solving the Monty Hall Problem!\n" +
                "\n" +
                "A game show with three doors. Behind one door is a car,\n" +
                "behind the other two are a goat each. You choose a door.\n" +
                "The host now opens one of the goat doors and offers to\n" +
                "let you change your choice before revealing which door is\n" +
                "the one with the car. Is it better, worse, or the same to\n" +
                "change your choice?\n" +
                "\n" +
                "Let's put it to the test!");

            for (var i = 0; i < 1000; i++)
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

            Console.WriteLine(
                "-------------------------------------\n" +
                "Staying on first choice...\n" +
                "Won the car {0:D}/1000 times\n" +
                "Changing our choice...\n" +
                "Won the car {1:D}/1000 times\n" +
                "-------------------------------------\n" +
                "The winning move is...",
                stayWins, changeWins);

            if (changeWins > stayWins)
            {
                Console.WriteLine("Changing your choice!\n");
            }
            else if (stayWins > changeWins)
            {
                Console.WriteLine("Sticking with your first choice!\n");
            }
            else
            {
                Console.WriteLine("Not to play!\n");
            }
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
            while ((openedDoor == initialChoice) || (doors[openedDoor] == "car"));

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
                while ((newChoice == initialChoice) || (newChoice == openedDoor));

                return (doors[newChoice] == "car");
            }
        }
    }
}
