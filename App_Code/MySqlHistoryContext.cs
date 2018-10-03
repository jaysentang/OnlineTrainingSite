using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

/// <summary>
/// Summary description for IdentityMySQL
/// </summary>
namespace TrainingSite
{
    public class MySqlHistoryContext : HistoryContext
    {
        public MySqlHistoryContext(DbConnection conn, string defaulSchema) : base(conn, defaulSchema)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();

        }
    }
}