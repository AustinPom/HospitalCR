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
            return db.Diagnoses.Select(i => i).ToList();
        }

        public void Create(Diagnosis item)
        {
            db.Diagnoses.Add(item);
        }

        public void Delete(Diagnosis item)
        {
            db.Diagnoses.Remove(item);
        }

        public Diagnosis GetDiagnosisById(int id)
        {
            return db.Diagnoses.FirstOrDefault(c => c.Id == id);
        }

        public List<Diagnosis> GetDiagnosisBySpecialization (int SpecializationId)
        {
            return db.Diagnoses.Where(c => c.SpecializationId == SpecializationId).ToList();
        }

        public void Update(Diagnosis item)
        {
            var found = db.Diagnoses.Find(item.Id);
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
