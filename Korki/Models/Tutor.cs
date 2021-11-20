using Korki.ExtAndUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Models
{
    public class Tutor
    {
        public static int MinRatingCount { get; } = 3;

        public int TID { get; set; } = -1;
        public string NameFirst { get; private set; }
        public string NameLast { get; private set; }
        public string FormalName { get; private set; }
        public bool UsesFormalName { get; private set; }
        public string DisplayName => (UsesFormalName) ? FormalName : NameFirst + " " + NameLast;

        public string PriceText { get; set; } = "";
        public string Desc { get; set; } = "";
        public string BonusInfo { get; set; } = "";

        public string CityName { get; set; } = "";
        public int RangeIncrement { get; set; } = 0;
        public bool GoesToClient { get; set; } = true;
        public bool ProvidesNearCity => GoesToClient && RangeIncrement > 0;

        public Dictionary<string, List<TeachingLevel>> Subjects { get; private set; } = new Dictionary<string, List<TeachingLevel>>();

        public int RatingSum { get; set; } = 0;
        public int RatingCount { get; set; } = 0;
        public float RatingAvg => (RatingCount == 0) ? 0 : RatingSum * 1f / RatingCount;
        public string RatingAvgStr => (RatingCount == 0) ? "" : (RatingSum / RatingCount).ToString("F1");

        public Tutor(string firstName, string lastName, string formalName, bool usesFormalName)
        {
            NameFirst = firstName;
            NameLast = lastName;
            FormalName = formalName;
            UsesFormalName = usesFormalName;
        }

        public static Tutor GetSampleTutor()
        {

            Tutor t = (Rand.Chance(50)) ? new Tutor("Przemysław", "Przykładowy", "", false) : new Tutor("Marlena", "Pokazowa", "", false);
            t.Desc = "";
            t.CityName = "Warszawa";
            t.RatingCount = Rand.Range(1, 350);
            t.RatingSum = (int)Math.Round(t.RatingCount * Rand.Range(2f, 5f), MidpointRounding.AwayFromZero);
            return t;
        }
    }
}

public enum TeachingLevel
{
    //set the numbers explicitely:
    OneToThree = 0,
    FourToSix = 1,
    SevenEight = 2,
    SecondaryEdu = 3,
    HigherEdu = 4,
}