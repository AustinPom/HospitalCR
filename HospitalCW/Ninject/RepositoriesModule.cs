using HospitalCW.DAL.Interfaces;
using HospitalCW.DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCW.Ninject
{
    public class RepositoriesModule: NinjectModule
    {
        private string connectionString;

        public RepositoriesModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IDBRepositories>().To<DBRepositories>().InSingletonScope().WithConstructorArgument(connectionString);
            //Bind<IDbRepositories>().To<DbRepositoriesMongo>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
