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

        public string GetAllSaltByID(int staffID)
        {
            string query = "SELECT salt FROM [staff] WHERE staff_ID = @staffID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@staffID", staffID);
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            try
            {
                return dataTable.Rows[0].Field<string>("SALT").ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("No user found by that name!");
            }
        }

        public Staff CheckPassword(int staffID, string hashedPassword)
        {
            string query = "SELECT salt FROM [staff] WHERE staff_ID = @staffID AND password = @password";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@staffID", staffID);
            sqlParameters[1] = new SqlParameter("@password", hashedPassword);
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            try
            {
                return null;
                //return ReadTable(dataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("No user found by that name!");
            }
        }
        public void AddNewStaffMember(string firstname, string lastname, int phonenumber, string email, HashWithSaltResult hashedPassword)
        {
            string query = "INSERT INTO [staff] VALUES (@firstname, @lastname, @phonenumber, @email, @salt ,@password);";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@firstname", firstname);
            sqlParameters[1] = new SqlParameter("@lastname", lastname);
            sqlParameters[2] = new SqlParameter("@phonenumber", phonenumber);
            sqlParameters[3] = new SqlParameter("@email", email);
            sqlParameters[4] = new SqlParameter("@salt", hashedPassword.Salt);
            sqlParameters[5] = new SqlParameter("@password", hashedPassword.Hash);
            ExecuteEditQuery(query, sqlParameters);
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

        private Staff ReadTable(DataTable dataTable)
        {
            Staff staff;
            foreach (DataRow dr in dataTable.Rows)
            {
                staff = new Staff()
                {
                    Staff_ID = (int)dr["staff_ID"],
                    firstName = (string)dr["firstName"],
                    lastName = (string)dr["lastName"],
                    phoneNumber = (int)dr["phoneNumber"],
                    emailAdress = (string)dr["emailAdress"],
                    salt = (string)dr["salt"],
                    passWord = (string)dr["password"]
                };
                return staff;
            }
            return null;
        }
    }
}



