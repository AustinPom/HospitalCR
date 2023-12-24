using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositorySpecialization
    {
        List<Specialization> GetAll();
        Specialization GetById(int id);
        void Create(Specialization item);
        void Update(Specialization item);
        void Delete(Specialization item);
    }
}
