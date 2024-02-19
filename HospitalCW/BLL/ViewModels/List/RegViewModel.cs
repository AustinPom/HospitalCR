using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using Org.BouncyCastle.Asn1.X509;
using HospitalCW.BLL.ViewModels.List.Other;

namespace HospitalCW.BLL.ViewModels.List
{
    public class RegViewModel : BaseViewModel
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

        public RegViewModel(MainViewModel p)
        {
            User = p.LoggedInAs;
            SubViewModel = new UsersViewModel(p, User, this);

            SwitchSubCommand = new CommandViewModel(o =>
            {
                string arg = (string)o;
                switch (arg)
                {
                    case "Users":
                        SubViewModel = new UsersViewModel(p, User, this);
                        break;
                    case "Specialists":
                        SubViewModel = new SpecialistsViewModel(p, User, this);
                        break;
                    case "Schedules":
                        SubViewModel = new SchedulesViewModel(p, User, this);
                        break;
                    case "CreateSchedule":
                        SubViewModel = new ScheduleViewModel(p, User, this);
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
