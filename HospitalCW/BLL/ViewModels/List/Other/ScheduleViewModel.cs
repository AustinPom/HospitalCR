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
    public class ScheduleViewModel: BaseViewModel
    {
        private string _timeStart;
        private string _timeEnd;

        public ObservableCollection<Specialist> Specialists { get; set; }

        public string TimeStart { get => _timeStart; set { OnPropertyChanged("TimeStart"); _timeStart = value; } }
        public string TimeEnd { get => _timeEnd; set { OnPropertyChanged("TimeEnd"); _timeEnd = value; } }


        public Specialist selectedSpecialist { get; set; }

        public ICommand CreateScheduleCommand { get; }
        public ICommand CancelCommand { get; }


        public ScheduleViewModel(MainViewModel p, User user, RegViewModel regViewModel)
        {
            Specialists = new ObservableCollection<Specialist>(p.db.Specialists.GetAll());

            CancelCommand = new CommandViewModel(
            o => {
                p.CurrentViewModel = new RegViewModel(p);
            });

            CreateScheduleCommand = new CommandViewModel(
            o => {

                Schedule newSchedule = new Schedule();
                newSchedule.TimeStart = TimeStart;
                newSchedule.TimeEnd = TimeEnd;
                newSchedule.SpecialistId = selectedSpecialist.Id;
                p.db.Schedules.Create(newSchedule);

                p.db.Save();
            });
        }
    }
}

