using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositorySchedule
    {
        List<Schedule> GetAll();
        Schedule GetScheduleById (int id);
        List<Schedule> GetScheduleBySpecialist(int SpecialistId);
        void Create(Schedule item);
        void Update(Schedule item);
        void Delete(Schedule item);
    }
}
