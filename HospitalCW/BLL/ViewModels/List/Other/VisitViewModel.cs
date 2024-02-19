using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalCW.BLL.ViewModels.List.Other
{
    public class VisitViewModel : BaseViewModel
    {
        public ObservableCollection<Specialization> Specializations { get; set;}
        public ObservableCollection<Specialist> Specialists { get; set; }
        public ObservableCollection<Schedule> Schedules { get; set; }
        public ObservableCollection<DateTime> DateTimes { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }

        public Patient selectedPatient { get; set; }
        public Specialization selectedSpecialization { get; set; }
        public Specialist selectedSpecialist { get; set; }
        public Schedule selectedSchedule { get; set; }
        public DateTime selectedDateTime { get; set; }

        public ICommand selectSpecialization {get;}
        public ICommand selectSpecialist { get;}
        public ICommand createVisit { get;}

        public VisitViewModel(MainViewModel p, User user, HomeViewModel homeViewModel)
        {
            Patients = new ObservableCollection<Patient>(p.db.Patients.GetAll());
            Specializations = new ObservableCollection<Specialization>(p.db.Specializations.GetAll());
            Specialists = new ObservableCollection<Specialist>();
            Schedules = new ObservableCollection<Schedule>();

            selectSpecialization = new CommandViewModel((object o) => 
            {
                Specialists.Clear();
                foreach (var item in p.db.Specialists.GetBySpecializationId(selectedSpecialization.Id))
                {
                    Specialists.Add(item);
                }
  
            });

            selectSpecialist = new CommandViewModel((object o) => 
            {
                Schedules.Clear();
                foreach (var item in p.db.Schedules.GetScheduleBySpecialist(selectedSpecialist.Id))
                {
                    Schedules.Add(item);
                }
            });

            createVisit = new CommandViewModel((object o) =>
            {
                Visit newVisit = new Visit();
                newVisit.PatientId = selectedPatient.Id;
                newVisit.Status = false;
                newVisit.VisitDate = selectedDateTime;
                newVisit.SpecialistId = selectedSpecialist.Id;
                newVisit.ScheduleId = selectedSchedule.Id;
                newVisit.DiagnosisId = 1;

                p.db.Visits.Create(newVisit);

                p.db.Save();
            });

        }

    }
}
