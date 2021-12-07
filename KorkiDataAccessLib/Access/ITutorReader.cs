using KorkiDataAccessLib.Models;
using System.Collections.Generic;

namespace KorkiDataAccessLib.Access
{
    public interface ITutorReader
    {
        void FilterTutorsByLvl(List<Tutor> list, TutorFilters filter);
        List<Tutor> GetAllWorkingTutors();
        Tutor GetTutor(int id);
        List<Tutor> GetTutorsFiltered(TutorFilters filter);
    }
}