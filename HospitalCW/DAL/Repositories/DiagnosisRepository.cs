using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class DiagnosisRepository: IRepositoryDiagnosis
    {
        private HospitalContext db;

        public List<Diagnosis> GetAll()
        {
            return db.Diagnosiss.Select(i => i).ToList();
        }

        public void Create(Diagnosis item)
        {
            db.Diagnosiss.Add(item);
        }

        public void Delete(Diagnosis item)
        {
            db.Diagnosiss.Remove(item);
        }

        public Diagnosis GetDiagnosisById(int id)
        {
            return db.Diagnosiss.FirstOrDefault(c => c.Id == id);
        }

        public Diagnosis GetDiagnosisBySpecialization (int SpecializationId)
        {
            return db.Diagnosiss.FirstOrDefault(c => c.SpecializationId == SpecializationId);
        }

        public void Update(Diagnosis item)
        {
            var found = db.Diagnosiss.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public DiagnosisRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
