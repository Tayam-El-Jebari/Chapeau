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
    }
}
