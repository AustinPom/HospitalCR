using HospitalCW.DAL.Models;
using HospitalCW.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Repositories
{
    public class UserRepository: IRepositoryUser
    {
        private HospitalContext db;

        public List<User> GetAll()
        {
            return db.Users.Select(i => i).ToList();
        }

        public User GetLoginUser(string login, string password)
        {
            return db.Users.Where(u => u.Login == login && u.Password == password).SingleOrDefault();
        }

        public bool CanRegister(string login, string age, string gender, string address)
        {
            var found = db.Users.FirstOrDefault(u =>
                (u.Login == login || u.Pat.Age == age || u.Pat.Gender == gender || u.Pat.Address == address)
            );
            return found == null;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(User item)
        {
            db.Users.Remove(item);
        }

        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(c => c.Id == id);
        }

        public void Update(User item)
        {
            var found = db.Users.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public UserRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
