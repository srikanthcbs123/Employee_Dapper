namespace Employee_Dapper.utils
{
    public static  class StoredProcedureNames
    {
        public static readonly string AddEmployee= "Usp_AddEmployeeReturn";
        public static readonly string UpdateEmployee = "Usp_UpdateEmployee";
        public static readonly string DeleteEmployee = "Usp_DeleteEmployee";
        public static readonly string GetEmployee = "Usp_GetEmployee";
        public static readonly string GetEmployeeByEmpid = "Usp_GetEmployeeId";



        #region OrderStoredProcedures
        public static readonly string AddOrder = "Usp_AddOrder";
        public static readonly string UpdateOrder = "Usp_UpdateOrder";
        public static readonly string DeleteOrder = "Usp_DeleteOrder";
        public static readonly string GetOrder = "Usp_GetOrder";
        public static readonly string GetOrderById = "Usp_GetOrderById";
        #endregion

    }
}
