// <copyright file="Problem024.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Lexicographic permutations
    /// -
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
    /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order.
    /// The lexicographic permutations of 0, 1 and 2 are: 012 021 102 120 201 210
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    public class Problem024 : Problem
    {
        private string _lexicographicPermutation;

        public Problem024()
        {
            Digits =
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem024Key]
                    .Collection[ProjectEulerConstants.Problem024DigitsKey]
                    .ToList<int>();
            LexicographicPermutation = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem024Key]
                    .Collection[ProjectEulerConstants.Problem024LexicographicPermutationKey]);
        }

        public Problem024(
            List<int> digits,
            int lexicographicPermutation)
        {
            Digits = digits;
            LexicographicPermutation = lexicographicPermutation;
        }

        public List<int> Digits { get; set; }

        public int LexicographicPermutation { get; set; }

        public override dynamic Solve()
        {
            var digitCount = Digits.Count;
            var numbers = Digits;
            var remainingPermutations = LexicographicPermutation - 1;

            /*
             * Figure out which number is first in the desired lexicographic permutation.
             * -
             * The last (n-1) digits can be ordered (n-1)! ways which means the first
             * (n-1)! permutations start with the first digit.  The permutations starting
             * from (n-1)!+1 to 2(n-1)! start with the second digit, and so on.
             * -
             * Once the first digit of the desired lexicographic permutation is found
             * we remove it from the list and continue until we exhaust the number of
             * permutations leading up to the desired lexicographic permutation.
             */
            var lexicographicPermutation = new StringBuilder();
            for (var i = 1; i < digitCount; i++)
            {
                // index of number in ordered digits
                var index = remainingPermutations / (digitCount - i).CalculateFactorial();

                // remaining permutations
                remainingPermutations = (int)(remainingPermutations % (digitCount - i).CalculateFactorial());

                // append number from digits list
                lexicographicPermutation.Append(numbers.ElementAt((int)index));

                // remove appended number from digits list
                numbers.RemoveAt((int)index);

                // done
                if (remainingPermutations == 0)
                {
                    break;
                }
            }

            // append the remaining numbers in digits list that did not contribute
            for (var i = 0; i < numbers.Count; i++)
            {
                lexicographicPermutation.Append(numbers.ElementAt(i));
            }

            _lexicographicPermutation = lexicographicPermutation.ToString();
            return _lexicographicPermutation;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The [" +
                LexicographicPermutation +
                LexicographicPermutation
                    .ToString()
                    .Substring(LexicographicPermutation.ToString().Length - 1, 1)
                    .ToOrdinalSuffix() +
                "] lexicographic permutation of the digits [" +
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem024Key]
                    .Collection[ProjectEulerConstants.Problem024DigitsKey] +
                "] is [" +
                _lexicographicPermutation +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
