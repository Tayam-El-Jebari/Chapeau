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
        public List<Order> GetOrdersForWaiter(int staffID)
        {
            List<Order> orders = orderDao.GetOrdersForWaiter(staffID);
            foreach(Order order in orders)
            {
                orderDao.GetOrderItemsForOrder(order);
            }
            return orders;
        }

        public List<Order> GetLastOrders()
        {
            return orderDao.GetLastOrders();
        }

        public void UpdateStateIsdelivered(int orderID)
        {
            orderDao.UpdateStateIsdelivered(orderID);
        }

        public void UpdateStateIsFinished(int orderID)
        {
            orderDao.UpdateStateIsFinished(orderID);
        }

        public List<Order> GetFoodOrdersForWaiterToDeliver(int staffID)
        {
            return orderDao.GetFoodOrdersForWaiterToDeliver(staffID);
        }

        public List<Order> GetDrinkOrdersForWaiterToDeliver(int staffID)
        {
            return orderDao.GetDrinkOrdersForWaiterToDeliver(staffID);
        }

        public List<Order> GetOngoingFoodOrdersForWaiter(int staffID)
        {
            return orderDao.GetOngoingFoodOrdersForWaiter(staffID);
        }
        public List<Order> GetOngoingDrinkOrdersForWaiter(int staffID)
        {
            return orderDao.GetOngoingDrinkOrdersForWaiter(staffID);
        }
    }
}

