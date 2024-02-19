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
    public class DiagBookViewModel: BaseViewModel
    {
        public ObservableCollection<Diagnosis> ListDiagnoses { get; set; }
        public ObservableCollection<Specialization> ListSpecializations { get; set; }

        public Specialization selectedSpecialization { get; set; }

        public ICommand selectSpecialization {  get;}

        public DiagBookViewModel(MainViewModel p, User user, BaseViewModel baseViewModel)
        {
            ListDiagnoses = new ObservableCollection<Diagnosis>();
            ListSpecializations = new ObservableCollection<Specialization>(p.db.Specializations.GetAll());

            selectSpecialization = new CommandViewModel((object o) =>
            {
                ListDiagnoses.Clear();
                foreach (var item in p.db.Diagnoses.GetDiagnosisBySpecialization(selectedSpecialization.Id))
                {
                    ListDiagnoses.Add(item);
                }
       
            });
        }
    }
}
