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

        public Bill CalculateVAT(List<OrderItem> bill)
        {
            float VAT;
                        
            //VAT = (price + VATPercentage) / (100 + VATPercentage);

        }
        public List<OrderItem> CompleteBill(int reservationId)
        {
            List<OrderItem> orderItems = billdb.GetOrderItems(reservationId);
            
            for (int i = 0; i < orderItems.Count; i++)
            {
                if (orderItems[i].MenuItemId == orderItems[i + 1].MenuItemId)
                {
                    orderItems[i + 1].Amount += orderItems[i].Amount;
                    orderItems.Remove(orderItems[i]);
                }
            }

            return orderItems;
        }
    }
    }
}
