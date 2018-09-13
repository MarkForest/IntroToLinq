using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        class Program
        {
            static void Main(string[] args)
            {
                LinqMethod();
                LinqToObject();
                Console.ReadKey();
            }

            private static void LinqToObject()
            {
                List<Product> products = GetProducts();
                var maxPrice = products.Select(p => p.Price).Max();
                var prod = products.First(x => x.Price == maxPrice);
                Console.WriteLine(prod.Name);

                Console.WriteLine(products.Count(p => p.Price > 10 && p.Price <= 20));

            }


            private static List<Product> GetProducts()
            {
                return new List<Product> {
                    new Product{ Name = "Snickers", Price = 20},
                    new Product{ Name = "Sckittels", Price = 30},
                    new Product{ Name = "Blend-a-med", Price = 40},
                    new Product{ Name = "Bud", Price = 15},
                    new Product{ Name = "Butter", Price = 35},
                    new Product{ Name = "Kinder Surpris", Price = 20}
                };
            }

            private static void LinqMethod()
            {

                //масив - источник данных
                string[] countries = {"Albania", "UK",
                "Lithuania", "Andorra", "Austria",
                "Latvia", "Liechtenstein", "Switzerland",
                "Ireland", "Sweden","Italy", "France",
                "Liechtenstein", "Spain", "Turkey", "Germany",
                "Switzerland", "Monaco", "Montenegro",
                "Norway", "Finland", "Turkey", "UK", "Poland",
                "Portugal", "Lithuania", "Luxembourg"
             };

                //Linq запрос
                var result = from country in countries where country.StartsWith("L") select country;
                foreach (var r in result)
                {
                    Console.WriteLine($"{r}: {r.GetType().Name}");
                }
                result = countries.Where(c => c.StartsWith("L"));
                foreach (var r in result)
                {
                    Console.WriteLine($"{r}: {r.GetType().Name}");
                }







                var result2 = (from c in countries where c.StartsWith("L")
                               orderby c.Length descending
                               select c).Distinct();
                foreach (var r in result2)
                {
                    Console.WriteLine($"{r}");
                }
                result2 = countries.OrderByDescending(c => c.Length).Where(c => c.StartsWith("L")).Distinct();
                foreach (var r in result2)
                {
                    Console.WriteLine($"{r}");
                }

            }
        }
    }
}
