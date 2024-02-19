using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositorySpecialist
    {
        List<Specialist> GetAll();
        Specialist GetById(int id);
        List<Specialist> GetBySpecializationId(int SpecializationId);
        void Create(Specialist item);
        void Update(Specialist item);
        void Delete(Specialist item);
    }
}
