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
    public class ReservationDao : BaseDao
    {
        public void AddNewReservation(string customerFullName, bool isPresent, DateTime reservationTime, int table_ID, string comments, int phoneNumber, string emailAdress)
        {
            string query = "INSERT INTO [staff] VALUES (@customerFullName, @isPresent, @reservationTime, @table_ID, @comments ,@phoneNumber, @emailAdress);";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@customerFullName", customerFullName);
            sqlParameters[1] = new SqlParameter("@isPresent", isPresent);
            sqlParameters[2] = new SqlParameter("@reservationTime", reservationTime);
            sqlParameters[3] = new SqlParameter("@table_ID", table_ID);
            sqlParameters[4] = new SqlParameter("@comments", comments);
            sqlParameters[5] = new SqlParameter("@phoneNumber", phoneNumber);
            sqlParameters[6] = new SqlParameter("@emailAdress,", emailAdress);
            ExecuteEditQuery(query, sqlParameters);
        }
        private List<Reservation> ReadTables(DataTable dataTable)
        {
            List<Reservation> reservations = new List<Reservation>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Reservation reservation = new Reservation()
                {
                    ReservationId = (int)dr["reservation_id"],
                    CustomerFullName = (string)dr["customerFullName"],
                    isPresent = (bool)dr["isPresent"],
                    ReservationTime = (DateTime)dr["reservationTime"],
                    TableId = (int)dr["table_ID"],
                    Comments = (string)dr["comments"],
                    PhoneNumber = (int)dr["phoneNumber"],
                    EmailAddress = (string)dr["emailAdress"]
                };
                reservations.Add(reservation);
            }
            return reservations;
        }

        private Staff ReadTable(DataTable dataTable)
        {
            Staff staff = new Staff()
            {
                Staff_ID = dataTable.Rows[0].Field<int>("staff_ID"),
                firstName = dataTable.Rows[0].Field<string>("firstName"),
                lastName = dataTable.Rows[0].Field<string>("lastName"),
                phoneNumber = dataTable.Rows[0].Field<int>("phoneNumber"),
                emailAdress = dataTable.Rows[0].Field<string>("emailAdress"),
                salt = dataTable.Rows[0].Field<string>("SALT"),
                passWord = dataTable.Rows[0].Field<string>("password")
            };
            return staff;
        }
    }
}
