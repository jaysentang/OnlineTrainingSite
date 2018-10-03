using System.Data.Entity;

/// <summary>
/// Summary description for MySqlConfiguration
/// </summary>
namespace TrainingSite
{
    public class MySqlConfiguration : DbConfiguration
    {
        public MySqlConfiguration()
        {
            SetHistoryContext("MySql.Data.MySqlClient", (conn, scheme) => new MySqlHistoryContext(conn, scheme));
            //
            // TODO: Add constructor logic here
            //
        }
    }
}