using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int MenuItemID { get; set; }
        public int Amount { get; set; }
    }
}
