using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalCW.BLL.ViewModels
{
    public class RegisterSViewModel: BaseViewModel
    {
        private string _login;
        private string _password;
        private string _age;
        private string _address;
        private string _gender;
        private string _firstname;
        private string _secondname;


        public string Login { get => _login; set { OnPropertyChanged("Login"); _login = value; } }
        public string Password { get => _password; set { OnPropertyChanged("Password"); _password = value; } }
        public string Age { get => _age; set { OnPropertyChanged("age"); _age = value; } }
        public string Address { get => _address; set { OnPropertyChanged("address"); _address = value; } }
        public string Gender { get => _gender; set { OnPropertyChanged("gender"); _gender = value; } }
        public string FirstName { get => _firstname; set { OnPropertyChanged("Name"); _firstname = value; } }
        public string SecondName { get => _secondname; set { OnPropertyChanged("Surname"); _secondname = value; } }

        public ICommand SignUpCommand { get; }
        public ICommand CancelCommand { get; }


        public RegisterSViewModel(MainViewModel p)
        {
            CancelCommand = new CommandViewModel(
            o => {
                p.CurrentViewModel = new LoginViewModel(p);
            });

            SignUpCommand = new CommandViewModel(
            o => {
                if (p.db.Users.CanRegister(Login, Age, Gender, Address))
                {
                    User nu = new User();
                    nu.Login = Login;
                    nu.Password = Password;

                    nu.Pat = new Patient();
                    nu.Pat.Address = Address;
                    nu.Pat.Age = Age;
                    nu.Pat.Gender = Gender;
                    nu.Pat.FirstName = FirstName;
                    nu.Pat.SecondName = SecondName;

                    p.db.Users.Create(nu);
                    p.db.Patients.Create(nu.Pat);

                    p.db.Save();
                    p.CurrentViewModel = new LoginViewModel(p);
                }
            }, o => true);
        }
    }
}
