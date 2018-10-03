using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Collections.Generic;



/// <summary>
/// Summary description for MySqlInitializer
/// </summary>
namespace TrainingSite
{
    public class MySqlInitializer : IDatabaseInitializer<ApplicationDbContext>
    {
       
        public void InitializeDatabase(ApplicationDbContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
                
                //create role
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "Administrator"});
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "Super User"});
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "User" });
                context.SaveChanges();
            }
            else {
                // query to check if MigrationHistory table is present in the database 
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                string.Format(
                  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                  "daifuku"));

                // if MigrationHistory table is not there (which is the case first time we run) - create it
                if (migrationHistoryTableExists.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
                
            }
        }
    }
}