using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositoryPatient
    {
        List<Patient> GetAll();
        Patient GetById(int id);
        void Create(Patient item);
        void Update(Patient item);
        void Delete(Patient item);
    }
}
