// <copyright file="Problem020.cs">
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
    /// Factorial digit sum
    /// -
    /// n! means n × (n − 1) × ... × 3 × 2 × 1
    /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    /// Find the sum of the digits in the number 100!
    /// </summary>
    public class Problem020 : Problem
    {
        private int _sumOfDigits;

        public Problem020()
        {
            Number = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem020Key]
                    .Collection[ProjectEulerConstants.Problem020NumberKey]);
        }

        public Problem020(int number)
        {
            Number = number;
        }

        public int Number { get; set; }

        public override dynamic Solve()
        {
            var factorial = Number.CalculateFactorial();

            while (factorial > 0)
            {
                _sumOfDigits += (int)(factorial % 10);
                factorial /= 10;
            }

            return _sumOfDigits;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The sum of the digits in the number [" +
                Number +
                "!] is [" +
                _sumOfDigits +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
