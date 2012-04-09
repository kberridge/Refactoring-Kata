using System.Collections.Generic;

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

            FinderResult answer = tr[0];
            foreach(var result in tr)
            {
                switch(matchMethod)
                {
                    case DateMatch.Closest:
                        if(result.BirthDateDifference < answer.BirthDateDifference)
                        {
                            answer = result;
                        }
                        break;

                    case DateMatch.Furthest:
                        if(result.BirthDateDifference > answer.BirthDateDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}