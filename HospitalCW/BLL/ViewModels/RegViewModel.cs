using HospitalCW.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HospitalCW.BLL.ViewModels
{
    public class RegViewModel: BaseViewModel
    {
        public ObservableCollection<Visit> ListVisits { get; set; }
        public ObservableCollection<Record> ListRecords { get; set; }
        public ObservableCollection<Patient> ListPatients { get; set; }
        public ObservableCollection<Specialist> ListSpecialists { get; set; }
        public ObservableCollection<User> ListUsers { get; set; }
        public ObservableCollection<Schedule> ListSchedules { get; set; }

        public ObservableCollection<string> Months { get; set; } = new ObservableCollection<string>(new List<string>()
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        });
        public string MonthSelected { get; set; }

        //public Photographer PhotographerSelected { get; set; }

        public ICommand SignOutCommand { get; }
        public ICommand StatisticsCommand { get; }
        public ICommand SaveCommand { get; }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public RegViewModel(MainViewModel p)
        {
            DateTime now = DateTime.Now;
            ListVisits = new ObservableCollection<Visit>(p.db.Visits.GetAll());
            ListRecords = new ObservableCollection<Record>(p.db.Records.GetAll());
            ListPatients = new ObservableCollection<Patient>(p.db.Patients.GetAll());
            ListSpecialists = new ObservableCollection<Specialist>(p.db.Specialists.GetAll());
            ListUsers = new ObservableCollection<User>(p.db.Users.GetAll());
            ListSchedules = new ObservableCollection<Schedule>(p.db.Schedules.GetAll());


            SignOutCommand = new CommandViewModel(
            o => {
                p.CurrentViewModel = new LoginViewModel(p);
                p.LogOut();
            });

            SaveCommand = new CommandViewModel(
            o => {
                p.db.Save();
            });

            //AddCommand = new CommandViewModel(
            //o => {
            //    var arg = (string)o;
            //    if (arg == "photographer")
            //    {
            //        var ph = new Photographer();
            //        ListPhotographers.Add(ph);
            //        p.db.Photographers.Create(ph);
            //    }
            //});

            //RemoveCommand = new CommandViewModel(
            //o => {
            //    var arg = (string)o;
            //    if (arg == "photographer")
            //    {
            //        p.db.Photographers.Delete(PhotographerSelected);
            //        ListPhotographers.Remove(PhotographerSelected);
            //    }
            //}, o => {
            //    var arg = (string)o;
            //    if (arg == "photographer")
            //    {
            //        return PhotographerSelected != null;
            //    }
            //    return false;
            //});

            //StatisticsCommand = new CommandViewModel(
            //o => {
            //    int mIndex = -1;
            //    for (int i = 0; i < Months.Count; i++)
            //        if (Months[i] == MonthSelected) { mIndex = i; break; }

            //    if (mIndex >= 0)
            //    {
            //        Statistic st = ((OrderRepository)p.db.Orders).GetMonthStatistics(mIndex);
            //        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //        using (StreamWriter of = new StreamWriter(Path.Combine(docPath, "PhotoStudioStatistic_" + Months[mIndex] + ".txt")))
            //        {
            //            of.WriteLine("=== " + Months[mIndex] + " PhotoStudio Report ===");
            //            of.WriteLine(" * Total Revenue\t\t" + st.totalmade.ToString("N0"));
            //            of.WriteLine(" * Orders Taken\t\t" + (st.successful + st.failed).ToString("N0"));
            //            of.WriteLine(" \t | Completed:\t" + (st.successful).ToString("N0"));
            //            of.WriteLine(" \t | Failed:\t" + (st.failed).ToString("N0"));
            //            of.WriteLine("\n--- Photographer statistics --- ");

            //            foreach (Photographer ph in st.totalmade_photographers.Keys)
            //            {
            //                of.WriteLine(ph.Surname + " " + ph.Name + " " + ph.Patronym);
            //                of.WriteLine("| Earned: " + st.totalmade_photographers[ph].ToString("N0") + " from " + st.successful_photographers[ph].ToString("N0") + " orders;");
            //            }
            //        }
            //    }
            //}, o => MonthSelected != null && MonthSelected.Length > 0);
        }
    }
}
