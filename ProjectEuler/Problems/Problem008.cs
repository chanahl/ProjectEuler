// <copyright file="Problem008.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core.Enums;
using Common.Framework.Core.Logging;
using Common.Framework.Data.Managers;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Largest product in a series
    /// -
    /// The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
    /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
    /// </summary>
    public class Problem008 : Problem
    {
        private long _largestProduct;

        public Problem008()
        {
            Digits = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem008Key]
                    .Collection[ProjectEulerConstants.Problem008DigitsKey]);
            Source = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem008Key]
                .Collection[ProjectEulerConstants.Problem008SourceKey];
        }

        public Problem008(
            int digits,
            string source)
        {
            Digits = digits;
            Source = source;
        }

        public int Digits { get; set; }

        public string Source { get; set; }

        public override dynamic Solve()
        {
            var flatFileDataManager = new FlatFileDataManager(
                BuiltInType.String,
                CollectionType.NonCollection,
                DelimiterType.None,
                Source);
            var number = flatFileDataManager.Input;
            for (var i = 0; i < number.Length - Digits; i++)
            {
                var subset = number.Substring(i, Digits).ToCharArray();

                long product = 1;
                foreach (char c in subset)
                {
                    product *= (long)char.GetNumericValue(c);
                }

                if (product > _largestProduct)
                {
                    _largestProduct = product;
                }
            }

            return _largestProduct;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The largest product of [" +
                Digits +
                "] adjacent digits in the [" +
                Source.Length +
                "]-digit number [" +
                Source +
                "] is [" +
                _largestProduct +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
