// <copyright file="Problem019.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using Common.Framework.Core;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Counting Sundays
    /// -
    /// You are given the following information, but you may prefer to do some research for yourself.
    /// 1 Jan 1900 was a Monday.
    /// Thirty days has September,
    /// April, June and November.
    /// All the rest have thirty-one,
    /// Saving February alone,
    /// Which has twenty-eight, rain or shine.
    /// And on leap years, twenty-nine.
    /// A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    /// </summary>
    public class Problem019 : Problem
    {
        private int _numberOfDays;

        public Problem019()
        {
            StartDate = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem019Key]
                .Collection[ProjectEulerConstants.Problem019StartDateKey]
                .NewDateTime(Constants.DateFormatIso8601);
            EndDate = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem019Key]
                .Collection[ProjectEulerConstants.Problem019EndDateKey]
                .NewDateTime(Constants.DateFormatIso8601);
            DayOfMonth = Convert.ToInt32(
                AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem019Key]
                    .Collection[ProjectEulerConstants.Problem019DayOfMonthKey]);
            DayOfWeek = AppConfigParameters
                    .Keys[ProjectEulerConstants.Problem019Key]
                    .Collection[ProjectEulerConstants.Problem019DayOfWeekKey];
        }

        public Problem019(
            DateTime startDate,
            DateTime endDate,
            int dayOfMonth,
            string dayOfWeek)
        {
            StartDate = startDate;
            EndDate = endDate;
            DayOfMonth = dayOfMonth;
            DayOfWeek = dayOfWeek;
        }

        public static DateTime StartDate { get; set; }

        public static DateTime EndDate { get; set; }

        public static int DayOfMonth { get; set; }

        public static string DayOfWeek { get; set; }

        public override dynamic Solve()
        {
            var dateTime = StartDate;
            while (dateTime <= EndDate)
            {
                if (dateTime.DayOfWeek.ToString() == DayOfWeek && dateTime.Day == DayOfMonth)
                {
                    _numberOfDays++;
                }

                dateTime = dateTime.AddDays(1);
            }

            return _numberOfDays;
        }

        protected override void LogResult()
        {
            ResultMessage =
                "The number of [" +
                DayOfWeek +
                "]s that fell on the [" +
                DayOfMonth +
                DayOfMonth.ToString().ToOrdinalSuffix() +
                "] of the month between [" +
                StartDate.ToString(Constants.DateFormatGregorian) +
                "] and [" +
                EndDate.ToString(Constants.DateFormatGregorian) +
                "] is [" +
                _numberOfDays +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
