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
        public int MenuItemId { get; set; }
        public int Amount { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public bool IsFinished { get; set; }
        public DateTime TimePlaced { get; set; }
    }
}
