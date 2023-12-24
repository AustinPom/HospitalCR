﻿using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HospitalCW
{
    public class HospitalContext: DbContext
    {
        public HospitalContext() : base("HospitalDataBase") { }
        public DbSet<Record> Records { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialist> Specialists{ get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
