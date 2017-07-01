// <copyright file="Problem006.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Sum square difference
    /// -
    /// The sum of the squares of the first ten natural numbers is, 1^2 + 2^2 + ... + 10^2 = 385
    /// The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)^2 = 552 = 3025
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    public class Problem006 : Problem
    {
        private int _squareSumDifference;

        public Problem006()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem006Key]
                    .Collection[ProjectEulerConstants.Problem006LimitKey]);
        }

        public Problem006(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }
        
        public override dynamic Solve()
        {
            for (var i = 1; i <= Limit; i++)
            {
                for (var j = 1; j <= Limit; j++)
                {
                    // Ignore the sum of squares part.
                    if (i != j)
                    {
                        _squareSumDifference += i * j;
                    }
                }
            }

            return _squareSumDifference;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The difference between the sum of the squares of the first [" +
                Limit +
                "] natural numbers and the square of the sum is [" +
                _squareSumDifference +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
