using System;
using System.Collections.Generic;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class OrderService
    {

        private OrderDao orderDao;

        public OrderService()
        {
            orderDao = new OrderDao();
        }
        public List<Order> GetActiveDrinkOrders()
        {
            return orderDao.GetActiveDrinkOrders();
        }
        public List<Order> GetActiveFoodOrders()
        {
            return orderDao.GetActiveFoodOrders();
        }
        public void GetUpdateStateIsFinished(Order order)
        {
            orderDao.UpdateStateIsFinished(order);
        }//add een orderitem update
        public void CreateCompleteOrder(Order orderToSend)
        {
            orderDao.CreateCompleteOrder(orderToSend);
        }
        public List<Order> GetOrdersForWaiterToDeliver(int staffID)
        {
            return orderDao.GetOrdersForWaiterToDeliver(staffID);
        }

        public List<Order> GetLastOrders()
        {
            return orderDao.GetLastOrders();
        }

        public void UpdateStateIsdelivered(int orderID)
        {
            orderDao.UpdateStateIsdelivered(orderID);
        }
    }
}