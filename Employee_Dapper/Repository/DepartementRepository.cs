using Dapper;
using Employee_Dapper.Entites;
using Employee_Dapper.Interface;
using Employee_Dapper.utils;
using System.Data;

namespace Employee_Dapper.Repository
{
    public class DepartementRepository : IDepartmentRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public DepartementRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddDeparment(Departement deptdetail)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {//Create object for DynamicParameters for storedure input parameter values binding purpose used.
                var p = new DynamicParameters();//DynamicParameters comming from Dapper package
                p.Add("@deptname", deptdetail.deptname);
                p.Add("@deptlocation", deptdetail.deptlocation);
                p.Add("@insertedvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddDepartment, p, commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertedvalue");
                return inserterdid;
            }
        }

        public async  Task<bool> DeleteDepartmentById(int deptid)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteDepartment, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Departement>> GetDepartMentDetails()
        {
            List<Departement> res;
            using (IDbConnection conn = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var queryresult = await conn.QueryAsync<Departement>(StoredProcedureNames.GetDepartment, CommandType.StoredProcedure);
                res = queryresult.ToList();
                return res;
            }
        }

        public async Task<Departement> GetDepartmentDetailsById(int deptid)
        {
            Departement dept;
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptid);
                var result = await con.QueryAsync<Departement>(StoredProcedureNames.GetDepartmentByDeptId, p, commandType: CommandType.StoredProcedure);
                dept = result.FirstOrDefault();
                return dept;
            }
        }

        public async Task<bool> UpdateDepartment(Departement deptdetail)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@deptid", deptdetail.deptid);
                p.Add("@deptname",deptdetail.deptname);
                p.Add("@deptlocation",deptdetail.deptlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateDepartment, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
