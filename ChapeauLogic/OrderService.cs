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

        public List<Order> GetActiveOrders()//voor tayam
        {
            return orderDao.GetActiveOrders();
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
        }
        public void CreateCompleteOrder(List<OrderItem> orderedItem, Reservation reservation, string comments)
        {
            orderDao.CreateCompleteOrder(orderedItem, reservation, comments);
        }
    }
}

