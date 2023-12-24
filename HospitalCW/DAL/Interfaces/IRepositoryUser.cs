using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositoryUser
    {
        List<User> GetAll();
        User GetById(int id);
        User GetLoginUser(string login, string password);
        bool CanRegister(string login, string age, string gender, string address);
        void Create(User item);
        void Update(User item);
        void Delete(User item);
    }
}
