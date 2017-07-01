// <copyright file="Problem023.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections.Generic;
using System.Linq;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Non-abundant sums
    /// -
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number.
    /// For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
    /// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.
    /// However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// </summary>
    public class Problem023 : Problem
    {
        private int _sumOfPositiveIntegers;

        public Problem023()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem023Key]
                    .Collection[ProjectEulerConstants.Problem023LimitKey]);
        }

        public Problem023(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }

        public override dynamic Solve()
        {
            var abundantNumbers = FindAllAbundantNumbers(Limit);
            var isSumOfTwoAbundantNumbers = FindAllSumOfTwoAbundantNumbers(abundantNumbers).ToList();
            for (var i = 1; i <= Limit; i++)
            {
                if (!isSumOfTwoAbundantNumbers.ElementAt(i))
                {
                    _sumOfPositiveIntegers += i;
                }
            }

            return _sumOfPositiveIntegers;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The sum of all the positive integers no greater than [" +
                Limit +
                "] which cannot be written as the sum of two abundant numbers is [" +
                _sumOfPositiveIntegers +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }

        private static IEnumerable<int> FindAllAbundantNumbers(int limit)
        {
            var abundantNumbers = new List<int>();
            for (var i = 2; i <= limit; i++)
            {
                var properDivisors = i.CalculateProperDivisors();
                if (properDivisors.Sum() > i)
                {
                    abundantNumbers.Add(i);
                }
            }

            return abundantNumbers;
        }

        private IEnumerable<bool> FindAllSumOfTwoAbundantNumbers(IEnumerable<int> abundantNumbers)
        {
            var isSumOfTwoAbundants = Enumerable.Repeat(false, Limit + 1).ToList();
            var numbers = abundantNumbers as IList<int> ?? abundantNumbers.ToList();
            for (var i = 0; i < numbers.Count(); i++)
            {
                for (var j = i; j < numbers.Count(); j++)
                {
                    var sumOfTwoAbundants = numbers.ElementAt(i) + numbers.ElementAt(j);
                    if (sumOfTwoAbundants <= Limit)
                    {
                        isSumOfTwoAbundants[sumOfTwoAbundants] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return isSumOfTwoAbundants;
        }
    }
}
