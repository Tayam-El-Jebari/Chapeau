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
        public List<Order> GetOrdersForWaiterToDeliver(int staffID)
        {
            string query = "SELECT order_id, o.table_Id, o.comments, o.isFinished, o.timePlaced FROM [Order] AS o JOIN [Table] AS t ON t.table_ID = o.table_Id WHERE t.Waiter_ID = @staffID AND isFinished = 1 AND isDelivered IS NULL";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@staffID", staffID);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> GetActiveDrinkOrders()
        {
            string query = "SELECT [Order_Item].order_id, [Order_Item].menuItem_ID, [Order_Item].amount, [MenuItem].productName, [MenuItem].description, [Order].comments, [Order].isFinished, [order].timePlaced FROM[order_Item] JOIN MenuItem ON MenuItem.menuItem_ID = [Order_Item].menuItem_ID JOIN[Order] ON[Order].order_id = [Order_Item].order_id WHERE[Order_Item].order_id in (SELECT order_id FROM[order] WHERE isFinished = 0) AND[order_Item].menuItem_ID IN(select menuItem_ID FROM Drink_Item) ORDER BY[order].timePlaced; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesItem(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> GetActiveFoodOrders()
        {
            string query = "SELECT [Order_Item].order_id, [Order_Item].menuItem_ID, [Order_Item].amount, [MenuItem].productName, [MenuItem].description, [Order].comments, [Order].isFinished, [order].timePlaced FROM[order_Item] JOIN MenuItem ON MenuItem.menuItem_ID = [Order_Item].menuItem_ID JOIN[Order] ON[Order].order_id = [Order_Item].order_id WHERE[Order_Item].order_id in (SELECT order_id FROM[order] WHERE isFinished = 0) AND[order_Item].menuItem_ID NOT IN(select menuItem_ID FROM Drink_Item) ORDER BY[order].timePlaced; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesItem(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Order> GetLastOrders()
        {
            string query = "SELECT o.order_id, o.table_Id, o.comments, o.isFinished, MAX(o.timePlaced) AS timePlaced FROM [Order] AS o JOIN [Reservation] AS r ON r.reservation_id = o.reservation_Id WHERE r.IsPresent = 1 AND o.isDelivered IS NULL GROUP BY o.table_Id";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<OrderItem> ReadTablesItem(DataTable dataTable)
        {
            List<OrderItem> activeOrders = new List<OrderItem>();

            foreach (DataRow dr in dataTable.Rows)
            {

                OrderItem orderItem = new OrderItem()
                {
                    Order = new Order() { OrderId = (int)dr["order_Id"], Comments = Convert.ToString(dr["comments"]), IsFinished = (bool)dr["isFinished"], TimePlaced = (DateTime)dr["timePlaced"] },
                    MenuItem = new MenuItem {MenuItemId = (int)dr["menuItem_ID"], ProductName = (string)dr["productName"], Description = Convert.ToString(dr["description"]), },
                    Amount = (int)dr["amount"],
                };
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

                    //MenuItem = new MenuItem() { ProductName = (string)dr["productName"], Description = (string)dr["description"] },
                    TableId = (int)dr["table_Id"],
                    Comments = Convert.ToString(dr["comments"]),
                    IsFinished = (bool)dr["isFinished"],
                    TimePlaced = (DateTime)dr["timePlaced"]
                };

                activeOrders.Add(order);
            }
            return activeOrders;
        }
        public void UpdateStateIsFinished(OrderItem order)
        {
            string query = $"UPDATE [Order] SET isFinished=@isFinished WHERE order_id=@order_id";
            SqlParameter[] sqlParameters = new SqlParameter[3] {
            new SqlParameter("@isFinished", order.Order.IsFinished),
            new SqlParameter("@order_id", order.Order.OrderId),
            new SqlParameter("@menuItem_ID", order.MenuItem.MenuItemId),
            };
            ExecuteEditQuery(query, sqlParameters);
        }

        public void UpdateStateIsdelivered(int orderID)
        {
            string query = $"UPDATE [Order] SET IsDelivered=1 WHERE order_Id=@orderID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@orderID", orderID);
            ExecuteEditQuery(query, sqlParameters);
        }


        public void CreateCompleteOrder(List<OrderItem> orderedItem, Reservation reservation, string comments, int staffId)
        {
            string query = "INSERT INTO [Order](reservation_Id, table_Id, isFinished, timePlaced, comments) VALUES (@reservationId, @tableId, 0, @currentTime, @comments);";
            SqlParameter[] sqlParameters = new SqlParameter[4]
            {
                new SqlParameter("@reservationId", reservation.ReservationId),
                new SqlParameter("@tableId", reservation.TableId),
                new SqlParameter("@currentTime", DateTime.Now),
                new SqlParameter("@comments", comments),
            };
            ExecuteEditQuery(query, sqlParameters);
            foreach (OrderItem orderItem in orderedItem)
            {
                query = "INSERT INTO[order_Item](order_id, menuItem_Id, amount) VALUES((SELECT TOP 1 order_id FROM [Order] ORDER BY order_id DESC), @menuItemId, @amount);" +
                    "UPDATE [menuItem] SET [stock] = [stock] - @amount WHERE [menuItem_ID] = @menuItemId;" +
                    "UPDATE [Table] SET [Waiter_id] = @staffId WHERE [table_ID] = @tableId;";
                sqlParameters = new SqlParameter[5]
                {
                     new SqlParameter("@orderId", 7),
                     new SqlParameter("@menuItemId", orderItem.MenuItem.MenuItemId),
                     new SqlParameter("@amount", orderItem.Amount),
                     new SqlParameter("@staffId", staffId),
                     new SqlParameter("@tableId", reservation.TableId),
                };
                ExecuteEditQuery(query, sqlParameters);
            }
        }
    }
}
