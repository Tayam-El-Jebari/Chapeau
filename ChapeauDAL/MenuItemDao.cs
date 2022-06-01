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
    public class MenuItemDao : BaseDao
    {
        public List<MenuItem> GetAllMenuItems(bool isLunch)
        {
            string query = SelectQuery(isLunch);

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private string SelectQuery(bool isLunch)
        {
            if (isLunch)
            {
                return "SELECT menuItem_ID, productName, price, [description], stock, threeCourseMealCode FROM [MenuItem] WHERE menuItem_ID IN (select * FROM Lunch_Item) OR menuItem_ID IN (select menuItem_Id FROM [Drink_Item])";
            }
            else
            {
                return "SELECT menuItem_ID, productName, price, [description], stock, threeCourseMealCode FROM [MenuItem] WHERE menuItem_ID IN (select * FROM Dinner_Item) OR menuItem_ID IN (select menuItem_Id FROM [Drink_Item]);";
            }
        }
        public List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            try
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    MenuItem menuItem = new MenuItem()
                    {
                        MenuItemId = (int)dr["menuItem_ID"],
                        ProductName = (string)dr["productName"],
                        Price = (double)dr["price"],
                        Description = Convert.ToString(dr["description"]),
                        stock = (int)dr["stock"],
                        MenuItemType = (MenuItemType)dr["ThreeCourseMealCode"]
                    };
                    menuItems.Add(menuItem);
                }
                return menuItems;

        }
            catch
            {
                throw new Exception("Something went wrong loading items from database. Please contact an administrator of the system.");
            }

}
    }
}
