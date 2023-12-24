using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class PatientRepository: IRepository<Patient>
    {
        private HospitalContext db;

        public List<Patient> GetAll()
        {
            return db.Patients.Select(i => i).ToList();
        }

        public void Create(Patient item)
        {
            db.Patients.Add(item);
        }

        public void Delete(Patient item)
        {
            db.Patients.Remove(item);
        }

        public Patient GetById(int id)
        {
            return db.Patients.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Patient item)
        {
            var found = db.Patients.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public PatientRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
