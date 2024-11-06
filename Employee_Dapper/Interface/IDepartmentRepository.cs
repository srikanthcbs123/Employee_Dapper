using Employee_Dapper.Entites;

namespace Employee_Dapper.Interface
{
    public interface IDepartmentRepository
    {
        Task<List<Departement>> GetDepartMentDetails();
        Task<Departement> GetDepartmentDetailsById(int deptid);
        Task<int> AddDeparment(Departement deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(Departement deptdetail);
    }
}
