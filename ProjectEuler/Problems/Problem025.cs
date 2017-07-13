// <copyright file="Problem025.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// 1000-digit Fibonacci number
    /// -
    /// The Fibonacci sequence is defined by the recurrence relation:
    /// F(n) = F(n−1) + F(n−2), where F1 = 1 and F2 = 1.
    /// Hence the first 12 terms will be:
    /// F1 = 1
    /// F2 = 1
    /// F3 = 2
    /// F4 = 3
    /// F5 = 5
    /// F6 = 8
    /// F7 = 13
    /// F8 = 21
    /// F9 = 34
    /// F10 = 55
    /// F11 = 89
    /// F12 = 144
    /// The 12-th term, F12, is the first term to contain three digits.
    /// What is the first term in the Fibonacci sequence to contain 1000 digits?
    /// </summary>
    public class Problem025 : Problem
    {
        private List<BigInteger> _fibonnaciNumbers;

        public Problem025()
        {
            Term = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem025Key]
                    .Collection[ProjectEulerConstants.Problem025TermKey]);
            Digits = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem025Key]
                    .Collection[ProjectEulerConstants.Problem025DigitsKey]);
        }

        public Problem025(
            int term,
            int digits)
        {
            Term = term;
            Digits = digits;
        }

        public int Term { get; set; }

        public int Digits { get; set; }

        public override dynamic Solve()
        {
            _fibonnaciNumbers = new List<BigInteger> { 1, 1 };
            var digitCount = 1;
            var termCount = 0;

            while (digitCount <= Digits && termCount < Term)
            {
                var fnm1 = _fibonnaciNumbers.Last();
                var fnm2 = _fibonnaciNumbers[_fibonnaciNumbers.Count - 2];
                _fibonnaciNumbers.Add(fnm1 + fnm2);

                digitCount = _fibonnaciNumbers.Last().ToString().Length;
                if (digitCount.Equals(Digits))
                {
                    termCount++;
                }
            }

            return _fibonnaciNumbers.Count;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The [" +
                Term + Term.ToString().ToOrdinalSuffix() +
                "] term in the Fibonacci sequence to contain [" +
                Digits +
                "] digits is [" +
                _fibonnaciNumbers.Count +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
