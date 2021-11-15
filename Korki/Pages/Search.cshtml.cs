using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Korki.Pages
{
    public class SearchModel : PageModel
    {
        //basic search terms
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string City { get; set; }
        [BindProperty(SupportsGet = true)]
        public TeachingLevel Level { get; set; }

        //advanced terms
        [BindProperty(SupportsGet = true)]
        public int MinRating { get; set; }

        public List<Tutor> Results { get; set; } = new List<Tutor>();


        public int PageIndex { get; set; } = 0;

        public static int MaxResultsPerPage { get; } = 40;

        public void OnGet()
        {

        }
    }
}
