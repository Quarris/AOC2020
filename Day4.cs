using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AOC2020 {
    public class Day4 : IDay {
        public void DoPart1(string[] inputs) {
            // Converts the inputs so that each line represents fields for a single passport.
            inputs = string.Join(" ", inputs).Split(new[] {"  "}, StringSplitOptions.None);

            List<Passport> passports = new List<Passport>();
            foreach (string line in inputs) {
                List<(string, string)> fields = line.Split(' ').Select(entry => {
                    string[] kvp = entry.Split(':');
                    return (kvp[0], kvp[1]);
                }).ToList();

                passports.Add(new Passport(fields.ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2)));
            }

            Console.WriteLine($"Found {passports.Count} passports of which {passports.Count(passport => passport.HasRequiredFields)} are valid");
        }

        public void DoPart2(string[] inputs) {
            // Converts the inputs so that each line represents fields for a single passport.
            inputs = string.Join(" ", inputs).Split(new[] {"  "}, StringSplitOptions.None);

            List<Passport> passports = new List<Passport>();
            foreach (string line in inputs) {
                List<(string, string)> fields = line.Split(' ').Select(entry => {
                    string[] kvp = entry.Split(':');
                    return (kvp[0], kvp[1]);
                }).ToList();

                passports.Add(new Passport(fields.ToDictionary(kvp => kvp.Item1, kvp => kvp.Item2)));
            }

            Console.WriteLine($"Found {passports.Count} passports of which {passports.Count(passport => passport.IsValidated())} are valid");
        }

        struct Passport {
            private static ISet<string> EyeColors { get; } = new HashSet<string>(new []{
                "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
            });

            private readonly Dictionary<string, string> _fields;

            public bool HasRequiredFields => this._fields.Count(kvp => kvp.Key != "cid") == 7;

            internal Passport(Dictionary<string, string> fields) {
                this._fields = new Dictionary<string, string>(fields);
            }

            public bool IsValidated() {
                try {
                    // Check Birth Year
                    int byr = int.Parse(this._fields["byr"]);
                    if (byr < 1920 || byr > 2002) {
                        return false;
                    }

                    // Check Issue Year
                    int iyr = int.Parse(this._fields["iyr"]);
                    if (iyr < 2010 || iyr > 2020) {
                        return false;
                    }

                    // Check Expiration Year
                    int eyr = int.Parse(this._fields["eyr"]);
                    if (eyr < 2020 || eyr > 2030) {
                        return false;
                    }

                    // Check Height
                    string heightField = this._fields["hgt"];
                    if (!heightField.Contains("cm") && !heightField.Contains("in"))
                        return false;
                    int typeIndex = heightField.Length - 2;
                    string type = heightField.Substring(typeIndex);
                    int height = int.Parse(heightField.Remove(typeIndex));
                    if (type == "cm" && (height < 150 || height > 193)) {
                        return false;
                    }

                    if (type == "in" && (height < 59 || height > 76)) {
                        return false;
                    }

                    // Check Hair Color
                    string hairColorField = this._fields["hcl"];
                    if (hairColorField.Length != 7 || hairColorField[0] != '#') {
                        return false;
                    }
                    if (!int.TryParse(hairColorField.Substring(1), NumberStyles.HexNumber, new NumberFormatInfo(), out int hairColor)) {
                        return false;
                    }

                    // Check Eye Color
                    if (!EyeColors.Contains(this._fields["ecl"]))
                        return false;

                    // Check Passport ID
                    string pid = this._fields["pid"];
                    if (pid.Count(char.IsDigit) != 9) {
                        return false;
                    }
                } catch (IndexOutOfRangeException exp) {
                    return false;
                } catch (KeyNotFoundException exp) {
                    return false;
                } catch (FormatException exp) {
                    return false;
                }

                return true;
            }
        }
    }
}