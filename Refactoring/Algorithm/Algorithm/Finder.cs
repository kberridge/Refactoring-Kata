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
            if (_people.Count < 2) return new FinderResult();

            var allDateDiffs = GetAllDateDiffs();
            if (matchMethod == DateMatch.Closest)
              return allDateDiffs.OrderBy(d => d.BirthDateDifference).First();
            else
              return allDateDiffs.OrderByDescending(d => d.BirthDateDifference).First();
        }

        List<FinderResult> GetAllDateDiffs()
        {
            var tr = new List<FinderResult>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var r = new FinderResult();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        r.Younger = _people[i];
                        r.Older = _people[j];
                    }
                    else
                    {
                        r.Younger = _people[j];
                        r.Older = _people[i];
                    }
                    r.BirthDateDifference = r.Older.BirthDate - r.Younger.BirthDate;
                    tr.Add(r);
                }
            }

            return tr;
        }
    }
}