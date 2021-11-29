using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class Tutor
    {
        public int TID { get; set; }
        public int UID { get; set; }

        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameFormal { get; set; }

        public bool UsesFormalName { get; set; }
        public bool GoesToClient { get; set; }
        public bool Operational { get; set; }

        public string Desc { get; set; }
        public string City { get; set; }
        public string InfoPrice { get; set; }
        public string InfoBonus { get; set; }

        public int ServiceRange { get; set; }
        public int RatingCount { get; set; }
        public int RatingSum { get; set; }
        public double RatingAvg => (RatingCount > 0) ? RatingSum * 1.0 / RatingCount : 0;

        public string Timetable { get; set; }

    }
}
