using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositoryDiagnosis
    {
        List<Diagnosis> GetAll();
        Diagnosis GetDiagnosisById(int id);
        List<Diagnosis> GetDiagnosisBySpecialization(int SpecializationId);
        void Create(Diagnosis item);
        void Update(Diagnosis item);
        void Delete(Diagnosis item);
    }
}
