using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Data
{
    public class ConstantTexts
    {
        public const string NotEnoughRatings = "Zbyt mało opinii, by wyświetlić jednoznaczną ocenę.";

        private static Dictionary<DayOfWeek, string> dowNames = new Dictionary<DayOfWeek, string>()
        {
            { DayOfWeek.Monday, "Poniedziałek" },
            { DayOfWeek.Tuesday, "Wtorek" },
            { DayOfWeek.Wednesday, "Środa" },
            { DayOfWeek.Thursday, "Czwartek" },
            { DayOfWeek.Friday, "Piątek" },
            { DayOfWeek.Saturday, "Sobota" },
            { DayOfWeek.Sunday, "Niedziela" },
        };

        public static string GetDayOfWeekName(DayOfWeek dow)
        {
            return dowNames[dow];
        }
    }
}
