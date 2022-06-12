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
        public void AddNewReservation(Reservation reservation)
        {
            reservationDb.AddNewReservation(reservation);
        }

        public void MarkReservationPresent(int reservationID)
        {
            reservationDb.MarkReservationPresent(reservationID);
        }

        public Reservation GetPresentReservationByTable(int tableID)
        {
            return reservationDb.GetPresentReservationByTable(tableID);
        }

        public List<Reservation> GetAllNonPresentReservationsOrderedByTable()
        {
            return reservationDb.GetAllNonPresentReservationsOrderedByTable();
        }

        public List<Reservation> GetAllPresentReservationsOrderedByTable()
        {
            return reservationDb.GetAllPresentReservationsOrderedByTable();
        }

        public List<Reservation> GetAllReservationsForToday()
        {
            return reservationDb.GetAllReservationsForToday();
        }
    }
}
