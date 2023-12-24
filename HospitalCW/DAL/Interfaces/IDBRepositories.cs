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
        IRepositoryRecord Records { get; }
        IRepository<Patient> Patients { get; }
        IRepository<Specialist> Specialists { get; }
        IRepositorySchedule Schedules { get; }
        IRepositoryVisit Visits { get; }
        IRepositoryDiagnosis Diagnosiss { get; }
        IRepositoryUser Users { get; }
        IRepositorySpecialization Specializations { get; }
        int Save();
    }
}
