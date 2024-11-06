namespace Employee_Dapper.utils
{
    public static  class StoredProcedureNames
    {
        #region EmployeeStoredProcedure Details
        public static readonly string AddEmployee= "Usp_AddEmployeeReturn";
        public static readonly string UpdateEmployee = "Usp_UpdateEmployee";
        public static readonly string DeleteEmployee = "Usp_DeleteEmployee";
        public static readonly string GetEmployee = "Usp_GetEmployee";
        public static readonly string GetEmployeeByEmpid = "Usp_GetEmployeeId";
        #endregion

        #region DepartmentDetails
        public static readonly string AddDepartment = "Usp_AddDepartment";
        public static readonly string UpdateDepartment = "Usp_UpdateDepartment";
        public static readonly string DeleteDepartment = "Usp_DeleteDepartment";
        public static readonly string GetDepartment = "Usp_GetDepartment";
        public static readonly string GetDepartmentByDeptId = "Usp_GetDepartmentById";
        #endregion

    }
}
