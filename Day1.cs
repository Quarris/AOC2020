using System;
using System.Linq;

namespace AOC2020 {
    public class Day1 : IDay {

        public void DoPart1(string[] inputs) {
            int[] expenses = inputs.Select(int.Parse).ToArray();
            for (int i = 0; i < expenses.Length; i++) {
                for (int j = i + 1; j < expenses.Length; j++) {
                    int firstExpense = expenses[i];
                    int secondExpense = expenses[j];
                    if (firstExpense + secondExpense == 2020) {
                        Console.WriteLine($"The expenses which sum to 2020 are {firstExpense} and {secondExpense}");
                        Console.WriteLine($"Their product is {firstExpense * secondExpense}");
                        return;
                    }
                }
            }
        }

        public void DoPart2(string[] inputs) {
            int[] expenses = inputs.Select(int.Parse).ToArray();
            for (int i = 0; i < expenses.Length; i++) {
                for (int j = i + 1; j < expenses.Length; j++) {
                    for (int k = j + 1; k < expenses.Length; k++) {
                        int firstExpense = expenses[i];
                        int secondExpense = expenses[j];
                        int thirdExpense = expenses[k];
                        if (firstExpense + secondExpense + thirdExpense == 2020) {
                            Console.WriteLine($"The expenses which sum to 2020 are {firstExpense} and {secondExpense} and {thirdExpense}");
                            Console.WriteLine($"Their product is {firstExpense * secondExpense * thirdExpense}");
                            return;
                        }
                    }
                }
            }
        }
    }
}