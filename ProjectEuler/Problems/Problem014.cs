// <copyright file="Problem014.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections.Generic;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Longest Collatz sequence
    /// -
    /// The following iterative sequence is defined for the set of positive integers:
    /// n → n/2 (n is even)
    /// n → 3n + 1 (n is odd)
    /// Using the rule above and starting with 13, we generate the following sequence:
    /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.
    /// Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    /// Which starting number, under one million, produces the longest chain?
    /// NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
    public class Problem014 : Problem
    {
        private readonly Dictionary<long, int> _collatzPairs = new Dictionary<long, int>();

        private long _maxCollatzNumber = 1;

        private long _maxCollatzLength = 1;

        public Problem014()
        {
            Limit = Convert.ToInt32(
                   AppConfigParameters
                       .Keys[ProjectEulerConstants.Problem014Key]
                       .Collection[ProjectEulerConstants.Problem014LimitKey]);
        }

        public Problem014(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }

        public override dynamic Solve()
        {
            CalculateCollatzStartingNumber();

            return _maxCollatzNumber;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The longest Collatz sequence that is produced by a starting number under [" +
                Limit +
                "] is [" +
                _maxCollatzNumber +
                "] with a length of [" +
                _maxCollatzLength +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }

        /// <summary>
        /// Calculates the next Collatz sequence number defined by
        /// n even: n = n / 2
        /// n odd:  n = 3n + 1
        /// if n is even: bitwise AND
        /// if even: bitwise CIRCULAR SHIFT RIGHT (divide by 2)
        /// if odd: bitwise CIRCULAR SHIFT LEFT (multiple by 2)
        /// </summary>
        /// <param name="n">Previous Collatz sequence number.</param>
        /// <returns>
        /// Next Collatz sequence number.
        /// </returns>
        private static long NextCollatzSequenceNumber(long n)
        {
            return (n & 1) == 0 ? (n >> 1) : (n << 1) + n + 1;
        }

        private void CalculateCollatzStartingNumber()
        {
            for (var n = 2; n <= Limit; n++)
            {
                var chainLength = GetChainLength(n);
                if (chainLength <= _maxCollatzLength)
                {
                    continue;
                }

                _maxCollatzNumber = n;
                _maxCollatzLength = chainLength;
            }
        }

        private int GetChainLength(long n)
        {
            int chainLength;

            // End of Collatz sequence.
            if (n == 1)
            {
                return 1;
            }

            // Try to get chain length from exising Collatz number cache.
            if (_collatzPairs.TryGetValue(n, out chainLength))
            {
                return chainLength;
            }

            // Next Collatz number in sequence.
            ////long next = ( n & 1 ) == 0 ? ( n >> 1 ) : ( n << 1 ) + n + 1;
            var next = NextCollatzSequenceNumber(n);
            chainLength = GetChainLength(next) + 1;

            // Cache starting Collatz numbers and corresponding sequence length.
            _collatzPairs.Add(n, chainLength);

            return chainLength;
        }
    }
}
