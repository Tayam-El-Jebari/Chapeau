using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public int TableID { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsReserverd { get; set; }
        public int AmountOfSeats { get; set; }
        public int WaiterID { get; set; }
        public string Description { get; set; }
    }
}
