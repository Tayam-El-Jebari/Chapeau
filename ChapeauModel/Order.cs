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
        public int TableId { get; set; }
        public string Comments { get; set; }
        public DateTime TimePlaced { get; set; }
    }
}
