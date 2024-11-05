using System.Data;

namespace Employee_Dapper.Interface
{
    public interface IEmpConnectionFactory
    {
        IDbConnection MidLandSqlConnectionString();
        IDbConnection Northwind_DBSqlConnectionString();
        IDbConnection hotelmanagementsqlConnectionString();
    }
}
