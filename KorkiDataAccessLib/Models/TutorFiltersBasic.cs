using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class TutorFiltersBasic
    {
        public string NameStr { get; } = "";
        public string NameFirst { get; } = "";
        public string NameLast { get; } = "";
        public string City { get; }
        public int Lvl { get; }

        public TutorFiltersBasic(string nameStr, string city, int lvl)
        {
            NameStr = (string.IsNullOrWhiteSpace(nameStr)) ? "" : nameStr;
            City = city;
            Lvl = lvl;

            string[] arr = NameStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 1)
            {
                NameLast = arr[0];
                NameFirst = arr[0];
            }
            else if (arr.Length == 2)
            {
                NameFirst = arr[0];
                NameLast = arr[1];
            }
        }

        public TutorFiltersBasic()
        {
            NameStr = "";
            City = "Warszawa";
            Lvl = 0;
        }
    }
}
