using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderItemDao : BaseDao
    {
        public void UpdateDrinkOrderStatusToDeliverd(int orderID)
        {
            string query = "UPDATE [Order_Item] SET[Status] = 2 WHERE order_id = @orderID AND menuItem_ID in (SELECT menuItem_ID FROM Drink_Item)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@orderID", orderID);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void UpdateFoodOrderStatusToDeliverd(int orderID)
        {
            string query = "UPDATE [Order_Item] SET[Status] = 2 WHERE order_id = @orderID AND menuItem_ID NOT in (SELECT menuItem_ID FROM Drink_Item)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@orderID", orderID);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
