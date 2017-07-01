// <copyright file="Problem011.cs">
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
    /// Largest product in a grid
    /// -
    /// In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
    /// What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
    /// </summary>
    public class Problem011 : Problem
    {
        private int[,] _grid;

        private long _largestProductInGrid;

        public Problem011()
        {
            AdjacentNumbers = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem011Key]
                    .Collection[ProjectEulerConstants.Problem011AdjacentNumbersKey]);
            Source = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem011Key]
                .Collection[ProjectEulerConstants.Problem011SourceKey];
        }

        public Problem011(
            int adjacentNumbers,
            string source)
        {
            AdjacentNumbers = adjacentNumbers;
            Source = source;
        }

        public int AdjacentNumbers { get; set; }

        public string Source { get; set; }

        public override dynamic Solve()
        {
            var flatFileDataManager = new FlatFileDataManager(
                BuiltInType.Integer,
                CollectionType.Array2D,
                DelimiterType.Space,
                Source);
            _grid = flatFileDataManager.Input;

            Calculate(_grid);

            return _largestProductInGrid;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The largest product of [" +
                AdjacentNumbers +
                "] adjacent numbers in the same direction (up, down, left, right or diagonally) in the [" +
                _grid.GetLength(0) +
                "]x[" +
                _grid.GetLength(1) +
                "] grid [" +
                Source +
                "] is [" +
                _largestProductInGrid +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }

        private void Calculate(int[,] a)
        {
            var rowBoundary = a.GetLength(0);
            var colBoundary = a.GetLength(1);

            for (var row = 0; row < a.GetLength(0); row++)
            {
                for (var col = 0; col < a.GetLength(1); col++)
                {
                    long tempProd;

                    // Horizontally.
                    if (col < colBoundary - AdjacentNumbers)
                    {
                        tempProd = a[row, col];
                        for (var i = 1; i < AdjacentNumbers; i++)
                        {
                            tempProd *= a[row, col + i];
                        }

                        _largestProductInGrid = Math.Max(_largestProductInGrid, tempProd);
                    }

                    // Vertically.
                    if (row < rowBoundary - AdjacentNumbers)
                    {
                        tempProd = a[row, col];
                        for (var i = 1; i < AdjacentNumbers; i++)
                        {
                            tempProd *= a[row + i, col];
                        }

                        _largestProductInGrid = Math.Max(_largestProductInGrid, tempProd);
                    }

                    // Diagonally (left to right).
                    if ((row < rowBoundary - AdjacentNumbers) && (col < colBoundary - AdjacentNumbers))
                    {
                        tempProd = a[row, col];
                        for (var i = 1; i < AdjacentNumbers; i++)
                        {
                            tempProd *= a[row + i, col + i];
                        }

                        _largestProductInGrid = Math.Max(_largestProductInGrid, tempProd);
                    }

                    // Diagonally (right to left).
                    if ((row < rowBoundary - AdjacentNumbers) && (col >= AdjacentNumbers - 1))
                    {
                        tempProd = a[row, col];
                        for (var i = 1; i < AdjacentNumbers; i++)
                        {
                            tempProd *= a[row + i, col - i];
                        }

                        _largestProductInGrid = Math.Max(_largestProductInGrid, tempProd);
                    }
                }
            }
        }
    }
}
