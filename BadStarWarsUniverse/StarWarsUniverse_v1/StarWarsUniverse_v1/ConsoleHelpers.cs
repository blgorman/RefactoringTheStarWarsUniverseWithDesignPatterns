using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsUniverse_v1
{
    public static class ConsoleHelpers
    {
        public static string GetUserInput(string message, bool getConfirmation = true)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }

            var inputString = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine($"Invalid input, please try again.");
                if (!string.IsNullOrWhiteSpace(message))
                {
                    Console.WriteLine(message);
                }

                var innerInputString = Console.ReadLine() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(innerInputString))
                {
                    inputString = innerInputString;
                }
            }

            if (getConfirmation)
            {
                //give the user a chance to enter a new value [recursively]
                Console.WriteLine($"You have entered {inputString}. Is this value correct [y/n]?");
                var correctInput = (Console.ReadLine()?.StartsWith("y", StringComparison.OrdinalIgnoreCase) ?? false);
                if (!correctInput)
                {
                    Console.WriteLine("You have requested to re-enter the value");
                    inputString = GetUserInput(message);
                }
            }
            
            return inputString;
        }

        public static int GetUserInputInteger(string message, bool getConfirmation = true, int min = int.MinValue, int max = int.MaxValue)
        {
            var success = false;
            int result = 0;
            while (!success)
            {
                var numberString = GetUserInput(message, getConfirmation);

                success = int.TryParse(numberString, out result);
                if (!success)
                {
                    Console.WriteLine("Incorrect value supplied");
                    continue;
                }

                if (result < min || result > max)
                {
                    Console.WriteLine($"Please make sure number is in range {min} - {max}");
                    continue;
                }
            }

            return result;
        }

        public static double GetUserInputDouble(string message, bool getConfirmation = true, double min = double.MinValue, double max = double.MaxValue)
        {
            var success = false;
            double result = 0;
            while (!success)
            {
                var numberString = GetUserInput(message, getConfirmation);

                success = double.TryParse(numberString, out result);
                if (!success)
                {
                    Console.WriteLine("Incorrect value supplied");
                    continue;
                }

                if (result < min || result > max)
                {
                    Console.WriteLine($"Please make sure number is in range {min} - {max}");
                    continue;
                }
            }

            return result;
        }

        public static int PrintMenuAndGetChoice(Dictionary<int, string> menuItems, int minChoice, int maxChoice, bool getConfirmation = false)
        {
            Console.WriteLine(new string('*', 80));
            foreach (var item in menuItems)
            {
                Console.WriteLine($"* Enter {item.Key} for {item.Value}");
            }
            Console.WriteLine(new string('*', 80));

            return GetUserInputInteger(String.Empty, getConfirmation);
        }

    }
}
