// <copyright file="Problem022.cs">
//     Copyright (c) 2017 All rights reserved.
// </copyright>
// <clrversion>4.0.30319.42000</clrversion>
// <author>Alex H.-L. Chan</author>

using System;
using System.Linq;
using System.Text;
using Common.Framework.Core.Enums;
using Common.Framework.Core.Logging;
using Common.Framework.Data.Managers;

namespace ProjectEuler.Problems
{
    /// <summary>
    /// Name scores
    /// -
    /// Using names.txt (right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
    /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
    /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938-th name in the list.
    /// So, COLIN would obtain a score of 938 × 53 = 49714.
    /// What is the total of all the name scores in the file?
    /// </summary>
    public class Problem022 : Problem
    {
        private int _nameScore;

        public Problem022()
        {
            Source = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem022Key]
                .Collection[ProjectEulerConstants.Problem022SourceKey];
            Name = AppConfigParameters
                .Keys[ProjectEulerConstants.Problem022Key]
                .Collection[ProjectEulerConstants.Problem022NameKey];
        }

        public Problem022(
            string source,
            string name)
        {
            Source = source;
            Name = name;
        }

        public string Source { get; set; }

        public new string Name { get; set; }

        public override dynamic Solve()
        {
            var flatFileDataManager = new FlatFileDataManager(
                BuiltInType.String,
                CollectionType.List,
                DelimiterType.Comma,
                Source);
            var names = flatFileDataManager.Input;

            // Sort alphabetically.
            names.Sort();

            // Remove backslash \ escape character.
            for (var i = 0; i < names.Count; i++)
            {
                names[i] = names[i].Replace("\"", string.Empty);
            }

            // Name is given.
            int index;
            byte[] alphabeticalPosition;

            // All names or single name.
            if (Name.ToUpper() == "ALL")
            {
                for (var i = 0; i < names.Count; i++)
                {
                    index = i + 1;
                    alphabeticalPosition = Encoding.ASCII.GetBytes(names[i]);
                    _nameScore += index * alphabeticalPosition.Sum(b => (Convert.ToInt32(b) - 64));
                }
            }
            else
            {
                index = names.IndexOf(Name) + 1;
                alphabeticalPosition = Encoding.ASCII.GetBytes(Name);
                _nameScore += index * alphabeticalPosition.Sum(b => (Convert.ToInt32(b) - 64));
            }

            return _nameScore;
        }

        protected override void LogResult()
        {
            var messageType =
                Name.ToUpper().Equals("ALL")
                    ? "of " + Name.ToLower() + " the name scores"
                    : "score of the name " + Name;
            ResultMessage =
                "The total " +
                messageType +
                " in the file [" +
                Source +
                "] is [" +
                _nameScore +
                "].";
            LogManager.Instance().LogResultMessage(ResultMessage);
        }
    }
}
