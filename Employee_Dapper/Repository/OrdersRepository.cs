using Dapper;
using Employee_Dapper.Entites;
using Employee_Dapper.Interface;
using Employee_Dapper.utils;
using System.Data;

namespace Employee_Dapper.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public OrdersRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddOrder(Orders orderdetail)
        {
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {//Create object for DynamicParameters for storedure input parameter values binding purpose used.
                var p = new DynamicParameters();//DynamicParameters comming from Dapper package
                p.Add("@ordername", orderdetail.ordername);
                p.Add("@orderlocation", orderdetail.orderlocation);
                p.Add("@insertedvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddOrder, p, commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertedvalue");
                return inserterdid;
            }
        }

        public async Task<bool> DeleteOrderById(int orderid)
        {
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteOrder, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<Orders> GetOrderById(int orderid)
        {
            Orders order;
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderid);
                var result = await con.QueryAsync<Orders>(StoredProcedureNames.GetOrderById, p, commandType: CommandType.StoredProcedure);
                order = result.FirstOrDefault();
                return order;
            }
        }

        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> res;
            using (IDbConnection conn = _connectionFactory.MidLandSqlConnectionString())
            {
                var queryresult = await conn.QueryAsync<Orders>(StoredProcedureNames.GetOrder, CommandType.StoredProcedure);
                res = queryresult.ToList();
                return res;
            }
        }

        public  async Task<bool> UpdateOrder(Orders orderdetail)
        {
            using (IDbConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                var p = new DynamicParameters();
                p.Add("@orderid", orderdetail.orderid);
                p.Add("@ordername",orderdetail.ordername);
                p.Add("@orderlocation ",orderdetail.orderlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateOrder, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
