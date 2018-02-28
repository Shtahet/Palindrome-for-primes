using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom_of_primes
{
    class Program
    {
        static void Main(string[] args)
        {
			//Looking for primes 
			//Sieve of Eratosthenes
			const int max5Digit = 99999;
			const int min5Digit = 10000;

			int[] intNums = Enumerable.Range(0, max5Digit).ToArray();
			intNums[1] = 0;
			for(int i = 2; i < intNums.Length; ++i)
			{
				if (intNums[i] != 0) {
					for (int j = i * 2; j < intNums.Length; j += i)
						intNums[j] = 0;
				}
			}

			int[] primes = intNums.Where(x => x >= min5Digit && x <= max5Digit).ToArray();

			foreach (int i in primes)
				Console.WriteLine($"{i}\t");
			Console.ReadLine();
		}

		//Check that number is palindrome
		public static bool isPalindorme(long number)
        {
            long revNumber = 0;													//Reverse number
            long tmpNumber = number;                                            //Number for action

			//Reverse digits
			while (tmpNumber > 10)
			{
				revNumber *= 10;
				revNumber += tmpNumber % 10;
				tmpNumber = tmpNumber / 10;
			}

			//Add last digit
			revNumber = revNumber * 10 + tmpNumber;

			return (revNumber == number) ? true:  false;
        }
    }
}
