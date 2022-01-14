using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Accounting_System
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product() { }
        public Product(Guid id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
