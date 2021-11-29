using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class TutorFiltersBasic
    {
        public string Name { get; }
        public string City { get; }
        public int Lvl { get; }

        public TutorFiltersBasic(string name, string city, int lvl)
        {
            Name = name;
            City = city;
            Lvl = lvl;
        }

        public TutorFiltersBasic()
        {
            Name = "";
            City = "Warszawa";
            Lvl = 0;
        }
    }
}
