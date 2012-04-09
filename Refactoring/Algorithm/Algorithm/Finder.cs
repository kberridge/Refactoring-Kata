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

        public F Find(DateMatch ft)
        {
            var tr = new List<F>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var r = new F();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        r.Person1 = _people[i];
                        r.Person2 = _people[j];
                    }
                    else
                    {
                        r.Person1 = _people[j];
                        r.Person2 = _people[i];
                    }
                    r.BirthDateDifference = r.Person2.BirthDate - r.Person1.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new F();
            }

            F answer = tr[0];
            foreach(var result in tr)
            {
                switch(ft)
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