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
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT menuItem_ID, productName, price, [description], stock, threeCourseMealCode, menuType FROM [MenuItem]";

        SqlParameter[] sqlParameters = new SqlParameter[0];

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
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
                        MenuItemType = (MenuItemType)dr["ThreeCourseMealCode"],
                        MenuType = (MenuType)dr["MenuType"]
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
