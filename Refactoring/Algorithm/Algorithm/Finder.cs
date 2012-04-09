using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _p;

        public Finder(List<Person> p)
        {
            _p = p;
        }

        public F Find(DateMatch ft)
        {
            var tr = new List<F>();

            for(var i = 0; i < _p.Count - 1; i++)
            {
                for(var j = i + 1; j < _p.Count; j++)
                {
                    var r = new F();
                    if(_p[i].BirthDate < _p[j].BirthDate)
                    {
                        r.Person1 = _p[i];
                        r.Person2 = _p[j];
                    }
                    else
                    {
                        r.Person1 = _p[j];
                        r.Person2 = _p[i];
                    }
                    r.D = r.Person2.BirthDate - r.Person1.BirthDate;
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
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case DateMatch.Furthest:
                        if(result.D > answer.D)
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