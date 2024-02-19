using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using HospitalCW.Ninject;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalCW.DAL.Repositories;
using HospitalCW.BLL.ViewModels.List;

namespace HospitalCW.BLL.ViewModels
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
        private User doc;

        public MainViewModel()
        {
            kernel = new StandardKernel(new NinjectRegistration(), new RepositoriesModule("DBHospital"));
            db = kernel.Get<IDBRepositories>();

            registrar = new User();
            registrar.Login = "registrar";
            registrar.Password = "registrar1";
            registrar.IsRegistrar = true;
            CurrentViewModel = new LoginViewModel(this);

            doc = new User();
            doc.Login = "PonomarenkoIG";
            doc.Password = "Nikita1337";
            doc.IsRegistrar = false;
        }

        public bool IsregistrarCredintals(string login, string password)
        {
            return login == registrar.Login && password == registrar.Password;
        }

        public bool IsspecialistCredintals(string login, string password)
        {
            return login == doc.Login && password == doc.Password;
        }

        public void TryLogInAs(string login, string password)
        {
            if (IsregistrarCredintals(login, password))
            {
                _loggedInAs = registrar;
                this.CurrentViewModel = new RegViewModel(this);
            }
            else if(IsspecialistCredintals(login, password))
            {
                _loggedInAs = doc;
                this.CurrentViewModel = new DocViewModel(this);
            }
            else
            {
                User logged_in = db.Users.GetLoginUser(login, password);
                if (logged_in != null)
                {
                    _loggedInAs = logged_in;
                    this.CurrentViewModel = new HomeViewModel(this);
                }
            }
        }

        public void LogOut()
        {
            _loggedInAs = null;
        }
    }
}
