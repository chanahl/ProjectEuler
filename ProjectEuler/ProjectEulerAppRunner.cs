// <copyright file="ProjectEulerAppRunner.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Collections.Generic;
using Common.Framework.Core.AppConfig;
using Common.Framework.Core.AppRunners;
using Common.Framework.Core.Enums;
using Common.Framework.Core.Extensions;
using Common.Framework.Core.Logging;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal class ProjectEulerAppRunner : ObjectAppRunner
    {
        protected override bool Main()
        {
            try
            {
                RegisterObjects<Problem>(
                    AssemblyType.Entry,
                    "ProjectEuler.Problems",
                    true);
                StartObjects("Run");
            }
            catch (Exception exception)
            {
                LogManager.Instance().LogErrorMessage(exception.Message);
            }

            return true;
        }

        protected override IEnumerable<string> GetCatalogue(
            AssemblyType assemblyType,
            string nameSpace)
        {
            var appConfigParameters = AppConfigManager.Instance().Property.AppConfigParameters;
            var projectEulerProblems = appConfigParameters
                .Keys[ProjectEulerConstants.ProjectEulersProblemsKey]
                .Collection[ProjectEulerConstants.ProblemsKey];

            if (!string.Equals(
                projectEulerProblems,
                ProjectEulerConstants.ProblemsAllKey,
                StringComparison.InvariantCultureIgnoreCase))
            {
                var problems = projectEulerProblems.ToList<string>();
                for (var i = 0; i < problems.Count; i++)
                {
                    problems[i] = "Problem" + problems[i].PadLeft(3, '0');
                }

                return problems;
            }

            return base.GetCatalogue(assemblyType, nameSpace);
        }

        protected override void RegisterObjects<T>(
            AssemblyType assemblyType,
            string nameSpace,
            bool useCollectionName,
            string switchName = null,
            params object[] arguments)
        {
            var classes = GetCatalogue(assemblyType, nameSpace);
            foreach (var problem in classes)
            {
                try
                {
                    var instance = Instantiate<Problem>(assemblyType, problem);
                    RegisterInstance(instance);
                }
                    // ReSharper disable once EmptyGeneralCatchClause
                catch (Exception)
                {
                    // do nothing with exception
                }
            }

            LogObjects();
        }
    }
}