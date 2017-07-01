// <copyright file="Problem004.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Largest palindrome product
    /// -
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public class Problem004 : Problem
    {
        private int _largestPalindromeProduct;

        public Problem004()
        {
            Digits = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem004Key]
                    .Collection[ProjectEulerConstants.Problem004DigitsKey]);
        }

        public Problem004(int digits)
        {
            Digits = digits;
        }

        public int Digits { get; set; }

        public override dynamic Solve()
        {
            // The starting n-digit number.
            var startingNDigitNumber = (int)Math.Pow(10.0, Digits) - 1;

            // Theory where we can define a lower limit.
            var lowerLimit = startingNDigitNumber - (int)Math.Pow(10.0, Digits - 1);

            for (var i = startingNDigitNumber; i > lowerLimit; i--)
            {
                for (var j = i; j >= lowerLimit; j--)
                {
                    // Potential palindrome.
                    var product = i * j;

                    // Store the product to compare with after checking.
                    var number = product;

                    // Reverse of the potential palindrome.
                    var reverse = 0;

                    // Check product digit by digit starting from the right.
                    while (product > 0)
                    {
                        var digit = product % 10;
                        reverse = (reverse * 10) + digit;
                        product = product / 10;
                    }

                    // Palindrome found.
                    if (number != reverse)
                    {
                        continue;
                    }

                    _largestPalindromeProduct = number;
                    return _largestPalindromeProduct;
                }
            }

            return null;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The largest palindrome made from the product of two [" +
                Digits +
                "]-digit numbers is [" +
                _largestPalindromeProduct +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
