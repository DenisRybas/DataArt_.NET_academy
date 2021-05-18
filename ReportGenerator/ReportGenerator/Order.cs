using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator
{
    public class Order
    {
        public Order(string email, DateTime dateTime, IReadOnlyList<OrderItem> items)
        {
            Email = email;
            DateTime = dateTime;
            Items = items;
        }

        public string Email { get; }
        public DateTime DateTime { get; }
        public IReadOnlyList<OrderItem> Items { get; }

        public Order AppendItem(OrderItem item)
        {
            return new Order(Email, DateTime, Items.Append(item).ToArray());
        }
    }

    public class OrderItem
    {
        public OrderItem(string productCode, int quantity)
        {
            ProductCode = productCode;
            Quantity = quantity;
        }

        public string ProductCode { get; }
        public int Quantity { get; }
    }
}
