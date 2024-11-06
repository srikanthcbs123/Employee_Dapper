using Employee_Dapper.Entites;

namespace Employee_Dapper.Interface
{
    public interface IDepartementService
    {
       Task<List<DepartementDto>> GetDepartMentDetails();
        Task<DepartementDto> GetDepartmentDetailsById(int deptid);
        Task<int> AddDeparment(DepartementDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartementDto deptdetail);
    }
}
