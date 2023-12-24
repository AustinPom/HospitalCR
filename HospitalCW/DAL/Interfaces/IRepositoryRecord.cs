using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositoryRecord
    {
        List<Record> GetAll();
        Record GetRecordById(int id);
        Record GetRecordByPatient(int PatientId);
        void Create(Record item);
        void Update(Record item);
        void Delete(Record item);
    }
}
