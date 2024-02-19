using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Models
{
    public class Visit
    {
        [Key]
        public int Id { get; set; }

        public DateTime VisitDate { get; set; }

        public int ScheduleId { get; set; }

        public int SpecialistId { get; set; }

        public int PatientId { get; set; }

        public int DiagnosisId { get; set; }

        public bool Status { get; set; }

        public override string ToString()
        {
            return VisitDate + " " + ScheduleId + " " + SpecialistId + " " + PatientId + " " + Status + " " + DiagnosisId;
        }
    }
}
