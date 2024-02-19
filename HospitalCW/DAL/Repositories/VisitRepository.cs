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

        public List<Visit> GetByPatient(int PatientId)
        {
            return db.Visits.Where(c => c.PatientId == PatientId).ToList();
        }

        public List<Visit> GetBySpecialist(int SpecialistId)
        {
            return db.Visits.Where(c => c.SpecialistId == SpecialistId).ToList();
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
