// <copyright file="ProblemsTest.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using Common.Framework.Core;
using Common.Framework.Core.AppConfig;
using Common.Framework.Core.Extensions;
using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEuler.Test
{
    [TestFixture]
    public class ProblemsTest
    {
        public string ExecutingAssemblyLocation { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            AppConfigManager.Instance().InitializeProperty();
            ExecutingAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Test(ExpectedResult = 233168)]
        public int Problem001()
        {
            var problem = new Problem001(1000, new List<int> { 3, 5 });
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 4613732)]
        public int Problem002()
        {
            var problem = new Problem002(4000000, "even");
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 6857)]
        public long Problem003()
        {
            var problem = new Problem003(600851475143);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 906609)]
        public int Problem004()
        {
            var problem = new Problem004(3);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 232792560)]
        public int Problem005()
        {
            var problem = new Problem005(20);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 25164150)]
        public int Problem006()
        {
            var problem = new Problem006(100);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 104743)]
        public int Problem007()
        {
            var problem = new Problem007(10001);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 23514624000)]
        public long Problem008()
        {
            var problem = new Problem008(13, Path.Combine(ExecutingAssemblyLocation, @"Source\008.dat"));
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 31875000)]
        public int Problem009()
        {
            var problem = new Problem009(1000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 142913828922)]
        public long Problem010()
        {
            var problem = new Problem010(2000000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 70600674)]
        public long Problem011()
        {
            var problem = new Problem011(4, Path.Combine(ExecutingAssemblyLocation, @"Source\011.dat"));
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 76576500)]
        public int Problem012()
        {
            var problem = new Problem012(500, 75000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = "5537376230")]
        public string Problem013()
        {
            var problem = new Problem013(10, Path.Combine(ExecutingAssemblyLocation, @"Source\013.dat"));
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 837799)]
        public long Problem014()
        {
            var problem = new Problem014(1000000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = "137846528820", TestOf = typeof(BigInteger))]
        public string Problem015()
        {
            var problem = new Problem015(20);
            var expected = problem.Solve();
            return expected.ToString();
        }

        [Test(ExpectedResult = "1366", TestOf = typeof(BigInteger))]
        public string Problem016()
        {
            var problem = new Problem016(2, 1000, 0);
            var expected = problem.Solve();
            return expected.ToString();
        }

        [Test(ExpectedResult = 21124)]
        public int Problem017()
        {
            var problem = new Problem017(1000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 1074)]
        public int Problem018()
        {
            var problem = new Problem018(Path.Combine(ExecutingAssemblyLocation, @"Source\018Production.dat"));
            var expected = problem.Solve();
            return expected;
        }
        
        [Test(ExpectedResult = 171)]
        public int Problem019()
        {
            var problem = new Problem019(
                "19010101".NewDateTime(Constants.DateFormatIso8601),
                "20001231".NewDateTime(Constants.DateFormatIso8601),
                1,
                "Sunday");
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 648)]
        public int Problem020()
        {
            var problem = new Problem020(100);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 31626)]
        public int Problem021()
        {
            var problem = new Problem021(10000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 871198282)]
        public int Problem022()
        {
            var problem = new Problem022(Path.Combine(ExecutingAssemblyLocation, @"Source\022.dat"), "ALL");
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 4179871)]
        public int Problem023()
        {
            var problem = new Problem023(28123);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = "2783915460")]
        public string Problem024()
        {
            var problem = new Problem024(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 4782)]
        public int Problem025()
        {
            var problem = new Problem025(1, 1000);
            var expected = problem.Solve();
            return expected;
        }

        [Test(ExpectedResult = 983)]
        public int Problem026()
        {
            var problem = new Problem026(1000);
            var expected = problem.Solve();
            return expected;
        }
    }
}