using KorkiDataAccessLib.Models;
using System.Collections.Generic;

namespace KorkiDataAccessLib.Access
{
    public interface ITutorReader
    {
        void FilterTutorsByLvl(List<TutorData> list, TutorFilters filter);
        List<TutorData> GetAllWorkingTutors();
        TutorData GetTutor(int id);
        List<TutorData> GetTutorsFiltered(TutorFilters filter);
    }
}