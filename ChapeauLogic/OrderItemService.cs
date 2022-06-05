using ChapeauDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class OrderItemService
    {
        OrderItemDao orderItemDao;

        public OrderItemService()
        {
            orderItemDao = new OrderItemDao();
        }

        public void UpdateDrinkOrderStatusToDeliverd(int orderID)
        {
            orderItemDao.UpdateDrinkOrderStatusToDeliverd(orderID);
        }

        public void UpdateFoodOrderStatusToDeliverd(int orderID)
        {
            orderItemDao.UpdateFoodOrderStatusToDeliverd(orderID);
        }
    }
}
