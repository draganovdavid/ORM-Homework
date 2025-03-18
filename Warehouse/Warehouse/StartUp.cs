namespace Warehouse
{
    using Microsoft.EntityFrameworkCore;
    using Warehouse.Data.Models;

    class Program
    {
        static void Main()
        {
            using var WarehouseDbcontext = new WarehouseContext();

            if (!WarehouseDbcontext.Database.CanConnect())
            {
                Console.WriteLine("Database does not exist. Creating now...");
                WarehouseDbcontext.Database.EnsureCreated();
                Console.WriteLine("Database Warehouse was created!");
            }
            else
            {
                Console.WriteLine("Database already exist.");
            }

            if (!WarehouseDbcontext.Products.Any())
            {
                var product1 = new Product { Name = "Phone" };
                var product2 = new Product { Name = "Laptop" };

                WarehouseDbcontext.Products.AddRange(product1, product2);
                WarehouseDbcontext.SaveChanges();
            }

            AddProduct("PC"); // Добавя продукт.

            BuyProduct("David", 1); // Добавя купувач в таблицата Buyer.

            GetProductSalesReport(); // Дава информация за продукта и броя на купувачите му.
        }

        public static void AddProduct(string name)
        {
            using var context = new WarehouseContext();

            var product = new Product { Name = name };
            context.Products.Add(product);
            context.SaveChanges();

            Console.WriteLine($"Added product: {name}");
        }

        public static void BuyProduct(string buyerName, int productId)
        {
            using var context = new WarehouseContext();

            var product = context
                .Products
                .Include(p => p.Buyers)
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                Console.WriteLine("Product does not exist.");
                return;
            }

            var buyer = new Buyer { Name = buyerName, ProductId = productId };
            context.Buyers.Add(buyer);
            context.SaveChanges();

            Console.WriteLine($"{buyerName} purchased {product.Name}");
        }

        public static void GetProductSalesReport()
        {
            using var context = new WarehouseContext();

            var report = context
                .Products
                .Select(p => new
                {
                    p.Name,
                    BuyerCount = p.Buyers.Count
                })
                .OrderByDescending(p => p.BuyerCount)
                .ToArray();

            foreach (var entry in report)
            {
                Console.WriteLine($"Product: {entry.Name}, Buyers count: {entry.BuyerCount}");
            }
        }
    }
}