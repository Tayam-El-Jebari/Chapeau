using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class OrderService
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
        public List<Order> GetActiveDrinkOrders()
        {
            return orderDao.GetActiveDrinkOrders();
        }
        public List<Order> GetActiveFoodOrders()
        {
            return orderDao.GetActiveFoodOrders();
        }
        public void GetUpdateStateIsFinished(bool isFinished)
        {
            orderDao.UpdateStateIsFinished(isFinished);
        }
    }
}

