using Microsoft.Data.SqlClient;
using System.Data;

namespace DotnetCoreAPITemplate.Infrastructure.Factories
{
    public static class MSSQLConnectionFactory
    {
        public static IDbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
