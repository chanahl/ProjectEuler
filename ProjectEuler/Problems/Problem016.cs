// <copyright file="Problem016.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Numerics;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Power digit sum
    /// -
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// What is the sum of the digits of the number 2^1000?
    /// </summary>
    public class Problem016 : Problem
    {
        private BigInteger _sumOfDigits;

        public Problem016()
        {
            Radix = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem016Key]
                    .Collection[ProjectEulerConstants.Problem016RadixKey]);
            Power = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem016Key]
                    .Collection[ProjectEulerConstants.Problem016PowerKey]);
            Modulo = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem016Key]
                    .Collection[ProjectEulerConstants.Problem016ModuloKey]);
        }

        public Problem016(
            int radix,
            int power,
            int modulo)
        {
            Radix = radix;
            Power = power;
            Modulo = modulo;
        }

        public int Radix { get; set; }

        public int Power { get; set; }

        public int Modulo { get; set; }

        public override dynamic Solve()
        {
            // convert power to binary representation
            var powerInBinary = Power.ToBinary();

            // use method of successive squaring to compute b^n
            var exponentiation = Exponentiation.Binary(Radix, powerInBinary, Modulo);

            var digits = exponentiation.ToString();
            for (var i = 0; i < digits.Length; i++)
            {
                _sumOfDigits += BigInteger.Parse(digits.Substring(i, 1));
            }

            return _sumOfDigits;
        }

        protected override void LogResult()
        {
            var moduloMessage = (Modulo == 0) ? string.Empty : " mod " + Modulo;
            ResultMessage =
                "The sum of the digits of the number [" +
                Radix +
                "^" +
                Power +
                moduloMessage +
                "] is [" +
                _sumOfDigits +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
