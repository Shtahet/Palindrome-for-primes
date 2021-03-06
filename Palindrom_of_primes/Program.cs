﻿using System;
using System.Linq;
using System.Threading.Tasks;

namespace Palindrom_of_primes
{
    class Program
    {
        static void Main(string[] args)
        {
			DateTime StartTime = DateTime.Now;
			
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
			long pal = 0;																		//result

			Object lockObj = new Object();                                                      //Lock object for multithreaded computing
			Parallel.For(0, primes.Length - 1, index => {                                       //Multithreading cycle for
				for (int j = index + 1; j < primes.Length; ++j)									//Subcycle
				{
					long mult = (long)primes[index] * (long)primes[j];
					if (isPalindorme(mult) == true)
					{
						lock (lockObj)															//Lock result calculation
						{
							if (mult > pal) {
								pal = mult;
								x = primes[index];
								y = primes[j];
							}
						}
					}

				}
			});

			//Display result
			Console.WriteLine($"{x} * {y} = {pal}");
			Console.WriteLine("Duration: {0}", DateTime.Now - StartTime);
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
