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
