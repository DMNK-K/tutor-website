using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Models
{
    public class TutorTimetable
    {
        public Dictionary<DateTime, List<DateTime>> AvailableDates { get; set; } = new Dictionary<DateTime, List<DateTime>>();
        

        public static TutorTimetable GetSampleTimetable()
        {
            TutorTimetable t = new TutorTimetable();
            return t;
        }
    }
}
