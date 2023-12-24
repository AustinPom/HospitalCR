using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class SpecializationRepository: IRepositorySpecialization
    {
        private HospitalContext db;

        public List<Specialization> GetAll()
        {
            return db.Specializations.Select(i => i).ToList();
        }

        public void Create(Specialization item)
        {
            db.Specializations.Add(item);
        }

        public void Delete(Specialization item)
        {
            db.Specializations.Remove(item);
        }

        public Specialization GetById(int id)
        {
            return db.Specializations.FirstOrDefault(c => c.Id == id);
        }


        public void Update(Specialization item)
        {
            var found = db.Specializations.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public SpecializationRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
