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
    public class DocViewModel : BaseViewModel
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

        public DocViewModel(MainViewModel p)
        {
            User = p.LoggedInAs;
            SubViewModel = new VisitPatViewModel(p, User, this);

            SwitchSubCommand = new CommandViewModel(o =>
            {
                string arg = (string)o;
                switch (arg)
                {
                    case "VisitPat":
                        SubViewModel = new VisitPatViewModel(p, User, this);
                        break;
                    case "DiagBook":
                        SubViewModel = new DiagBookViewModel(p, User, this);
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
