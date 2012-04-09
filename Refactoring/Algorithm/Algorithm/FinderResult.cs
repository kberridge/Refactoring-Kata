using System;

namespace Algorithm
{
    public class FinderResult
    {
        public Person Younger { get; set; }
        public Person Older { get; set; }
        public TimeSpan BirthDateDifference { get; set; }
    }
}