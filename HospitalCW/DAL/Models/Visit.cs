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

        public int RecordId { get; set; }

        public int DiagnosisId { get; set; }

        public override string ToString()
        {
            return RecordId + " " + DiagnosisId;
        }
    }
}
