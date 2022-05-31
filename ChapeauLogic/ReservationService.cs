using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class ReservationService
    {
        private ReservationDao reservationDb;

        public ReservationService()
        {
            reservationDb = new ReservationDao();
        }
        public void AddNewReservation(string customerFullName, bool isPresent, DateTime reservationTime, int table_ID, string comments, int phoneNumber, string emailAdress)
        {
            reservationDb.AddNewReservation(customerFullName, isPresent, reservationTime, table_ID, comments, phoneNumber, emailAdress);
        }

        public Reservation GetActiveReservationByTableID(int tableID)
        {
            return reservationDb.GetActiveReservationByTableID(tableID);
        }
    }
}
