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
        public List<MenuItem> GetAllMenuItems(int threeCourseMealCode)
        {
            string query = "SELECT menuItem_ID, productName, price, description FROM [MenuItem] WHERE [threeCourseMealCode] = @threeCourseMealCode";
            SqlParameter[] sqlParameters = new SqlParameter[1]
            {
                new SqlParameter("@threeCourseMealCode", threeCourseMealCode)
            };

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
                        Description = (string)dr["description"]
                    };
                    menuItems.Add(menuItem);
                }
                return menuItems;

            }
            catch
            {
                throw new Exception("No data found in menuitems");
            }

        }
    }
}
