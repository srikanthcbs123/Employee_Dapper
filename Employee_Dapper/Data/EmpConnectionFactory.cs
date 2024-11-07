using Employee_Dapper.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Employee_Dapper.Data
{
    public class EmpConnectionFactory : IEmpConnectionFactory
    {
        private readonly IConfiguration _config;
        public EmpConnectionFactory(IConfiguration config)
        {
            _config = config;
        }
        //Don't hard code connecting sting like below.
        //always read the connection string from appsettings.json file
        // string connectionString = "data source=DESKTOP-AAO14OC;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement;integrated security=yes";
        public IDbConnection MidLandSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:MidLandSqlConnectionString").Value);
            //Creates an IDbConnection Object to store the sqlconnection.
            IDbConnection con= new SqlConnection(connStr);
            return con;
        }

        public IDbConnection Northwind_DBSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:Northwind_DBSqlConnectionString").Value);
            // Creates an IDbConnection Object to store the sqlconnection.
            IDbConnection _connection = new SqlConnection(connStr);
            return _connection;
        }

        public IDbConnection hotelmanagementsqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementsqlConnectionString").Value);
            // Creates an IDbConnection Object to store the sqlconnection.
            IDbConnection con = new SqlConnection(connStr);
            return con;
        }
    }
}
