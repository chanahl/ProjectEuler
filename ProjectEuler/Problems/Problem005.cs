// <copyright file="Problem005.cs">
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
    /// Smallest multiple
    /// -
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    public class Problem005 : Problem
    {
        private int _smallestPositiveNumber;

        public Problem005()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem005Key]
                    .Collection[ProjectEulerConstants.Problem005LimitKey]);
        }

        public Problem005(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }

        public override dynamic Solve()
        {
            var primes =
                PrimeNumbers.GetPrimes(
                    Limit,
                    PrimeNumbers.PrimesByTrialDivision);
            _smallestPositiveNumber = 1;
            foreach (var p in primes)
            {
                // a = log( k ) / log ( p )
                var a = (int)Math.Floor(Math.Log(Limit) / Math.Log(p));

                // Result is then from prime factorization: N = \prod_{i} p[i]^a[i].
                _smallestPositiveNumber = _smallestPositiveNumber * (int)Math.Pow(p, a);
            }

            return _smallestPositiveNumber;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The smallest positive number that is evenly divisible by all of the numbers from " +
                "1 to [" +
                Limit +
                "] is [" +
                _smallestPositiveNumber +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
