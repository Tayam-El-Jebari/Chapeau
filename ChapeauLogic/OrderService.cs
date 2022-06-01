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
        public List<OrderItem> GetActiveDrinkOrders()
        {
            return orderDao.GetActiveDrinkOrders();
        }
        public List<OrderItem> GetActiveFoodOrders()
        {
            return orderDao.GetActiveFoodOrders();
        }
        public void GetUpdateStateIsFinished(OrderItem order)
        {
            orderDao.UpdateStateIsFinished(order);
        }//add een orderitem update
        public void CreateCompleteOrder(List<OrderItem> orderedItem, Reservation reservation, string comments, int staffId)
        {
            orderDao.CreateCompleteOrder(orderedItem, reservation, comments, staffId);
        }
        public List<Order> GetOrdersForWaiterToDeliver(int staffID)
        {
            return orderDao.GetOrdersForWaiterToDeliver(staffID);
        }

        public List<Order> GetLastOrders()
        {
            return orderDao.GetLastOrders();
        }
    }
}

