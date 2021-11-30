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
    /// Class providing functionality (in the form of extension methods)
    /// for mapping models retrieved from data access layer
    /// to their respective app-layer counterpart models and vice versa.
    /// </summary>
    public static class ModelMapping
    {
        public static List<Models.Tutor> Map(this List<Tutor> list)
        {
            if(list == null) { return null; }
            List<Models.Tutor> result = new List<Models.Tutor>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                Models.Tutor tutor = list[i].Map();
                if (tutor != null)
                {
                    result.Add(tutor);
                }
            }
            return result;
        }

        public static Models.Tutor Map(this Tutor source)
        {
            if (source == null) { return null; }
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
            };
            return result;
        }

        public static TutorFiltersBasic Map(this BasicSearchTerms source)
        {
            return new TutorFiltersBasic(source.Name, source.City, (int)source.Level);
        }
    }
}
