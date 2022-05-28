using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Bill
    {
        public int BillID { get; set; }
        public int TableID { get; set; }
        public int StaffID { get; set; }
        public List<OrderItem> MenuItems { get; set; }
        public double TotalPriceInclVAT { get; set; }
        public double TotalPriceExclVAT { get; set; }
        public double TotalVAT { get; set; }
        public double Tip { get; set; }
        public bool IsPaid { get; set; }
        public double Discount { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}
