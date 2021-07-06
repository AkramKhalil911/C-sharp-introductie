using Northwind.Data;
using System;
using System.Linq;

namespace Northwind
{
    class Program
    {
        static void Main(string[] args)
        {
            int orderID = HaalOrderID();
            ToonOrder(orderID);
            //ToonCategories();
            //ToonProducts();
            //ToonSuppliers();
            //ToonSupplierProducts();
        }

        private static string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Northwind";

        private static void ToonCategories()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Opdracht 1: ");
            Console.ResetColor();
            using (var db = new NorthwindDbContext(_connectionString))
            {
                Console.WriteLine("Kies uit de volgende nummers");                
                var categories = db.Categories.ToList();
                foreach (var category in categories)
                {
                    Console.Write($"Category ID {category.CategoryID}: ");
                    Console.WriteLine(category.CategoryName);
                }
            }
        }

        private static void ToonProducts()
        {
            int categoryInput = 0;
            int categoryCount = 0;
            do
            {
                using (var db = new NorthwindDbContext(_connectionString))
                {
                    categoryCount = db.Categories.Count();
                    Console.Write("Voer een nummer in: ");
                    categoryInput = int.Parse(Console.ReadLine());

                    var categories = db.Categories
                        .Where(b => b.CategoryID == categoryInput)
                        .ToList();

                    foreach (var category in categories)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Je hebt gekozen voor {category.CategoryID}: {category.CategoryName}");
                        Console.ResetColor();
                    }

                    var products = db.Products
                        .Where(b => b.CategoryID == categoryInput)
                        .ToList();

                    foreach (var product in products)
                    {
                        Console.Write($"Product ID {product.ProductID}: ");
                        Console.WriteLine(product.ProductName);
                    }
                }
            } while (categoryInput > categoryCount);
        }

        private static void ToonSuppliers()
        {
            using (var db = new NorthwindDbContext(_connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Opdracht 2: ");
                Console.ResetColor();
                var suppliers = db.Suppliers.ToList();
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"Supplier ID {supplier.SupplierID}:\t {supplier.CompanyName}");
                }
            }
        }

        private static void ToonSupplierProducts()
        {
            int productInput = 0;
            int productCount = 0;
            do
            {
                using (var db = new NorthwindDbContext(_connectionString))
                {
                    productCount = db.Suppliers.Count();
                    Console.Write("Voer een supplier ID in: ");
                    productInput = int.Parse(Console.ReadLine());

                    var products = db.Products
                        .Where(b => b.SupplierID == productInput)
                        .ToList();

                    var suppliers = db.Suppliers
                        .Where(b => b.SupplierID == productInput)
                        .ToList();

                    foreach (var product in products)
                    {
                        foreach (var supplier in suppliers)
                        {
                            var categories = db.Categories
                                .Where(b => b.CategoryID == product.CategoryID)
                                .OrderBy(b => b.CategoryName)
                                .ToList();

                            foreach (var category in categories)
                            {
                                Console.WriteLine($"{category.CategoryName}, {product.ProductID}, {product.ProductName}, {product.Supplier.CompanyName}");
                            }
                        }
                    }
                }
            } while (productInput > productCount);
        }

        private static void ToonOrder(int orderID)
        {
            Console.Clear();
            OrderHeader(orderID);
            OrderDetails(orderID);
        }

        private static void OrderHeader(int orderID)
        {
            using (var db = new NorthwindDbContext(_connectionString))
            {
                var orderOutput = db.Orders
                    .Where(b => b.OrderID == orderID)
                    .ToList();
                db.Customers.ToList();

                foreach (var orderid in orderOutput)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(orderid.Customer.CompanyName);
                    Console.WriteLine(orderid.Customer.ContactName);
                    Console.WriteLine(orderid.Customer.Address);
                    Console.WriteLine(orderid.Customer.City);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nOrder: {orderid.OrderID} Date: {Convert.ToDateTime(orderid.OrderDate).ToString("dd-M-yyyy")}\n");
                }
            }
        }
        public int NumberDecimalDigits { get; set; }
        private static void OrderDetails(int orderID)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            using (var db = new NorthwindDbContext(_connectionString))
            {
                var orderOutput = db.OrderDetails
                    .Where(b => b.OrderID == orderID)
                    .OrderBy(b => b.Product.Category.CategoryName)
                    .ToList();
                db.Products.ToList();
                db.Categories.ToList();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("{0,-15} {1,-40} {2,-25} {3,-24} {4,-5}\n", "Category", "Product", "UnitPrice", "Quantity", "Total");
                Console.ForegroundColor = ConsoleColor.Yellow;

                foreach (var orderid in orderOutput)
                {
                    Console.WriteLine("{0,-15} {1,-40} {2,-25} {3,-24} {4,-5}",
                        orderid.Product.Category.CategoryName,
                        orderid.Product.ProductName,
                        "\u20AC " + Math.Round(orderid.UnitPrice, 2),
                        orderid.Quantity,
                        "\u20AC " + Math.Round(orderid.Quantity * orderid.UnitPrice, 2));
                }
            }
        }

        private static int HaalOrderID()
        {
            using (var db = new NorthwindDbContext(_connectionString))
            {
                int orderID = 0;
                bool TrueOrFalse = false;

                while (TrueOrFalse == false)
                {
                    Console.Write("Voer een order ID in: ");
                    orderID = int.Parse(Console.ReadLine());
                    var lowOrderID = db.Orders.OrderByDescending(b => b.OrderID).LastOrDefault();
                    var highOrderID = db.Orders.OrderByDescending(b => b.OrderID).FirstOrDefault();

                    if (orderID >= lowOrderID.OrderID && orderID <= highOrderID.OrderID)
                    {
                        TrueOrFalse = true;
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Het ID kon niet gevonden worden in de database!");
                        Console.ResetColor();
                    }
                }
                return orderID;
            }
        }
    }
}
