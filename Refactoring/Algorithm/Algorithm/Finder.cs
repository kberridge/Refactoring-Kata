using System.Collections.Generic;
using System.Linq;
using System;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> p)
        {
            _people = p;
        }

        public FinderResult FindBornClosest()
        {
          return Find(diffs => diffs.OrderBy(d => d.BirthDateDifference));
        }

        public FinderResult FindBornFurthest()
        {
          return Find(diffs => diffs.OrderByDescending(d => d.BirthDateDifference));
        }

        FinderResult Find(Func<IEnumerable<FinderResult>, IEnumerable<FinderResult>> order)
        {
          if (_people.Count < 2) return FinderResult.None;
          var allDateDiffs = GetAllDateDiffs();
          return order(allDateDiffs).First();
        }

        IEnumerable<FinderResult> GetAllDateDiffs()
        {
            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    if (_people[i].BirthDate < _people[j].BirthDate)
                      yield return new FinderResult(_people[i], _people[j]);
                    else
                      yield return new FinderResult(_people[j], _people[i]);
                }
            }
        }
    }
}