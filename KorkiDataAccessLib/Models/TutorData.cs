using System;
using System.Collections.Generic;
using System.Text;

namespace KorkiDataAccessLib.Models
{
    public class TutorData
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string NameFormal { get; set; }

        public bool UsesFormalName { get; set; }
        public bool GoesToClient { get; set; }
        public string Description { get; set; }

        public int RatingCount { get; set; }
        public int RatingSum { get; set; }
        public static int MinRatingCount { get; } = 3;

        public int CityID { get; set; }
        public CityData City { get; set; }
        public string InfoPrice { get; set; }
        public string InfoBonus { get; set; }

        public int ServiceRange { get; set; }
        public double RatingAvg => (RatingCount > 0) ? RatingSum * 1.0 / RatingCount : 0;

        public string Timetable { get; set; }

        public bool Operational { get; set; }
        private string _subjectsStr;
        public string SubjectsStr { get => _subjectsStr; set { _subjectsStr = value.ToLower(); ComputeSubjects(); } }
        public bool IsShowcase { get; set; }

        public Dictionary<string, List<int>> Subjects { get; private set; } = new Dictionary<string, List<int>>();

        void ComputeSubjects()
        {
            string[] elements = SubjectsStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (elements.Length >= 2 && elements.Length % 2 == 0)
            {
                for (int i = 0; i < elements.Length; i += 2)
                {
                    string subjectName = elements[i];
                    int lvlIndex;
                    if (int.TryParse(elements[i + 1], out lvlIndex))
                    {
                        if (Subjects.ContainsKey(subjectName))
                        {
                            Subjects[subjectName].Add(lvlIndex);
                        }
                        else
                        {
                            Subjects.Add(subjectName, new List<int>() { lvlIndex });
                        }
                    }
                }
            }
        }

        public bool TeachesSubject(string subjectNameLowerCase)
        {
            return Subjects.ContainsKey(subjectNameLowerCase);
        }

        public bool TeachesAnySubjectAtLvl(int lvl)
        {
            foreach (string key in Subjects.Keys)
            {
                if (Subjects[key].Contains(lvl))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
