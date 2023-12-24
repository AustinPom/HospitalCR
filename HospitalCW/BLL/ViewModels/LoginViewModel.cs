using HospitalCW.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace HospitalCW.BLL.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        private string _login = string.Empty;
        private string _password = string.Empty;
        private MainViewModel mainViewModel;

        public string Login { get => _login; set { OnPropertyChanged("Login"); _login = value; } }
        public string Password { get => _password; set { OnPropertyChanged("Password"); _password = value; } }


        public ICommand SignInCommand { get; }
        public ICommand SignUpCommandP { get; }
        public ICommand SignUpCommandS { get; }

        public LoginViewModel(MainViewModel p)
        {
            SignInCommand = new CommandViewModel(
            o => {
                p.TryLogInAs(Login, Password);
            }, o => (_login.Length > 3) && (_password.Length > 3));

            SignUpCommandP = new CommandViewModel(
            o => {
                p.CurrentViewModel = new RegisterViewModel(p);
            });

            SignUpCommandS = new CommandViewModel(
            o => {
                p.CurrentViewModel = new RegisterSViewModel(p);
            });
        }
    }
}

