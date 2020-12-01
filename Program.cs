using System;
using System.IO;

namespace AOC2020 {
    class Program {
        private static IDay[] solutions = {
            new Day1()
        };

        static void Main(string[] args) {
            int day;
            do {
                Console.Write("Which day would you like to test?");
                bool parsed = int.TryParse(Console.ReadLine(), out day);
                if (!parsed || day < 1 || day > 25) {
                    Console.WriteLine("Incorrect day. Insert a day between 1 and 25 inclusive.");
                } else break;
            } while (true);

            IDay solution = solutions[day - 1];
            string[] inputs = GetInputs(day);
            Console.WriteLine($"Are you ready to test day {day} part 1?");
            Console.ReadKey(true);
            Console.WriteLine($"Testing Part 2 of day {day}");
            solution.DoPart1(inputs);
            Console.WriteLine($"Are you ready to test day {day} part 2?");
            Console.ReadKey(true);
            Console.WriteLine($"Testing Part 2 of day {day}");
            solution.DoPart2(inputs);
        }

        static string[] GetInputs(int day) {
            return File.ReadAllLines($"Inputs/{day}");
        }
    }
}