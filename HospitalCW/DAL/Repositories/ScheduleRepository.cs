using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    internal class ScheduleRepository: IRepositorySchedule
    {
        private HospitalContext db;

        public List<Schedule> GetAll()
        {
            return db.Schedules.Select(i => i).ToList();
        }

        public void Create(Schedule item)
        {
            db.Schedules.Add(item);
        }

        public void Delete(Schedule item)
        {
            db.Schedules.Remove(item);
        }

        public Schedule GetScheduleById(int id)
        {
            return db.Schedules.FirstOrDefault(c => c.Id == id);
        }

        public Schedule GetScheduleBySpecialist(int SpecialistId)
        {
            return db.Schedules.FirstOrDefault(c => c.SpecialistId == SpecialistId);
        }

        public void Update(Schedule item)
        {
            var found = db.Schedules.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public ScheduleRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
