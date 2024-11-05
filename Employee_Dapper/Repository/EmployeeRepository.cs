using Dapper;//Import the dapper package
using Employee_Dapper.Entites;
using Employee_Dapper.Interface;
using System.Data;
using Employee_Dapper.utils;
namespace Employee_Dapper.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IEmpConnectionFactory _connectionFactory;
        //Constructor injection for iplemeting loosly coupled between the classes.
        public EmployeeRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddEmployes(Employee empdetail)
        {
            using (IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {//Create object for DynamicParameters for storedure input parameter values binding purpose used.
                var p = new DynamicParameters();//DynamicParameters comming from Dapper package
                p.Add("@empname", empdetail.empname);
                p.Add("@empsalary", empdetail.empsalary);
                p.Add("@insertvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddEmployee, p, commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertvalue");
                return inserterdid;
            }
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
           using(IDbConnection con=_connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p= new DynamicParameters();
                p.Add("@empid", empid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteEmployee,p, commandType: CommandType.StoredProcedure);
                return true;    
            }
        }

        public  async Task<Employee> GetEmployeeById(int empid)
        {
            Employee emp;
            using (IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@empid", empid);
                var result=await con.QueryAsync<Employee>(StoredProcedureNames.GetEmployeeByEmpid,p, commandType: CommandType.StoredProcedure);
                emp=result.FirstOrDefault();
                return emp;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List <Employee> res;
            using(IDbConnection conn=_connectionFactory.hotelmanagementsqlConnectionString())
            {
                var queryresult=await conn.QueryAsync<Employee>(StoredProcedureNames.GetEmployee, CommandType.StoredProcedure);
                res = queryresult.ToList();
                return res;
            }
            
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {
            using (IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@empid", empdetail.empid);
                p.Add("@empname", empdetail.empname);
                p.Add("@empsalary", empdetail.empsalary);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateEmployee,p,commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
