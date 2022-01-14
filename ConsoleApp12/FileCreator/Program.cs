using System;
using Order_Accounting_System;
using System.Collections.Generic;

namespace FileCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                List<Customer> cus = new List<Customer>()
                {
                new Customer(Guid.NewGuid(), "Name1", "9163736-)2", "gidhj@madfb.sdh"),
                new Customer(Guid.NewGuid(), "Name2", "9165562", "grth@mrthb.sdh")
                };
                using (var customerJson = new CustomerFileCreator(@"C:\Users\Bazavr\Desktop\IT\Домашняя работа\C#\ConsoleApp12\FileCreator\customers.json"))
                {
                    customerJson.WriteAll(ref cus);
                }

                List<Product> prod = new List<Product>()
                {
                new Product(Guid.NewGuid(), "Product1", 23.9),
                new Product(Guid.NewGuid(), "Product2", 23.7),
                new Product(Guid.NewGuid(), "Product3", 123.46),
                new Product(Guid.NewGuid(), "Product4", 34.45)
                };
                using (var productJson = new ProductFileCreator(@"C:\Users\Bazavr\Desktop\IT\Домашняя работа\C#\ConsoleApp12\FileCreator\product.json"))
                {
                    productJson.WriteAll(ref prod);
                }

                Random rd = new Random();
                List<Order> ord = new List<Order>();
                for (int i = 0; i < 10; i++)
                {
                    ord.Add(new Order(cus[rd.Next(cus.Count)].Id, prod[rd.Next(prod.Count)].Id));
                }
                using (var orderJson = new OrderFileCreator(@"C:\Users\Bazavr\Desktop\IT\Домашняя работа\C#\ConsoleApp12\FileCreator\order.json"))
                {
                    orderJson.WriteAll(ref ord);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
