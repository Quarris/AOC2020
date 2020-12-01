using System;
using System.Linq;

namespace AOC2020 {
    public class Day1 : IDay {

        public void DoPart1(string[] inputs) {
            // Select => O(n) * O(1); OrderBy => O(nlogn) avg, O(n^2) worst;
            int[] expenses = inputs.Select(int.Parse).OrderBy(i => i).ToArray();
            int front = 0;
            int back = expenses.Length - 1;

            // O(n)
            while (front < back) {
                int sum = expenses[front] + expenses[back];
                if (sum == 2020) {
                    break;
                }

                if (sum > 2020) {
                    back--;
                } else {
                    front++;
                }
            }

            if (expenses[front] + expenses[back] != 2020) {
                throw new ArgumentException("Expenses do not contained any values which sum to 2020");
            }

            Console.WriteLine($"Expenses '{expenses[front]}' and '{expenses[back]}' sum to 2020");
            Console.WriteLine($"Expense product results in {expenses[front] * expenses[back]}");
        }

        public void DoPart2(string[] inputs) {
            // Select => O(n) * O(1); OrderBy => O(nlogn) avg, O(n^2) worst;
            int[] expenses = inputs.Select(int.Parse).OrderBy(i => i).ToArray();
            int front = 0;
            int middle;
            int back = expenses.Length - 1;

            // O(n)
            for (middle = 1; middle < expenses.Length - 1; middle++) {
                front = 0;
                back = expenses.Length - 1;
                // O(n)
                while (front < back) {
                    int sum = expenses[front] + expenses[middle] + expenses[back];
                    if (sum == 2020) {
                        goto foundSum;
                    }

                    if (sum > 2020) {
                        back--;
                    } else {
                        front++;
                    }
                }
            }

            foundSum:
            if (expenses[front] + expenses[middle] + expenses[back] != 2020) {
                throw new ArgumentException("Expenses do not contained any values which sum to 2020");
            }

            Console.WriteLine($"Expenses '{expenses[front]}' and '{expenses[middle]}' and '{expenses[back]}' sum to 2020");
            Console.WriteLine($"Expense product results in {expenses[front] * expenses[middle] * expenses[back]}");
        }
    }
}