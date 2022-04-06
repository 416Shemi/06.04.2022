using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp32.Models;
using Newtonsoft.Json;

namespace ConsoleApp32
{
    class Program
    {
        static void Main(string[] args)
        {
            Product bmw = new Product { Id = 1, Name = "M5", Price = 30000 };
            Product audi = new Product { Id = 2, Name = "Q7", Price = 120000 };
            Product mercedes = new Product { Id = 3, Name = "Benz", Price = 95000 };
            Product tayota = new Product { Id = 4, Name = "camry", Price = 60000 };

            Orderitem item1 = new Orderitem { Id = 1, Product = bmw, Count = 1 };
            item1.TotalPrice = item1.Count * bmw.Price;
            Orderitem item2 = new Orderitem { Id = 2, Product = audi, Count = 2 };
            item2.TotalPrice = item2.Count * audi.Price;
            Orderitem item3 = new Orderitem { Id = 3, Product = mercedes, Count = 5};
            item3.TotalPrice = item3.Count * mercedes.Price;
            Orderitem item4 = new Orderitem { Id = 4, Product = tayota, Count = 1 };
            item4.TotalPrice = item4.Count * tayota.Price;

            List<Orderitem> orderitems1 = new List<Orderitem>();
            orderitems1.Add(item1);
            orderitems1.Add(item3);
            orderitems1.Add(item2);
            orderitems1.Add(item4);


            Order order1 = new Order { Id = 1, OrderItems = orderitems1 };
            var jsonObj = JsonConvert.SerializeObject(order1);

            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directoryInfo.Name != typeof(Program).Namespace)
            {
                directoryInfo = directoryInfo.Parent;
            }

            Console.WriteLine(jsonObj);
            using (StreamWriter sw = new StreamWriter(directoryInfo + @"\json1.json"))
                sw.WriteLine(jsonObj);
            

            string result;
            using (StreamReader sr = new StreamReader(directoryInfo + @"\Sadiqinfayli.json"))
                result = sr.ReadToEnd();

            Order o1 = JsonConvert.DeserializeObject<Order>(result);
            List<Orderitem> orederlist = o1.OrderItems;
            foreach (var element in orederlist)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Id:" + element.Id);
                Console.WriteLine("Product:" + element.Product.Name);
                Console.WriteLine("Price:" + element.Product.Price);
                Console.WriteLine("Count:" + element.Count);
                Console.WriteLine("Total Price:" + element.TotalPrice);
            }
        }
    }
}
