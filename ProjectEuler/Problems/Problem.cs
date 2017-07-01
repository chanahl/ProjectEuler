// <copyright file="Problem.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.IO;
using Common.Framework.Core;
using Common.Framework.Core.AppConfig;

namespace ProjectEuler.Problems
{
    public abstract class Problem
    {
        public static readonly AppConfigParameters AppConfigParameters =
            AppConfigManager.Instance().Property.AppConfigParameters;

        protected Problem()
        {
            Name = GetType().Name;
        }

        public string Name { get; set; }

        public string ResultMessage { get; set; }

        public void Run()
        {
            Solve();
            LogResult();
            WriteResult();
        }

        public abstract dynamic Solve();

        protected abstract void LogResult();

        private void WriteResult()
        {
            var logDateTime = DateTime.Now.ToString(Constants.DateFormatIso8601);
            var targetDirectory = Path.Combine(AppConfigManager.Instance().Property.AppConfigCore.TargetDirectory, logDateTime);
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            var resultFile = Path.Combine(targetDirectory, Name + ".txt");
            using (var streamWriter = new StreamWriter(resultFile))
            {
                streamWriter.WriteLine(ResultMessage);
                streamWriter.Close();
            }
        }
    }
}