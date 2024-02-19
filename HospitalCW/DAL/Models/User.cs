using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsRegistrar { get; set; }

        public Patient Pat { get; set; }

        public Specialist Doctor { get; set; }

        public override string ToString()
        {
            return Login + "[" + Id + "]";
        }
    }
}
