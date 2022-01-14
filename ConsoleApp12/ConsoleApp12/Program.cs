using System;
using System.Collections.Generic;
using System.Linq;

namespace Order_Accounting_System
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                List<Customer> customers = new List<Customer>();
                List<Product> products = new List<Product>();
                List<Order> orders = new List<Order>();

                using (var cusReader = new CustomersReader(@"C:\Users\Bazavr\Desktop\IT\Домашняя работа\C#\ConsoleApp12\FileCreator\customers.json"))
                {
                    foreach (var c in cusReader.ReadAll())
                        customers.Add(c);
                }

                using (var productReader = new ProductsReader(@"C:\Users\Bazavr\Desktop\IT\Домашняя работа\C#\ConsoleApp12\FileCreator\product.json"))
                {
                    foreach (var p in productReader.ReadAll())
                        products.Add(p);
                }

                using (var orderReader = new OrdersReader(@"C:\Users\Bazavr\Desktop\IT\Домашняя работа\C#\ConsoleApp12\FileCreator\order.json"))
                {
                    foreach (var o in orderReader.ReadAll())
                        orders.Add(o);
                }

                Console.WriteLine("Customers(Id, Name, Phone):");
                foreach (var r in customers)
                    Console.WriteLine($"{r.Id}, {r.Name}, {r.Phone}");

                Console.WriteLine("\nProducts(Id, Name, Price):");
                foreach (var r in products)
                    Console.WriteLine($"{r.Id}, {r.Name}, {r.Price}");

                Console.WriteLine("\nOrders(CustomerId, ProductId):");
                foreach (var r in orders)
                    Console.WriteLine($"{r.CustomerId}, {r.ProductId}");

                Random rd = new Random();
                int custI = rd.Next(customers.Count);
                int prodI = rd.Next(products.Count);

                Console.WriteLine($"\nСумма заказов заказчика с Id {customers[custI].Id}");
                DataSampling ds = new DataSampling();
                double sumPrice = ds.OrderSumPrice(ref orders, ref products, customers[custI].Id);
                Console.WriteLine($"{sumPrice}");

                Console.WriteLine($"\nКоличество проданного товара с Id {products[prodI].Id}");
                int countProducts = ds.CountSoldProducts(ref orders, ref products, products[prodI].Id);
                Console.WriteLine($"{countProducts}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

        }
    }
}
