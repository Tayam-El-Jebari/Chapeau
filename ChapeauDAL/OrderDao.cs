using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ChapeauModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderDao : BaseDao
    {
        public List<Order> GetActiveOrders()
        {
            string query = "SELECT * FROM [Order] WHERE isFinished = 0";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> activeOrders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    OrderId = (int)dr["order_Id"],
                    menuItemId = (int)dr["menuitem_Id"],
                    reservationId = (int)dr["reservation_Id"],
                    tableId = (int)dr["menuitem_Id"],
                    comments = (string)dr["comments"],
                    isFinished = (bool)dr["isFinished"]
                };

                activeOrders.Add(order);
            }
            return activeOrders;
        }
    }
}
