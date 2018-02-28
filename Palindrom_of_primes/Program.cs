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

			int[] intNums = Enumerable.Range(0, max5Digit).ToArray();							//Generate array
			intNums[1] = 0;																		//Prepare to Eratosthenes
			for(int i = 2; i < intNums.Length; ++i)                                             //Main algorithm
			{
				if (intNums[i] != 0) {
					for (int j = i * 2; j < intNums.Length; j += i)
						intNums[j] = 0;
				}
			}

			int[] primes = intNums.Where(d => d >= min5Digit && d <= max5Digit).ToArray();      //Select only 5 digit numbers

			//Looking for max polindrom
			int x = 0;                                                                          //1st multiplier
			int y = 0;                                                                          //2nd multiplier
			long pal = 0;									                                   //result

			for(int i = 0; i < primes.Length - 1; ++i)
				for(int j = i+1; j < primes.Length; ++j)
				{
					long mult = (long)primes[i] * (long)primes[j];
					if (isPalindorme(mult) && mult > pal)
					{
						pal = mult;
						x = primes[i];
						y = primes[j];
					}

				}
					
			
			Console.WriteLine($"{x} * {y} = {pal}");
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
