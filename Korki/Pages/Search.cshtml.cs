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
            new SelectListItem("ObojÍtnie", ((int)TutoringPlace.Any).ToString()),
            new SelectListItem("Z dojazdem do klienta", ((int)TutoringPlace.AtClients).ToString()),
            new SelectListItem("U korepetytora", ((int)TutoringPlace.AtTutors).ToString()),
        };

        public TutoringPlace Place { get; private set; }

        public List<Tutor> Results { get; private set; }

        public int PageIndex { get; set; } = 0;
        public static int MaxResultsPerPage { get; } = 40;

        private readonly ITutorReader reader;

        public SearchModel(ITutorReader reader)
        {
            this.reader = reader;
        }

        public void OnGet()
        {
            BasicTerms.Validate();
            //this seems like a hack, but achieves what i'm after - without calling ModelStateClear();
            //the results of calling BasicTerms.Validate() didn't appear on the newly constructed form,
            //with ModelState.Clear() the form is repopulated with the validated values
            ModelState.Clear();
            ValidateAdvancedTerms();

            TutorFilters filter = BasicTerms.Map(MinRating, SkipNonRated, MaxPrice, (int)Place);

            // this stuff is from when i was trying to fix an access violation error 
            // that was elusive, seemed to happen right after OnExit finished its job
            // and resolved itself? suspicious, leaving this just in case

            //List<KorkiDataAccessLib.Models.Tutor> unmappedResults = reader.GetAllWorkingTutors();
            //Results = reader.GetTutorsFiltered(filter).Map();
            //Results = new List<Tutor>();
            //for (int i = 0; i < 20 && i < unmappedResults.Count; i++)
            //{
            //    Results.Add(ModelMapper.MapTutor(unmappedResults[i]));
            //}
            //Results = ModelMapper.MapTutors(unmappedResults);

            //Results = ModelMapper.MapTutors(reader.GetAllWorkingTutors());
            Results = ModelMapper.MapTutors(reader.GetTutorsFiltered(filter));

        }

        private void ValidateAdvancedTerms()
        {
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