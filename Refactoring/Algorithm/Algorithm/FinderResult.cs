using System;

namespace Algorithm
{
    public class FinderResult
    {
        public Person Younger { get; private set; }
        public Person Older { get; private set; }
        public TimeSpan BirthDateDifference { get; private set; }

        private FinderResult() { }

        public FinderResult(Person younger, Person older)
        {
          Younger = younger;
          Older = older;
          BirthDateDifference = older.BirthDate - younger.BirthDate;
        }

        static FinderResult none = new FinderResult();
        public static FinderResult None { get { return none; } }
    }
}