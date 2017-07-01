// <copyright file="Problem009.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Collections.Custom;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Special Pythagorean triplet
    /// -
    /// A Pythagorean triplet is a set of three natural numbers, a &lt; b &lt; c, for which, a^2 + b^2 = c^2
    /// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product a * b * c.
    /// </summary>
    public class Problem009 : Problem
    {
        private int _pythagoreanTripletProduct;

        public Problem009()
        {
            Sum = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem009Key]
                    .Collection[ProjectEulerConstants.Problem009SumKey]);
        }

        public Problem009(int sum)
        {
            Sum = sum;
        }

        public int Sum { get; set; }

        public override dynamic Solve()
        {
            var limit = (int)Math.Ceiling((decimal)(Sum / 2d)) - 1;

            for (var m = 2; m <= limit; m++)
            {
                // found m
                if ((Sum / 2) % m != 0)
                {
                    continue;
                }

                // ensure k is odd
                int k;
                if (m % 2 == 0)
                {
                    k = m + 1;
                }
                else
                {
                    k = m + 2;
                }

                while (k < 2 * m && k <= Sum / (2 * m))
                {
                    var pair = new Pair<int>(k, m);
                    if ((((Sum / 2) * m) % k == 0) && (pair.CalculateGreatestCommonDivisor() == 1))
                    {
                        var d = Sum / (2 * k * m);
                        var n = k - m;
                        var a = ((m * m) - (n * n)) * d;
                        var b = 2 * m * n * d;
                        var c = ((m * m) + (n * n)) * d;
                        _pythagoreanTripletProduct = a * b * c;
                        break;
                    }

                    k += 2;
                }
            }

            return _pythagoreanTripletProduct;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The product abc resulting from the one Pythagorean triplet satisfying a + b + c = [" +
                Sum +
                "] is [" +
                _pythagoreanTripletProduct +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
