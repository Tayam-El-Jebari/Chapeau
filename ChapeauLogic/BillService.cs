using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class BillService
    {
        const double HighVat = 21;
        const int LowVat = 6;

        BillDao billdb;

        public BillService()
        {
            billdb = new BillDao();
        }

        public List<Bill> GetBills()
        {
            List<Bill> bills = billdb.GetAllBills();
            return bills;
        }

        public void AddBill(Bill bill)
        {
            billdb.AddBill(bill);
        }
        public Bill MakeBill(int reservationId)
        {
            double VAT = 0;
            double TotalPrice = 0;

            Bill bill = new Bill();
            List<OrderItem> lowVatItems = SortList(billdb.GetLowVAT(reservationId));
            List<OrderItem> highVatItems = SortList(billdb.GetHighVAT(reservationId));
            

            foreach (OrderItem hvItem in highVatItems)
            {
                VAT += (hvItem.Price + HighVat) / (100 + HighVat);
                bill.MenuItems.Add(hvItem);
                TotalPrice += hvItem.Price;
            }
            foreach (OrderItem lvItem in lowVatItems)
            {
                VAT += (lvItem.Price + HighVat) / (100 + HighVat);
                bill.MenuItems.Add(lvItem);
                TotalPrice += lvItem.Price;
            }
            foreach (OrderItem lvItem in lowVatItems)
            {
                highVatItems.Add(lvItem);
            }

            bill.TotalPriceInclVAT = TotalPrice;
            bill.TotalPriceExclVAT = TotalPrice - VAT;
            bill.TotalVAT = VAT;
            bill.MenuItems = highVatItems;

            return bill;
        }
        public int BillID { get; set; }
        public int TableID { get; set; }
        public int StaffID { get; set; }
        public List<OrderItem> MenuItems { get; set; }
        public decimal TotalPriceInclVAT { get; set; }
        public decimal TotalPriceExclVAT { get; set; }
        public decimal Tip { get; set; }
        public bool IsPaid { get; set; }
        public decimal Discount { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }

        public List<OrderItem> SortList(List<OrderItem> orderItems)
        {
            for (int i = 0; i < orderItems.Count; i++)
            {
                if (orderItems[i].MenuItem == orderItems[i + 1].MenuItem)
                {
                    orderItems[i + 1].Amount += orderItems[i].Amount;
                    orderItems.Remove(orderItems[i]);
                }
            }
            return orderItems;
        }
    }
    
}
