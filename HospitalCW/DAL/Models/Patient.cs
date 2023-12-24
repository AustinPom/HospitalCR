using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalCW.DAL.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Age { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }

    }
}
