// <copyright file="Problem007.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// 10001st prime
    /// -
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6-th prime is 13.
    /// What is the 10 001st prime number?
    /// </summary>
    public class Problem007 : Problem
    {
        private int _primeNumber;

        public Problem007()
        {
            Index = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem007Key]
                    .Collection[ProjectEulerConstants.Problem007IndexKey]);
        }

        public Problem007(int index)
        {
            Index = index;
        }

        public int Index { get; set; }

        public override dynamic Solve()
        {
            var primes = PrimeNumbers.GetPrimes(
                PrimeNumbers.SieveLimit(Index),
                PrimeNumbers.PrimesBySieveOfAtkin);
            _primeNumber = primes[Index - 1];

            return _primeNumber;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The [" +
                Index +
                Index.ToString().ToOrdinalSuffix() +
                "] prime number is [" +
                _primeNumber +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
