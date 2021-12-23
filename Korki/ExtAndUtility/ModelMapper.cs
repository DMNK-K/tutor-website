using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using KorkiDataAccessLib.Models;
using KorkiDataAccessLib.Access;

namespace Korki.ExtAndUtility
{
    /// <summary>
    /// Class providing functionality for mapping models retrieved from data access layer
    /// to their respective app-layer counterpart models and vice versa.
    /// Models from data access layer end with Data, eg Tutor <=> TutorData,
    /// this is for clarity.
    /// </summary>
    public static class ModelMapper
    {
        public static List<Tutor> MapTutors(List<TutorData> list)
        {
            if (list == null) { return null; }
            List<Tutor> result = new List<Tutor>(list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == null) { continue; }
                Tutor tutor = MapTutor(list[i]);
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

        public static Tutor MapTutor(TutorData source)
        {
            if (source == null) { return null; }
            Tutor result = new Models.Tutor(source.NameFirst, source.NameLast, source.NameFormal, source.UsesFormalName)
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

        public static TutorFilters Map(this BasicSearchTerms source, int minRating, bool skipNonRated, bool requirePriceInfo, int tutoringPlace)
        {
            return new TutorFilters(source.Name, source.City, (int)source.Level, minRating, skipNonRated, requirePriceInfo, tutoringPlace);
        }

        public static UserData Map(this User user)
        {
            return new UserData()
            {
                ID = user.ID,
                IsTutor = user.IsTutor,
                Email = user.Email,
                EmailHash = user.Email,
                Username = user.UserName,
                PasswordHash = user.PasswordHash,
                JoinDateTime = user.JoinDateTime,
                IsDeleted = user.IsDeleted,
                DeletionInfo = user.DeletionInfo,
                IsSuspended = user.IsSuspended,
                SuspentionInfo = user.SuspentionInfo,
                SuspentionDateTime = user.SuspentionDateTime,
                SuspentionAutoEnd = user.SuspentionAutoEnd,
                IsShowcase = user.IsShowcase,
                AccessFailedCount = user.AccessFailedCount
            };
        }

        public static User Map(this UserData userData)
        {
            return new User()
            { 
                ID = userData.ID,
                IsTutor = userData.IsTutor,
                Email = userData.Email,
                EmailHash = userData.Email,
                UserName = userData.Username,
                PasswordHash = userData.PasswordHash,
                JoinDateTime = userData.JoinDateTime,
                IsDeleted = userData.IsDeleted,
                DeletionInfo = userData.DeletionInfo,
                IsSuspended = userData.IsSuspended,
                SuspentionInfo = userData.SuspentionInfo,
                SuspentionDateTime = userData.SuspentionDateTime,
                SuspentionAutoEnd = userData.SuspentionAutoEnd,
                IsShowcase = userData.IsShowcase,
                AccessFailedCount = userData.AccessFailedCount
            };

        }
    }
}
