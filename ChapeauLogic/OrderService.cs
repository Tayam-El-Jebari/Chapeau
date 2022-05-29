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
        public void GetUpdateStateIsFinished(bool isFinished)
        {
            orderDao.UpdateStateIsFinished(isFinished);
        }
        public void UpdateOrders(bool isFinished, DateTime timePlaced, string comments)
        {
            orderDao.UpdateOrders(isFinished, timePlaced, comments);
        }
        public void UpdateOrderItem(int amount)
        {
            orderDao.UpdateOrderItem(amount);
        }

        public void CreateCompleteOrder(List<OrderItem> orderedItem, Reservation reservation, string comments)
        {
            orderDao.CreateCompleteOrder(orderedItem, reservation, comments);
        }
    }
}

