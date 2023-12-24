using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class VisitRepository: IRepositoryVisit
    {
        private HospitalContext db;

        public List<Visit> GetAll()
        {
            return db.Visits.Select(i => i).ToList();
        }

        public void Create(Visit item)
        {
            db.Visits.Add(item);
        }

        public void Delete(Visit item)
        {
            db.Visits.Remove(item);
        }

        public Visit GetVisitById(int id)
        {
            return db.Visits.FirstOrDefault(c => c.Id == id);
        }

        public Visit GetVisitByRecord(int RecordId)
        {
            return db.Visits.FirstOrDefault(c => c.RecordId == RecordId);
        }

        public void Update(Visit item)
        {
            var found = db.Visits.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public VisitRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
