using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.BLL.ViewModels.Other
{
    public class DiagnosisViewModel: BaseViewModel
    {
        public ObservableCollection<Diagnosis> ListDiagnosiss { get; set; }

        public DiagnosisViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            ListDiagnosiss = new ObservableCollection<Diagnosis>(p.db.Diagnosiss.GetAll());
        }
    }
}
