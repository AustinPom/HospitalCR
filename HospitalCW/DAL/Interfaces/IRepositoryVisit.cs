using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.DAL.Interfaces
{
    public interface IRepositoryVisit
    {
        List<Visit> GetAll();
        Visit GetVisitById(int id);
        Visit GetVisitByRecord (int recordId);
        void Create(Visit item);
        void Update(Visit item);
        void Delete(Visit item);
    }
}
