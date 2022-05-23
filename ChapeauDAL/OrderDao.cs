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
        public List<Order> GetActiveOrders()//voor tayam, mist readtables
        {
            string query = "SELECT order_id, m.productName, m.[description], o.table_Id, o.comments, o.isFinished FROM [Order] AS o JOIN MenuItem AS m ON o.menuItem_ID = m.menuItem_ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> GetActiveDrinkOrders()
        {
            string query = "SELECT  o.order_id, m.productName, oi.amount, m.[description], o.table_Id, o.comments, o.isFinished FROM[Order] AS o, [Order_Item] AS oi, MenuItem AS m WHERE m.menuItem_ID IN(SELECT menuItem_Id FROM[Drink_Item] WHERE  o.isFinished = 'FALSE')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesItem(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> GetActiveFoodOrders()
        {
            string query = "SELECT o.order_id, o.reservation_Id, m.productName, oi.amount, m.[description], o.table_Id, o.comments, o.isFinished, o.timePlaced FROM[Order] AS o, [Order_Item] AS oi, MenuItem AS m WHERE m.menuItem_ID IN(SELECT menuItem_Id FROM[Dinner_Item][Lunch_Item] WHERE  o.isFinished = 'FALSE')";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesItem(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> ReadTablesItem(DataTable dataTable)
        {
            List<OrderItem> activeOrders = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderId = (int)dr["order_Id"],
                    ReservationId = (int)dr["reservation_Id"],
                    ProductName =  (string)dr["productName"],
                    Amount = (int)dr["amount"],
                    Description = (string)dr["description"],
                    TableId = (int)dr["table_Id"],
                    Comments = ConvertFromDR<string>(dr["comments"]),
                    IsFinished = (bool)dr["isFinished"],
                    TimePlaced = (DateTime)dr["timePlaced"]
                };
                /*Order order = new Order()
                {

                };*/

                activeOrders.Add(orderItem);
            }
            return activeOrders;
        }
        public List<Order> ReadTables(DataTable dataTable)
        {
            List<Order> activeOrders = new List<Order>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order()
                {
                    OrderId = (int)dr["order_Id"],
                    ProductName = (string)dr["productName"],
                    ProductDescription = (string)dr["description"],
                    TableId = (int)dr["table_Id"],
                    Comments = ConvertFromDR<string>(dr["comments"]),
                    IsFinished = (bool)dr["isFinished"],
                };

                activeOrders.Add(order);
            }
            return activeOrders;
        }
        private T ConvertFromDR<T>(object obj)
        {
            if (obj == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)obj;
            }
        }
        public void UpdateStateIsFinished(bool isFinished)
        {
            string query = $"UPDATE Order SET IsFinished=@IsFinished WHERE IsFinished='{isFinished}'";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@IsFinished", isFinished);
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}
