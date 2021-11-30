using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class TutorFiltersAdv
    {
        public int MinRating { get; } = 0;
        public int MaxPrice { get; } = int.MaxValue;
        public bool SkipNonRated { get; } = false;
        public int TutoringPlace { get; } = 0;

        public TutorFiltersAdv(int minRating, bool skip)
        {
            MinRating = minRating;
            SkipNonRated = skip;
        }

        public TutorFiltersAdv(int minRating, int maxPrice, bool skip, int tutoringPlace = 0)
        {
            MinRating = minRating;
            MaxPrice = maxPrice;
            SkipNonRated = skip;
            TutoringPlace = tutoringPlace;
        }
    }
}

