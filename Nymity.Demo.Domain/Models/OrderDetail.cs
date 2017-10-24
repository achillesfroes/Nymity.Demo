﻿namespace Nymity.Demo.Domain.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public OrderDetail()
        {
            UnitPrice = 0m;
            Quantity = 1;
            Discount = 0f;
        }
    }
}
