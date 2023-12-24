using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        public string TimeStart { get; set; }

        public string TimeEnd { get; set; }

        public int SpecialistId { get; set; }

        public override string ToString()
        {
            return TimeStart + " " + TimeEnd;
        }

    }
}
