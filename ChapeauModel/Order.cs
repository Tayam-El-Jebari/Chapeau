using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public int menuItemId { get; set; }
        public float reservationId { get; set; }
        public int tableId { get; set; }
        public string comments { get; set; }
        public bool isFinished { get; set; }
    }
}
