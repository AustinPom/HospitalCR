using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.BLL.ViewModels.List.Other
{
    public class UsersViewModel: BaseViewModel
    {
        public ObservableCollection<User> ListUsers { get; set; }

        public UsersViewModel(MainViewModel p, User user, BaseViewModel pp)
        {
            ListUsers = new ObservableCollection<User>(p.db.Users.GetAll());
        }
    }
}
