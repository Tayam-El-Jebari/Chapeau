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
        private BillDao billdb;

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
            double vat = 0;
            double totalPrice = 0;

            //1 minder
            ICalculateVAT calculateHighVAT = new CalculateHighVAT();
            Bill bill = new Bill();
            List<OrderItem> highVatItems = SortList(billdb.GetHighVAT(reservationId));
            //1 lijst
            if (highVatItems != null)
            {
                foreach (OrderItem hvItem in highVatItems)
                {
                    double tempTotalPrice = (hvItem.Amount * hvItem.MenuItem.Price);
                    vat += calculateHighVAT.CalculateVAT(tempTotalPrice);
                    totalPrice += tempTotalPrice;
                }
            }

            bill.TotalPriceInclVAT = totalPrice;
            bill.TotalPriceExclVAT = totalPrice - vat;
            bill.TotalVAT = vat;
            bill.MenuItems = highVatItems;

            return bill;
        }

        public List<OrderItem> SortList(List<OrderItem> orderItems)
        {
            for (int i = 0; i < orderItems.Count - 1; i++)
            {
                if (orderItems[i].MenuItem.MenuItemId == orderItems[i + 1].MenuItem.MenuItemId)
                {
                    orderItems[i].Amount = orderItems[i].Amount + orderItems[i+ 1].Amount;
                    orderItems.RemoveAt(i + 1);
                    i--;
                }
            }
            return orderItems;
        }
    }
}
