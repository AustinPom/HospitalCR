using HospitalCW.BLL.ViewModels;
using HospitalCW.BLL.ViewModels.Other;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalCW.BLL
{
    public class HomeViewModel: BaseViewModel
    {
        private BaseViewModel _subViewModel;
        public BaseViewModel SubViewModel
        {
            get
            {
                return _subViewModel;
            }
            set
            {
                _subViewModel = value;
                OnPropertyChanged();
            }
        }

        public User User { get; set; }

        public ICommand SignOutCommand { get; }
        public ICommand SwitchSubCommand { get; }

        public HomeViewModel(MainViewModel p)
        {
            User = p.LoggedInAs;
            SubViewModel = new UserViewModel(p, User, this);

            SwitchSubCommand = new CommandViewModel(o =>
            {
                string arg = (string)o;
                switch (arg)
                {
                    case "User":
                        SubViewModel = new UserViewModel(p, User, this);
                        break;
                    case "Record":
                        //SubViewModel = new RecordViewModel(p, User, this);
                        break;
                    case "Diagnosis":
                        SubViewModel = new DiagnosisViewModel(p, User, this);
                        break;
                }
            });

            SignOutCommand = new CommandViewModel(o =>
            {
                User = null;
                p.LogOut();
                p.CurrentViewModel = new LoginViewModel(p);
            });
        }
    }
}
