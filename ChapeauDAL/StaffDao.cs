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
    public class StaffDao : BaseDao
    {
        public List<Staff> GetAllStaffs()
        {
            string query = "SELECT staff_ID, firstName, lastName, phoneNumber, emailAdress, salt, password FROM [staff]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Staff> ReadTables(DataTable dataTable)
        {
            List<Staff> staffs = new List<Staff>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Staff staff = new Staff()
                {
                    Staff_ID = (int)dr["staff_ID"],
                    firstName = (string)dr["firstName"],
                    lastName = (string)dr["lastName"],
                    phoneNumber = (int)dr["phoneNumber"],
                    emailAdress = (string)dr["emailAdress"],
                    salt = (string)dr["salt"],
                    passWord = (string)dr["password"]
                };
                staffs.Add(staff);
            }
            return staffs;
        }
    }
}



