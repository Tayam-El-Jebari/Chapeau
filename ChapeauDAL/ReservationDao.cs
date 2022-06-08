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
        public List<Reservation> GetAllNonPresentReservationsOrderedByTable()
        {
            string query = "SELECT reservation_id, customerFullName, isPresent, reservationTime, table_ID, comments FROM [Reservation] WHERE isPresent = 0 ORDER BY table_ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void AddNewReservation(string customerFullName, bool isPresent, DateTime reservationTime, int table_ID, string comments, int phoneNumber, string emailAdress)
        {
            string query = "INSERT INTO [Reservation] (customerFullName, isPresent, reservationTime, table_ID, comments, phoneNumber, emailAdress) VALUES (@customerFullName, @isPresent, @reservationTime, 4, @comments, @phoneNumber, @emailAdress);";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@customerFullName", customerFullName);
            sqlParameters[1] = new SqlParameter("@isPresent", isPresent);
            sqlParameters[2] = new SqlParameter("@reservationTime", reservationTime);
            sqlParameters[3] = new SqlParameter("@table_ID", table_ID);
            sqlParameters[4] = new SqlParameter("@comments", comments);
            sqlParameters[5] = new SqlParameter("@phoneNumber", phoneNumber);
            sqlParameters[6] = new SqlParameter("@emailAdress", emailAdress);
            ExecuteEditQuery(query, sqlParameters);
        }

        public Reservation GetPresentReservationByTable(int tableID)
        {
            string query = "SELECT reservation_id, customerFullName, isPresent, reservationTime, table_ID, comments FROM Reservation WHERE table_ID = @table_ID AND isPresent = 1";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@table_ID", tableID);
            return ReadTable(ExecuteSelectQuery(query, sqlParameters));
        }

        public void MarkReservationPresent(int reservationID)
        {
            string query = "UPDATE Reservation SET isPresent = 1 WHERE reservation_id = @reservation_id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@reservation_id", reservationID);
            ExecuteEditQuery(query, sqlParameters);
        }

        public List<Reservation> GetAllPresentReservationsOrderedByTable()
        {
            string query = "SELECT reservation_id, customerFullName, isPresent, reservationTime, table_ID, comments FROM [Reservation] WHERE isPresent = 1 ORDER BY table_ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Reservation> GetAllReservationsForToday()
        {
            string query = "SELECT reservation_id, customerFullName, isPresent, reservationTime, table_ID, comments FROM [Reservation] WHERE CAST(reservationTime AS DATE) = CAST(GETDATE() AS DATE) ORDER BY table_ID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
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
                    Comments = Convert.ToString(dr["comments"]),
                };
                reservations.Add(reservation);
            }
            return reservations;
        }

        private Reservation ReadTable(DataTable dataTable)
        {
            Reservation reservation = new Reservation()
            {
                ReservationId = dataTable.Rows[0].Field<int>("reservation_id"),
                CustomerFullName = dataTable.Rows[0].Field<string>("customerFullName"),
                isPresent = dataTable.Rows[0].Field<bool>("isPresent"),
                ReservationTime = dataTable.Rows[0].Field<DateTime>("reservationTime"),
                TableId = dataTable.Rows[0].Field<int>("table_ID"),
                Comments = dataTable.Rows[0].Field<string>("comments"),
            };
            return reservation;
        }
    }
}
