using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order_Accounting_System
{
    class DataSampling
    {
        public double OrderSumPrice(ref List<Order> orders, ref List<Product> products, Guid customerId)
        {
            double sumPrice = 0.0;
            var sum = from o in orders
                      join p in products on o.ProductId
                      equals p.Id
                      where o.CustomerId == customerId
                      select p.Price;
            foreach (var r in sum)
                sumPrice += r;
            return sumPrice;
        }

        public int CountSoldProducts(ref List<Order> orders, ref List<Product> products, Guid productId)
        {
            int countProducts = 0;
            var count = from o in orders
                        join p in products on o.ProductId
                        equals p.Id
                        where o.ProductId == productId
                        select p.Id;
            foreach (var r in count)
                countProducts++;
            return countProducts;
        }
    }
}
