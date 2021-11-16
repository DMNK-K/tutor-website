using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Models
{
    public class Tutor
    {
        public static int MinRatingCount { get; } = 3;

        public string NameFirst { get; private set; }
        public string NameLast { get; private set; }
        public string FormalName { get; private set; }
        public bool UsesFormalName { get; private set; }
        public string DisplayName => (UsesFormalName) ? FormalName : NameFirst + " " + NameLast;

        public string Desc { get; set; }

        public string CityName { get; set; }

        public Dictionary<string, List<TeachingLevel>> Subjects { get; private set; } = new Dictionary<string, List<TeachingLevel>>();

        public int RatingSum { get; private set; } = 0;
        public int RatingCount { get; private set; } = 0;
        public float RatingAvg => (RatingCount == 0) ? 0 : RatingSum * 1f / RatingCount;
        public string RatingAvgStr => (RatingCount == 0) ? "" : (RatingSum / RatingCount).ToString("F1");
    }
}

public enum TeachingLevel
{
    OneToFour,
    FiveToEight,
    SecondaryEdu,
    HigherEdu,
}