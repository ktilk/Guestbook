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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // convert all datetime and datetime? properties to datetime2 in ms sql
            // ms sql datetime has min value of 1753-01-01 00:00:00.000
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2").HasPrecision(0));



        }
    }
}
