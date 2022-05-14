using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    class OrderService
    {

        OrderDao orderDao;

        public OrderService()
        {
            orderDao = new OrderDao();
        }

        public List<Order> GetActiveOrders()
        {
            return orderDao.GetActiveOrders();
        }
    }
}

