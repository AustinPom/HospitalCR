using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IDBRepositories
    {
        IRepository<Patient> Patients { get; }
        IRepositorySpecialist Specialists { get; }
        IRepositorySchedule Schedules { get; }
        IRepositoryVisit Visits { get; }
        IRepositoryDiagnosis Diagnoses { get; }
        IRepositoryUser Users { get; }
        IRepository<Specialization> Specializations { get; }
        int Save();
    }
}
