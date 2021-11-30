using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public int VoivodeshipAlphaIndex { get; set; }
        public string Powiat { get; set; }
        public string Gmina { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }

        public string Voivodeship => (VoivodeshipAlphaIndex >= 0 && VoivodeshipAlphaIndex < voivodeshipNames.Count) ? voivodeshipNames[VoivodeshipAlphaIndex] : "invalid voidvodeship";

        private static List<string> voivodeshipNames = new List<string>()
        {
            "Dolnośląskie",
            "Kujawsko-Pomorskie",
            "Lubelskie",
            "Lubuskie",
            "Łódzkie",
            "Małopolskie",
            "Mazowieckie",
            "Opolskie",
            "Podkarpackie",
            "Podlaskie",
            "Pomorskie",
            "Śląskie",
            "Świętokrzyskie",
            "Warmińsko-Mazurskie",
            "Wielkopolskie",
            "Zachodniopomorskie",
        };
    }
}
