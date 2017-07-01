// <copyright file="Problem003.cs">
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
    /// Largest prime factor
    /// -
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143?
    /// </summary>
    public class Problem003 : Problem
    {
        private long _largestPrimeFactor;

        public Problem003()
        {
            Number = Convert.ToInt64(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem003Key]
                    .Collection[ProjectEulerConstants.Problem003NumberKey]);
        }

        public Problem003(long number)
        {
            Number = number;
        }

        public long Number { get; set; }

        public override dynamic Solve()
        {
            _largestPrimeFactor = Number.CalculateLargestPrimeFactor();

            return _largestPrimeFactor;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The largest prime factor of the number [" +
                Number +
                "] is [" +
                _largestPrimeFactor +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
