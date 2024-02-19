using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.BLL.ViewModels.List.Other
{
    public class SchedulesViewModel: BaseViewModel
    {
        public ObservableCollection<Schedule> ListSchedules { get; set; }

        public SchedulesViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            ListSchedules = new ObservableCollection<Schedule>(p.db.Schedules.GetAll());
        }
    }
}
