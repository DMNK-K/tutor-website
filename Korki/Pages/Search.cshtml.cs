using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Korki.Pages
{
    public class SearchModel : PageModel
    {
        ////basic search terms
        //[BindProperty(SupportsGet = true)]
        //public string Name { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string City { get; set; }
        //private string defaultCity = "Warszawa";
        //[BindProperty(SupportsGet = true)]
        //public string LevelStr { get; set; }

        //public List<SelectListItem> PickableLevels { get; } = new List<SelectListItem>()
        //{
        //    new SelectListItem("Klasy 1-3 szko³y podst.", ((int)TeachingLevel.OneToThree).ToString()),
        //    new SelectListItem("Klasy 4-6 szko³y podst.", ((int)TeachingLevel.FourToSix).ToString()),
        //    new SelectListItem("Klasy 7-8 szko³y podst.", ((int)TeachingLevel.SevenEight).ToString()),
        //    new SelectListItem("Szko³a œrednia", ((int)TeachingLevel.SecondaryEdu).ToString()),
        //    new SelectListItem("Szko³a wy¿sza", ((int)TeachingLevel.HigherEdu).ToString()),
        //};

        //public TeachingLevel Level { get; private set; }

        [BindProperty(SupportsGet = true)]
        public BasicSearchTerms BasicTerms { get; set; } = new BasicSearchTerms();

        //advanced terms
        [BindProperty(SupportsGet = true)]
        public int MinRating { get; set; }
        [BindProperty(SupportsGet = true)]
        public int MaxPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool SkipNonRated { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PlaceStr { get; set; }

        public List<SelectListItem> PickablePlaces { get; } = new List<SelectListItem>()
        {
            new SelectListItem("Obojêtnie", ((int)TutoringPlace.Any).ToString()),
            new SelectListItem("Z dojazdem do klienta", ((int)TutoringPlace.AtClients).ToString()),
            new SelectListItem("U korepetytora", ((int)TutoringPlace.AtTutors).ToString()),
        };

        public TutoringPlace Place { get; private set; }

        public List<Tutor> Results { get; set; } = new List<Tutor>();

        public int PageIndex { get; set; } = 0;
        public static int MaxResultsPerPage { get; } = 40;

        public void OnGet()
        {
            BasicTerms.Validate();

            if (MaxPrice < 0) { MaxPrice = 0; }
            MinRating = Math.Clamp(MinRating, 0, 5);

            int placeInt;
            if (int.TryParse(PlaceStr, out placeInt) && Enum.IsDefined(typeof(TutoringPlace), placeInt))
            {
                Place = (TutoringPlace)placeInt;
            }
            else
            {
                Place = TutoringPlace.Any;
            }
        }
    }
}

public enum TutoringPlace
{
    Any = 0,
    AtClients,
    AtTutors,
}