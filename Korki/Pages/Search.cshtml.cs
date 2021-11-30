using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using Korki.ExtAndUtility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KorkiDataAccessLib.Access;
using KorkiDataAccessLib.Models;
using Tutor = Korki.Models.Tutor;

namespace Korki.Pages
{
    public class SearchModel : PageModel
    {
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

            TutorFiltersBasic filter = BasicTerms.Map();
            TutorFiltersAdv advFilter = new TutorFiltersAdv(MinRating, MaxPrice, SkipNonRated, (int)Place);
            //Results = TutorAccess.GetTutorsFiltered(filter, advFilter).Map();
        }
    }
}

public enum TutoringPlace
{
    Any = 0,
    AtClients,
    AtTutors,
}