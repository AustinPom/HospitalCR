using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class DBRepositories: IDBRepositories
    {
        private HospitalContext db;

        private RecordRepository _records;
        private PatientRepository _patients;
        private SpecialistRepository _specialists;
        private ScheduleRepository _schedules;
        private DiagnosisRepository _diagnosiss;
        private VisitRepository _visits;
        private UserRepository _users;
        private SpecializationRepository _specializations;

        public DBRepositories()
        {
            db = new HospitalContext();
        }

       

        public IRepositoryUser Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(db);
                return _users;
            }
        }

        public IRepositorySpecialization Specializations
        {
            get
            {
                if (_specializations == null)
                    _specializations = new SpecializationRepository(db);
                return _specializations;
            }
        }
        public IRepositoryDiagnosis Diagnosiss
        {
            get
            {
                if (_diagnosiss == null)
                    _diagnosiss = new DiagnosisRepository(db);
                return _diagnosiss;
            }
        }

        public IRepositoryRecord Records
        {
            get
            {
                if (_records == null)
                    _records = new RecordRepository(db);
                return _records;
            }
        }

        public IRepository<Patient> Patients
        {
            get
            {
                if (_patients == null)
                    _patients = new PatientRepository(db);
                return _patients;
            }
        }

        public IRepositoryVisit Visits
        {
            get
            {
                if (_visits == null)
                    _visits = new VisitRepository(db);
                return _visits;
            }
        }

        public IRepository<Specialist> Specialists
        {
            get
            {
                if (_specialists == null)
                    _specialists = new SpecialistRepository(db);
                return _specialists;
            }
        }

        public IRepositorySchedule Schedules
        {
            get
            {
                if (_schedules == null)
                    _schedules = new ScheduleRepository(db);
                return _schedules;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}

