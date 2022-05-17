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
        public List<MenuItem> menuItems { get; set; }
        public decimal TotalPriceInclVAT { get; set; }
        public decimal TotalPriceExclVAT { get; set; }
        public decimal Tip { get; set; }
        public bool IsPaid { get; set; }
        public decimal Discount { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}
