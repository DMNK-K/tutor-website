using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class TutorFilters
    {
        //basic filters
        public string NameStr { get; private set; } = "";
        public string NameFirst { get; private set; } = "";
        public string NameLast { get; private set; } = "";
        public string City { get; private set; } = "";
        public int Lvl { get; private set; }

        public bool IsAdvanced { get; }

        //advanced filters
        public int MinRating { get; } = 0;
        public bool RequirePriceInfo { get; } = false;
        public bool SkipNonRated { get; } = false;
        public int TutoringPlace { get; } = 0;
        public int MinRatingCount => TutorData.MinRatingCount;

        public static string DefaultCity => "Warszawa";

        public TutorFilters()
        {
            IsAdvanced = false;

            NameStr = "";
            City = DefaultCity;
            Lvl = 0;
        }

        public TutorFilters(string nameStr, string city, int lvl)
        {
            IsAdvanced = false;
            SetBasicFilters(nameStr, city, lvl);
        }

        public TutorFilters(string nameStr, string city, int lvl, int minRating, bool skip)
        {
            IsAdvanced = true;
            SetBasicFilters(nameStr, city, lvl);

            MinRating = Math.Clamp(minRating, 0, 5);
            SkipNonRated = skip;
        }

        public TutorFilters(string nameStr, string city, int lvl, int minRating, bool skip, bool requirePriceInfo, int tutoringPlace = 0)
        {
            IsAdvanced = true;
            SetBasicFilters(nameStr, city, lvl);

            MinRating = Math.Clamp(minRating, 0, 5);
            SkipNonRated = skip;
            RequirePriceInfo = requirePriceInfo;
            TutoringPlace = tutoringPlace;
        }

        void SetBasicFilters(string nameStr, string city, int lvl)
        {
            NameStr = (string.IsNullOrWhiteSpace(nameStr)) ? "" : nameStr;
            City = city;
            Lvl = lvl;

            CalcSpecificNames();
        }

        void CalcSpecificNames()
        {
            string[] arr = NameStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 1)
            {
                NameLast = arr[0];
                NameFirst = arr[0];
            }
            else if (arr.Length == 2)
            {
                NameFirst = arr[0];
                NameLast = arr[1];
            }
        }
    }
}
