using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Utility
{
    //all queries use LIKE instead of CONTAINS because of the set-up required for
    //making CONTAINS work (can't create full-text index catalog via VS),
    //but ideally they would use CONTAINS

    public static class DapperQueries
    {
        //this migh look like it can be shortened by using *, but for a couple of these
        //we need to specify different property names so dapper knows how to match
        private static string TutorAndCity => @"
            dbo.Tutor.ID ID,
            dbo.Tutor.UserID UserID,
            dbo.Tutor.NameFirst NameFirst,
            dbo.Tutor.NameLast NameLast,
            dbo.Tutor.NameFormal NameFormal,
            dbo.Tutor.UsesFormalName UsesFormalName,
            dbo.Tutor.GoesToClient GoesToClient,
            dbo.Tutor.Description Description,
            dbo.Tutor.RatingCount RatingCount,
            dbo.Tutor.RatingSum RatingSum,
            dbo.Tutor.InfoPrice InfoPrice,
            dbo.Tutor.InfoBonus InfoBonus,
            dbo.Tutor.CityID CityID,
            dbo.Tutor.ServiceRange ServiceRange,
            dbo.Tutor.Timetable Timetable,
            dbo.Tutor.Operational Operational,
            dbo.Tutor.SubjectsStr SubjectsStr,
            dbo.City.ID CID,
            dbo.City.CityName Name,
            dbo.City.VoivodeshipAlphaIndex VoivodeshipAlphaIndex,
            dbo.City.Powiat Powiat,
            dbo.City.Gmina Gmina
            dbo.City.Lat Lat,
            dbo.City.Long Long,
            ";


        public static string TutorSearchSimple =>
            @$"SELECT {TutorAndCity}

            FROM dbo.Tutor
            INNER JOIN dbo.City 
	        ON dbo.Tutor.CityID = dbo.City.ID

	        WHERE
	        Operational = 1 AND
	        CityName LIKE CONCAT(@city, '%') AND
	        (
		        (UsesFormalName = 1 AND NameFormal LIKE CONCAT('%', @NameStr, '%')) OR
		        NameFirst = @NameFirst OR
		        NameLast LIKE CONCAT('%', @NameLast, '%') OR
		        SubjectsStr LIKE CONCAT('%', @NameStr, '%')
	        );";

        public static string TutorSearchSimpleNoNameStr =>
            @$"SELECT {TutorAndCity}

            FROM dbo.Tutor
            INNER JOIN dbo.City 
	        ON dbo.Tutor.CityID = dbo.City.ID

	        WHERE
	        Operational = 1 AND
	        CityName LIKE CONCAT(@City, '%');";
    }
}
