using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=DataBaseConnectionStr")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,Migrations.Configuration>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }

        public DbSet<Inscription> Inscriptions { get; set; }
    }
}
