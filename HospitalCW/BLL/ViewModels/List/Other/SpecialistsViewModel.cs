using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.BLL.ViewModels.List.Other
{
    public class SpecialistsViewModel: BaseViewModel
    {
        public ObservableCollection<Specialist> ListSpecialists { get; set; }

        public SpecialistsViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            ListSpecialists = new ObservableCollection<Specialist>(p.db.Specialists.GetAll());
        }
    }
}
