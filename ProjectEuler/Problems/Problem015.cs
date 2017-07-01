// <copyright file="Problem015.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Numerics;
using Common.Framework.Core.Logging;
using ProjectEuler.Mathematics;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Lattice paths
    /// -
    /// Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
    /// Right, right, down, down.
    /// Right, down, right, down.
    /// Right, down, down, right.
    /// Down, right, right, down.
    /// Down, right, down, right.
    /// Down, down, right, right.
    /// How many such routes are there through a 20×20 grid?
    /// </summary>
    public class Problem015 : Problem
    {
        private BigInteger _numberOfRoutes;

        public Problem015()
        {
            Size = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem015Key]
                    .Collection[ProjectEulerConstants.Problem015SizeKey]);
        }

        public Problem015(int size)
        {
            Size = size;
        }

        public int Size { get; set; }

        public override dynamic Solve()
        {
            var n = (2 * Size).CalculateFactorial();
            var k = Size.CalculateFactorial();
            _numberOfRoutes = n / (k * k);

            return _numberOfRoutes;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The number of possible routes that are of length 2n of a [" +
                Size +
                "]x[" +
                Size +
                "] grid is [" +
                _numberOfRoutes +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
