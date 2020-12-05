using System;

namespace AOC2020 {
    public class Day5 : IDay {
        public void DoPart1(string[] inputs) {
            int highestSeatID = -1;
            foreach (string input in inputs) {
                int row = this.FindRow(0, 128, input);
                int col = this.FindColumn(0, 8, input.Substring(7));
                int seatID = row * 8 + col;
                if (seatID > highestSeatID) {
                    highestSeatID = seatID;
                }
            }

            Console.WriteLine($"The highest seat ID is {highestSeatID}");
        }

        public void DoPart2(string[] inputs) {
            throw new System.NotImplementedException();
        }

        int FindRow(int start, int end, string partition) {
            if (partition[0] != 'F' && partition[0] != 'B') {
                return start;
            }

            if (partition[0] == 'F') {
                end = start / 2 + end / 2;
            } else {
                start = start / 2 + end / 2;
            }

            return this.FindRow(start, end, partition.Substring(1));
        }

        int FindColumn(int start, int end, string partition) {
            if (partition.Length == 0 || partition[0] != 'R' && partition[0] != 'L') {
                return start;
            }

            if (partition[0] == 'L') {
                end = start / 2 + end / 2;
            } else {
                start = start / 2 + end / 2;
            }

            return this.FindColumn(start, end, partition.Substring(1));
        }
    }
}