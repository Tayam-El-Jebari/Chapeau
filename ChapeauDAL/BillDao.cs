using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class BillDao : BaseDao
    {
        public List<Bill> GetAllBills()
        {
            string query = "SELECT bill_Id, table_Id, staff_ID, totalPriceInclVAT, totalPriceExclVAT, tip, isPaid, discount, currentDate, comments FROM [Bill]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void AddBill(Bill bill)
        {
            string query = "INSERT INTO [Bill] VALUES (@bill_Id, @table_Id, @staff_ID, @totalPriceInclVAT, @totalPriceExclVAT, @tip, @isPaid, @discount, @currentDate, @comments);";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@bill_Id", bill.BillID);
            sqlParameters[1] = new SqlParameter("@table_Id", bill.TableID);
            sqlParameters[2] = new SqlParameter("@staff_ID", bill.StaffID);
            sqlParameters[3] = new SqlParameter("@totalPriceInclVAT", bill.TotalPriceInclVAT);
            sqlParameters[4] = new SqlParameter("@totalPriceExclVAT", bill.TotalPriceExclVAT);
            sqlParameters[5] = new SqlParameter("@tip", bill.Tip);
            sqlParameters[6] = new SqlParameter("@isPaid", bill.IsPaid);
            sqlParameters[7] = new SqlParameter("@discount", bill.Discount);
            sqlParameters[8] = new SqlParameter("@currentDate", bill.Date);
            sqlParameters[9] = new SqlParameter("@comments", bill.Comments);
            ExecuteEditQuery(query, sqlParameters);
        }
        public List<Bill> ReadTables(DataTable dataTable)
        {
            List<Bill> bills = new List<Bill>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Bill bill = new Bill()
                {
                    BillID = (int)dr["bill_Id"],
                    TableID = (int)dr["table_Id"],
                    StaffID = (int)dr["staff_ID"],
                    TotalPriceInclVAT = (decimal)dr["totalPriceInclVAT"],
                    TotalPriceExclVAT = (decimal)dr["totalPriceExclVAT"],
                    Tip = (decimal)dr["tip"],
                    IsPaid = (bool)dr["isPaid"],
                    Discount = (decimal)dr["discount"],
                    Date = (DateTime)dr["currentDate"],
                    Comments = (string)dr["comments"]
                };
                bills.Add(bill);
            }
            return bills;
        }

        public List<OrderItem> GetMenuItems(int orderId)
        {
            List<OrderItem> orderItem = new List<OrderItem>();
            string query = "SELECT m.menuItem_ID, m.productName, m.price, oi.amount FROM [MenuItem] AS m" +
		    "JOIN [Order_item] AS oi ON m.menuItem_ID = oi.menuItem_ID" +
		    "JOIN [Order] AS o ON o.reservation_Id = 202";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@order_id", orderId);
            
            foreach (DataRow dr in dataTable.Rows)
            {
                OrderItem orderItem = new OrderItem()
                {
                    MenuItemId = (int)dr["menuItem_ID"],
                    ProductName = (string)dr["productName"],
                    Price = (double)dr["price"],
                    Amount = (int)dr["amount"]
                };

                orderItems.Add(order);
            }
            return orderItems;
        }
    }
}
