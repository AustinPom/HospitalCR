using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Models
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int SpecializationId { get; set; }

        public override string ToString()
        {
            return Name + " " + SpecializationId;
        }
    }
}
