using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.ExtAndUtility;

namespace Korki.Models
{
    public class BasicSearchTerms
    {
        public string Name { get; set; } = "";
        public string City { get; set; } = "";
        private string defaultCity = "Warszawa";

        public string LevelStr { get; set; }

        public List<SelectListItem> PickableLevels { get; } = new List<SelectListItem>()
        {
            new SelectListItem("Klasy 1-3 szkoły podst.", ((int)TeachingLevel.OneToThree).ToString()),
            new SelectListItem("Klasy 4-6 szkoły podst.", ((int)TeachingLevel.FourToSix).ToString()),
            new SelectListItem("Klasy 7-8 szkoły podst.", ((int)TeachingLevel.SevenEight).ToString()),
            new SelectListItem("Szkoła średnia", ((int)TeachingLevel.SecondaryEdu).ToString()),
            new SelectListItem("Szkoła wyższa", ((int)TeachingLevel.HigherEdu).ToString()),
        };

        public TeachingLevel Level { get; private set; } = TeachingLevel.OneToThree;

        public void Validate()
        {
            //truncating first, and then trimming is on purpose, to cut down on extreeeeemely long strings before trimming happens
            Name = Name.LimitLength(50).TrimAsTextInput();
            City = City.LimitLength(70);
            City = (string.IsNullOrWhiteSpace(City)) ? defaultCity : City.TrimAsTextInput();
            LevelStr = LevelStr.LimitLength(3);

            int levelInt;
            if (int.TryParse(LevelStr, out levelInt) && Enum.IsDefined(typeof(TeachingLevel), levelInt))
            {
                Level = (TeachingLevel)levelInt;
            }
            else
            {
                Level = TeachingLevel.OneToThree;
            }
        }
    }
}
