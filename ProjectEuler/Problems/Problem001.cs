// <copyright file="Problem001.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections.Generic;
using System.Linq;
using Common.Framework.Core.Collections.Custom;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Multiples of 3 and 5
    /// -
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class Problem001 : Problem
    {
        private List<int> _multiples;

        public Problem001()
        {
            Target = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem001Key]
                    .Collection[ProjectEulerConstants.Problem001TargetKey]);
            Divisors = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem001Key]
                .Collection[ProjectEulerConstants.Problem001DivisorsKey]
                .ToList<int>();
        }

        public Problem001(
            int target,
            List<int> divisors)
        {
            Target = target;
            Divisors = divisors;
        }

        public int Target { get; set; }

        public List<int> Divisors { get; set; }

        public override dynamic Solve()
        {
            _multiples = new List<int>();
            foreach (var divisor in Divisors)
            {
                var pair = new Pair<int>(divisor, Target);
                _multiples.AddRange(pair.CalculateMultiples(true));
            }

            _multiples = _multiples.Distinct().ToList();
            return _multiples.Sum();
        }

        protected override void LogResult()
        {
            var sumOfMultiples = _multiples.Sum();
            var numDivisors = Divisors.Count;
            ResultMessage = "The sum of all the multiples of [";
            for (var i = 0; i < numDivisors; i++)
            {
                if (i == 0)
                {
                    ResultMessage += Divisors[i];
                    continue;
                }

                if (numDivisors == 2 || i == (numDivisors - 1))
                {
                    ResultMessage += "] or [";
                }
                else
                {
                    ResultMessage += ", ";
                }

                ResultMessage += Divisors[i];
            }

            ResultMessage += "] below [" + Target + "] is [" + sumOfMultiples + "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}