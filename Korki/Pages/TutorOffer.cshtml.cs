using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Korki.ExtAndUtility;
using KorkiDataAccessLib.Access;

namespace Korki.Pages
{
    public class TutorOfferModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int TID { get; set; }

        public Tutor Tutor { get; set; }
        public TutorTimetable Timetable { get; set; } = new TutorTimetable();

        private readonly ITutorReader reader;

        public TutorOfferModel(ITutorReader reader)
        {
            this.reader = reader;
        }

        public string GetLevelStr(string subject)
        {
            if (Tutor.Subjects == null || !Tutor.Subjects.ContainsKey(subject)) { return ""; }
            List<TeachingLevel> lvls = Tutor.Subjects[subject];

            string str = "";
            int combinedPrimaryCount = 0;
            combinedPrimaryCount += (lvls.Contains(TeachingLevel.OneToThree)) ? 1 : 0;
            combinedPrimaryCount += (lvls.Contains(TeachingLevel.FourToSix)) ? 1 : 0;
            combinedPrimaryCount += (lvls.Contains(TeachingLevel.SevenEight)) ? 1 : 0;

            if (combinedPrimaryCount == 3)
            {
                str += "klasy 1-8 szko造 podst.";
            }
            else if (combinedPrimaryCount > 1)
            {
                if (lvls.Contains(TeachingLevel.OneToThree))
                {
                    str += (lvls.Contains(TeachingLevel.FourToSix)) ? "klasy 1-6 szko造 podst." : "klasy 1-3 i 7-8 szko造 podst.";
                }
                else
                {
                    str += "klasy 4-8 szko造 podst.";
                }
            }
            else if (combinedPrimaryCount == 1)
            {
                if (lvls.Contains(TeachingLevel.OneToThree)) str += "klasy 1-3 szko造 podst.";
                else if (lvls.Contains(TeachingLevel.FourToSix)) str += "klasy 4-6 szko造 podst.";
                else str += "klasy 7, 8 szko造 podst.";
            }

            if (lvls.Contains(TeachingLevel.SecondaryEdu))
            {
                str += (str != "" ? ", " : "") + "szko豉 ?rednia";
            }

            if (lvls.Contains(TeachingLevel.HigherEdu))
            {
                str += (str != "" ? ", " : "") + "szko豉 wy窺za";
            }
            return str;
        }

        public void OnGet()
        {
            Tutor = ModelMapper.MapTutor(reader.GetTutor(TID));
            Timetable = TutorTimetable.GetSampleTimetable();
        }
    }
}
