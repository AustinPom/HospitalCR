using HospitalCW.BLL.ViewModels;
using HospitalCW.BLL.ViewModels.List.Other;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalCW.BLL.ViewModels.List
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

        public User user { get; set; }

        public ICommand SignOutCommand { get; }
        public ICommand SwitchSubCommand { get; }

        public HomeViewModel(MainViewModel p)
        {
            user = p.LoggedInAs;
            SubViewModel = new VisitViewModel(p, user, this);

            SwitchSubCommand = new CommandViewModel(o =>
            {
                string arg = (string)o;
                switch (arg)
                {
                    case "User":
                        SubViewModel = new UserViewModel(p, user, this);
                        break;
                    case "Visit":
                        SubViewModel = new VisitViewModel(p, user, this);
                        break;
                }
            });

            SignOutCommand = new CommandViewModel(o =>
            {
                user = null;
                p.LogOut();
                p.CurrentViewModel = new LoginViewModel(p);
            });
        }
    }
}
