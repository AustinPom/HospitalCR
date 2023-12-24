using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using HospitalCW.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.Ninject
{
    public class NinjectRegistration: NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositoryRecord>().To<RecordRepository>();
            Bind<IRepositoryDiagnosis>().To<DiagnosisRepository>();
            Bind<IRepository<Patient>>().To<PatientRepository>();
            Bind<IRepositoryVisit>().To<VisitRepository>();
            Bind<IRepository<Specialist>>().To<SpecialistRepository>();
            Bind<IRepositorySchedule>().To<ScheduleRepository>();
            Bind<IRepositoryUser>().To<UserRepository>();
            Bind<IRepositorySpecialization>().To<SpecializationRepository>();
        }
    }
}
