using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalCW.BLL.ViewModels.List.Other
{
    public class VisitPatViewModel: BaseViewModel
    {
        public ObservableCollection<Visit> ListVisits { get; set; }
        public ObservableCollection<Patient> ListPatients { get; set; }

        public Patient selectedPatient { get; set; }

        public ICommand selectPatient { get; }

        public VisitPatViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            ListVisits = new ObservableCollection<Visit>();
            ListPatients = new ObservableCollection<Patient>(p.db.Patients.GetAll());

            selectPatient = new CommandViewModel((object o) =>
            {
                ListVisits.Clear();
                foreach (var item in p.db.Visits.GetByPatient(selectedPatient.Id))
                {
                    ListVisits.Add(item);
                }
            });
        }
    }
}
