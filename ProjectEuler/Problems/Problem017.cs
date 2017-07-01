// <copyright file="Problem017.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Number letter counts
    /// -
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
    /// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
    /// The use of "and" when writing out numbers is in compliance with British usage.
    /// </summary>
    public class Problem017 : Problem
    {
        private const int Hundred = 7;
        
        private const int Thousand = 8;

        private static readonly int[] Ones =
        {
            0,  // zero
            3,  // one
            3,  // two
            5,  // three
            4,  // four
            4,  // five
            3,  // six
            5,  // seven
            5,  // eight
            4,  // nine
            3,  // ten
            6,  // eleven
            6,  // twelve
            8,  // thirteen
            8,  // fourteen
            7,  // fifteen
            7,  // sixteen
            9,  // seventeen
            8,  // eighteen
            8   // nineteen
        };

        private static readonly int[] Tens =
        {
            0,  // null
            3,  // ten
            6,  // twenty
            6,  // thirty
            5,  // forty
            5,  // fifty
            5,  // sixty
            7,  // seventy
            6,  // eighty
            6   // ninety
        };

        private int _wordCount;

        public Problem017()
        {
            Limit = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem017Key]
                    .Collection[ProjectEulerConstants.Problem017LimitKey]);
        }

        public Problem017(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }

        public override dynamic Solve()
        {
            for (var i = 1; i <= Limit; i++)
            {
                var onesDigit = i % 10;
                var tensDigit = ((i % 100) - onesDigit) / 10;
                var hundredsDigit = ((i % 1000) - (tensDigit * 10) - onesDigit) / 100;
                var thousandsDigit = ((i % 10000) - (hundredsDigit * 100) - (tensDigit * 10) - onesDigit) / 1000;

                if (thousandsDigit != 0)
                {
                    _wordCount += Ones[1] + Thousand;
                }

                if (hundredsDigit != 0)
                {
                    _wordCount += Hundred + Ones[hundredsDigit];
                    if (tensDigit != 0 || onesDigit != 0)
                    {
                        // "AND"
                        _wordCount += 3;
                    }
                }

                if (tensDigit == 0 || tensDigit == 1)
                {
                    _wordCount += Ones[(tensDigit * 10) + onesDigit];
                }
                else
                {
                    _wordCount += Tens[tensDigit] + Ones[onesDigit];
                }
            }

            return _wordCount;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The numbers from 1 to [" +
                Limit +
                "] inclusive, if written out in words, would require a total number of [" +
                _wordCount +
                "] letters.";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
