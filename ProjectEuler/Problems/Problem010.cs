// <copyright file="Problem010.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Summation of primes
    /// -
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    /// </summary>
    public class Problem010 : Problem
    {
        private long _sumOfPrimes;

        public Problem010()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem010Key]
                    .Collection[ProjectEulerConstants.Problem010LimitKey]);
        }

        public Problem010(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }

        public override dynamic Solve()
        {
            var primes = PrimeNumbers.GetPrimes(
                PrimeNumbers.SieveLimit(Limit),
                PrimeNumbers.PrimesBySieveOfAtkin);

            var i = 0;
            while (primes[i] < Limit)
            {
                _sumOfPrimes += primes[i];
                i++;
            }

            return _sumOfPrimes;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The sum of all primes below [" +
                Limit +
                "] is [" +
                _sumOfPrimes +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
