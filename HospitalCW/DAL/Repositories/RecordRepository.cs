using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HospitalCW.DAL.Repositories
{
    public class RecordRepository: IRepositoryRecord
    {
        private HospitalContext db;

        public List<Record> GetAll()
        {
            return db.Records.Select(i => i).ToList();
        }
        public Record GetRecordByPatient(int PatientId)
        {
            return db.Records.FirstOrDefault(c => c.PatientId == PatientId);
        }

        public void Create(Record item)
        {
            db.Records.Add(item);
        }

        public void Delete(Record item)
        {
            db.Records.Remove(item);
        }

        public Record GetRecordById(int id)
        {
            return db.Records.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Record item)
        {
            var found = db.Records.Find(item.Id);
            if (found != null)
            {
                db.Entry(found).CurrentValues.SetValues(item);
            }
        }

        public RecordRepository(HospitalContext db)
        {
            this.db = db;
        }
    }
}
