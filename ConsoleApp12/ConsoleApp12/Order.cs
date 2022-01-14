using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Accounting_System
{
    public class Order
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }

        public Order() { }
        public Order(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }


    }
}
