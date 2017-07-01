// <copyright file="Problem013.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections;
using System.Numerics;
using Common.Framework.Core.Enums;
using Common.Framework.Core.Logging;
using Common.Framework.Data.Managers;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Large sum
    /// -
    /// Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
    /// </summary>
    public class Problem013 : Problem
    {
        private string[] _number;

        private BigInteger _largeSum;

        public Problem013()
        {
            Digits = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem013Key]
                    .Collection[ProjectEulerConstants.Problem013DigitsKey]);
            Source = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem013Key]
                .Collection[ProjectEulerConstants.Problem013SourceKey];
        }

        public Problem013(
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
                CollectionType.Array1D,
                DelimiterType.None,
                Source);
            _number = flatFileDataManager.Input;
            for (var i = 0; i < ((ICollection)_number).Count; i++)
            {
                _largeSum += BigInteger.Parse(_number[i]);
            }

            return _largeSum.ToString().Substring(0, Digits);
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The first [" +
                Digits +
                "] digits of the sum of the [" +
                _number.Length +
                "] [" +
                _number[0].Length +
                "]-digit numbers [" +
                Source +
                "] is [" +
                _largeSum.ToString().Substring(0, Digits) +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
