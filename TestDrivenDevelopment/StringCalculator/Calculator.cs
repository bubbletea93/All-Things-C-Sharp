using System;
using System.Linq;

namespace StringCalculator.UnitTest
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public int Add(string numbers)
        {
            var separators = new char[] { ',', '\n' };
            var splitNumbers = numbers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0;

            //If numbers are not numbers throw ArguementException
            if (splitNumbers.Any(x => !int.TryParse(x, out int result)))
            {
                throw new ArgumentException($"Verify all numbers are valid integers.");
            }

            if (splitNumbers.Any())
            {
                foreach (var number in splitNumbers)
                {
                    var isInt = int.TryParse(number, out int result);

                    if (isInt )
                    {
                        sum += result;
                    }
                }

                return sum;
            }
            else
            {
                return sum;
            }
        }
    }
}