using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Korki.Pages
{
    public class TutorOfferModel : PageModel
    {
        public Tutor Tutor { get; set; }

        public void OnGet()
        {
        }
    }
}
