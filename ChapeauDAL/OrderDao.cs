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
        public List<Order> GetActiveOrders()//voor tayam, mist readtables
        {
            string query = "SELECT order_id, m.productName, m.[description], o.table_Id, o.comments, o.isFinished FROM [Order] AS o JOIN MenuItem AS m ON o.menuItem_ID = m.menuItem_ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
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
                    OrderId = (int)dr["order_Id"],
                    MenuItemId = (int)dr["menuItem_ID"],
                    ProductName =  (string)dr["productName"],
                    Amount = (int)dr["amount"],
                    Description = Convert.ToString(dr["description"]),
                    Comments = Convert.ToString(dr["comments"]),
                    IsFinished = (bool)dr["isFinished"],
                    TimePlaced = (DateTime)dr["timePlaced"]
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


        public void CreateCompleteOrder(List<OrderItem> orderedItem, Reservation reservation, string comments)
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
                query = "INSERT INTO[order_Item](order_id, menuItem_Id, amount) VALUES((SELECT TOP 1 order_id FROM [Order] ORDER BY order_id DESC), @menuItemId, @amount);";
                sqlParameters = new SqlParameter[3]
                {
                     new SqlParameter("@orderId", 7),
                     new SqlParameter("@menuItemId", orderItem.MenuItemID),
                     new SqlParameter("@amount", orderItem.Amount),
                };
                ExecuteEditQuery(query, sqlParameters);
            }
        }
    }
}
