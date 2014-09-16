﻿using System;
using System.Globalization;

namespace Restaurant
{
    public class Waiter
    {
        private readonly IHandleOrder _orderHandler;
        private int orderId = 1;

        public Waiter(IHandleOrder orderHandler)
        {
            _orderHandler = orderHandler;
        }

        public string PlaceOrder()
        {
            var order = new Order
            {
                OrderId = orderId++.ToString(CultureInfo.InvariantCulture),
                TableNumber = 5,
                ServerName = "Dave",
                TimeStamp = DateTime.Now.ToShortTimeString(),
                Items = new[]
                {
                    new OrderItem {ItemName = "Spaghetti Bolognese", Qty = 2},
                    new OrderItem {ItemName = "Fish", Qty = 3 },
                }
            };
            _orderHandler.HandleOrder(order);
            return order.OrderId;
        } 
    }
}
