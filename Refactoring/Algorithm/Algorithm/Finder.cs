using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> p)
        {
            _people = p;
        }

        public FinderResult Find(DateMatch matchMethod)
        {
          if (_people.Count < 2) return FinderResult.None;

            var allDateDiffs = GetAllDateDiffs();
            if (matchMethod == DateMatch.Closest)
              return allDateDiffs.OrderBy(d => d.BirthDateDifference).First();
            else
              return allDateDiffs.OrderByDescending(d => d.BirthDateDifference).First();
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