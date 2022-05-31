﻿using System;
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
        public List<OrderItem> GetActiveDrinkOrders()
        {
            string query = "select [Order_Item].order_id, [Order_Item].menuItem_ID, [Order_Item].amount, [MenuItem].productName, [MenuItem].description, [Order].comments, [Order].isFinished FROM[order_Item] JOIN MenuItem ON MenuItem.menuItem_ID = [Order_Item].menuItem_ID JOIN[Order] ON[Order].order_id = [Order_Item].order_id WHERE[Order_Item].order_id in (SELECT order_id FROM[order] WHERE isFinished = 0) AND[order_Item].menuItem_ID IN(select menuItem_ID FROM Drink_Item); ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesItem(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<OrderItem> GetActiveFoodOrders()
        {
            string query = "SELECT [Order_Item].order_id, [Order_Item].menuItem_ID, [Order_Item].amount, [MenuItem].productName, [MenuItem].description, [Order].comments, [Order].isFinished FROM[order_Item] JOIN MenuItem ON MenuItem.menuItem_ID = [Order_Item].menuItem_ID JOIN[Order] ON[Order].order_id = [Order_Item].order_id WHERE[Order_Item].order_id in (SELECT order_id FROM[order] WHERE isFinished = 0) AND[order_Item].menuItem_ID NOT IN(select menuItem_ID FROM Drink_Item); ";
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
                    Order = new Order() { OrderId = (int)dr["order_Id"], Comments = Convert.ToString(dr["comments"]), IsFinished = (bool)dr["isFinished"], TimePlaced = (DateTime)dr["timePlaced"] },
                    MenuItem = new MenuItem { ProductName = (string)dr["productName"], Description = Convert.ToString(dr["description"]), },
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
                    TableId = (int)dr["table_Id"],
                    Comments = Convert.ToString(dr["comments"]),
                    IsFinished = (bool)dr["isFinished"],
                };

                activeOrders.Add(order);
            }
            return activeOrders;
        }

        public void UpdateStateIsFinished(bool isFinished)
        {
            string query = $"UPDATE Order SET IsFinished=@IsFinished WHERE IsFinished='{isFinished}'";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@IsFinished", isFinished);
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
