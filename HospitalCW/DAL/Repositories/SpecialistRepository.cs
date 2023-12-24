using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class SpecialistRepository: IRepository<Specialist>
    {
        private HospitalContext db;

        public List<Specialist> GetAll()
        {
            return db.Specialists.Select(i => i).ToList();
        }

        public void Create(Specialist item)
        {
            db.Specialists.Add(item);
        }

        public void Delete(Specialist item)
        {
            db.Specialists.Remove(item);
        }

        public Specialist GetById(int id)
        {
            return db.Specialists.FirstOrDefault(c => c.Id == id);
        }

        public Specialist GetBySpecializaionId(int specializationid)
        {
            return db.Specialists.FirstOrDefault(c => c.SpecializationId == specializationid);
        }

        public void Update(Specialist item)
        {
            var found = db.Specialists.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public SpecialistRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
