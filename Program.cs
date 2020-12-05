using System;
using System.IO;

namespace AOC2020 {
    class Program {
        private static IDay[] solutions = {
            new Day1(),
            new Day2(),
            new Day3(),
            new Day4(),
            new Day5()
        };

        static void Main(string[] args) {
            Boolean.TryParse(args[0], out bool isTest);
            int day;
            do {
                Console.WriteLine("Which day would you like to test?\n");
                bool parsed = int.TryParse(Console.ReadLine(), out day);
                if (!parsed || day < 1 || day > 25) {
                    Console.WriteLine("Incorrect day. Insert a day between 1 and 25 inclusive.");
                } else break;
            } while (true);

            IDay solution = solutions[day - 1];
            string[] inputs = isTest ? GetTestInputs(day) : GetInputs(day);
            Console.WriteLine($"Press any key to test day {day} part 1...");
            Console.ReadKey(true);
            Console.WriteLine($"Testing Part 1 of day {day}");
            solution.DoPart1(inputs);
            Console.WriteLine($"Press any key to test day {day} part 2...");
            Console.ReadKey(true);
            Console.WriteLine($"Testing Part 2 of day {day}");
            solution.DoPart2(inputs);
        }

        static string[] GetInputs(int day) {
            return File.ReadAllLines($"Inputs/Day{day}.txt");
        }

        static string[] GetTestInputs(int day) {
            return File.ReadAllLines($"Inputs/Day{day}Test.txt");
        }
    }
}