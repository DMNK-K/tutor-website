using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using KorkiDataAccessLib.Models;
using KorkiDataAccessLib.Access;
using Tutor = KorkiDataAccessLib.Models.Tutor;

namespace Korki.ExtAndUtility
{
    /// <summary>
    /// Class providing functionality
    /// for mapping models retrieved from data access layer
    /// to their respective app-layer counterpart models and vice versa.
    /// </summary>
    public static class ModelMapper
    {
        public static List<Models.Tutor> MapTutors(List<Tutor> list)
        {
            if (list == null) { return null; }
            List<Models.Tutor> result = new List<Models.Tutor>(list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null) { continue; }
                Models.Tutor tutor = MapTutor(list[i]);
                result.Add(tutor);
            }

            return result;
        }


        //public static List<Models.Tutor> Map(this List<Tutor> list)
        //{
        //    if(list == null) { return null; }
        //    List<Models.Tutor> result = new List<Models.Tutor>(list.Count);
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i] != null)
        //        {
        //            Models.Tutor tutor = list[i].Map();
        //            result.Add(tutor);
        //        }
        //    }
        //    return result;
        //}

        public static Models.Tutor MapTutor(Tutor source)
        {
            Models.Tutor result = new Models.Tutor(source.NameFirst, source.NameLast, source.NameFormal, source.UsesFormalName)
            {
                TID = source.ID,
                Desc = source.Description,
                PriceText = source.InfoPrice,
                BonusInfo = source.InfoBonus,
                RangeIncrement = source.ServiceRange,
                RatingSum = source.RatingSum,
                RatingCount = source.RatingCount,
                GoesToClient = source.GoesToClient,
                CityName = (source.City != null) ? source.City.Name : "",
            };
            return result;
        }

        //public static Models.Tutor Map(this Tutor source)
        //{
        //    Models.Tutor result = new Models.Tutor(source.NameFirst, source.NameLast, source.NameFormal, source.UsesFormalName)
        //    {
        //        TID = source.ID,
        //        Desc = source.Description,
        //        PriceText = source.InfoPrice,
        //        BonusInfo = source.InfoBonus,
        //        RangeIncrement = source.ServiceRange,
        //        RatingSum = source.RatingSum,
        //        RatingCount = source.RatingCount,
        //        GoesToClient = source.GoesToClient,
        //        CityName = (source.City != null) ? source.City.Name : "",
        //    };
        //    return result;
        //}

        public static TutorFilters Map(this BasicSearchTerms source)
        {
            return new TutorFilters(source.Name, source.City, (int)source.Level);
        }

        public static TutorFilters Map(this BasicSearchTerms source, int minRating, bool skipNonRated)
        {
            return new TutorFilters(source.Name, source.City, (int)source.Level, minRating, skipNonRated);
        }

        public static TutorFilters Map(this BasicSearchTerms source, int minRating, bool skipNonRated, int maxPrice, int tutoringPlace)
        {
            return new TutorFilters(source.Name, source.City, (int)source.Level, minRating, skipNonRated, maxPrice, tutoringPlace);
        }
    }
}
