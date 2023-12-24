using HospitalCW.DAL.Interfaces;
using HospitalCW.BLL.ViewModels;
using HospitalCW.DAL.Models;
using HospitalCW.Ninject;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCW.DAL.Repositories;


namespace HospitalCW.BLL
{
    public class MainViewModel: BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        StandardKernel kernel;
        public IDBRepositories db;

        private User _loggedInAs;
        public User LoggedInAs { get => _loggedInAs; }

        private User registrar;

        public MainViewModel()
        {
            kernel = new StandardKernel(new NinjectRegistration(), new RepositoriesModule("PhotoStudioCS"));
            //kernel = new StandardKernel(new NinjectRegistrations(), new RepositoriesModule("MongoDBCS"));
            db = kernel.Get<IDBRepositories>();

            registrar = new User();
            registrar.Login = "registrar";
            registrar.Password = "registrar1";
            registrar.IsRegistrar = true;
            CurrentViewModel = new LoginViewModel(this);
        }

        public bool IsregistrarCredintals(string login, string password)
        {
            return login == registrar.Login && password == registrar.Password;
        }

        public void TryLogInAs(string login, string password)
        {
            if (IsregistrarCredintals(login, password))
            {
                _loggedInAs = registrar;
                this.CurrentViewModel = new RegViewModel(this);
            }
            else
            {
                User logged_in = db.Users.GetLoginUser(login, password);
                if (logged_in != null)
                {
                    this.CurrentViewModel = new HomeViewModel(this);
                    _loggedInAs = logged_in;
                }
            }
        }

        public void LogOut()
        {
            _loggedInAs = null;
        }
    }
}
