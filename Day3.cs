using System;

namespace AOC2020 {
    public class Day3 : IDay {
        private const char Tree = '#';

        public void DoPart1(string[] inputs) {
            int posX = 0;
            int posY = 0;
            int trees = 0;

            while (posY < inputs.Length - 1) {
                posX += 3;
                posY++;

                char[] row = inputs[posY].ToCharArray();
                if (row[posX % row.Length] == Tree) {
                    trees++;
                }
            }

            Console.WriteLine($"Encountered {trees} trees.");
        }

        public void DoPart2(string[] inputs) {
            int[][] slopes = {
                new[] {1, 1},
                new[] {3, 1},
                new[] {5, 1},
                new[] {7, 1},
                new[] {1, 2}
            };

            long result = 1;
            foreach (int[] slope in slopes) {
                int posX = 0;
                int posY = 0;
                int trees = 0;
                while (posY < inputs.Length - 1) {
                    posX += slope[0];
                    posY += slope[1];

                    char[] row = inputs[posY].ToCharArray();
                    if (row[posX % row.Length] == Tree) {
                        trees++;
                    }
                }

                Console.WriteLine($"Encountered {trees} trees for slope ({slope[0]}, {slope[1]}).");
                result *= trees;
                Console.WriteLine(result);
            }

            Console.WriteLine($"Collective multiple of trees is {result}.");
        }
    }
}