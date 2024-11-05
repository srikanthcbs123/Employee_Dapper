using Employee_Dapper.Dtos;
using Employee_Dapper.Entites;

namespace Employee_Dapper.Interface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDtos>> GetEmployees();
        Task<EmployeeDtos> GetEmployeeById(int empid);
        Task<int> AddEmployes(EmployeeDtos empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(EmployeeDtos empdetail);
    }
}
