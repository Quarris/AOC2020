using System;
using System.Linq;

namespace AOC2020 {
    public class Day2 : IDay {
        public void DoPart1(string[] inputs) {
            int validPasswords = 0;

            foreach (string input in inputs) {
                string[] split = input.Split(' ');
                int[] appearCount = split[0].Split('-').Select(int.Parse).ToArray(); // [min, max] The amount of times (inclusive) the letter can appear.
                char letter = split[1][0]; // The letter that is checked to appear.
                string password = split[2]; // The password.
                int count = password.ToCharArray().Count(c => c == letter);

                if (count >= appearCount[0] && count <= appearCount[1]) {
                    validPasswords++;
                }
            }

            Console.WriteLine($"Number of valid passwords is {validPasswords}");
        }

        public void DoPart2(string[] inputs) {
            int validPasswords = 0;

            foreach (string input in inputs) {
                string[] split = input.Split(' ');
                int[] positions = split[0].Split('-').Select(int.Parse).ToArray(); // [first, second] The positions that the letter has to appear in exactly once.
                char letter = split[1][0]; // The letter that is checked for.
                string password = split[2]; // The password.

                if (password[positions[0] - 1] == letter ^ password[positions[1] - 1] == letter) {
                    validPasswords++;
                }
            }

            Console.WriteLine($"Number of valid passwords is {validPasswords}");
        }
    }
}