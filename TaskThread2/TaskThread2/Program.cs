using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskThread2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitRegions();
            InitCustomers();
            InitOrders();
            InitProducts();

            Stopwatch timer = new Stopwatch();

            Thread product_processing_thread = new Thread(ProcessProductInfo);
            Thread customer_processing_thread = new Thread(ProcessCustomerAndRegionInfo);

            timer.Start();
            product_processing_thread.Start();
            customer_processing_thread.Start();
            product_processing_thread.Join();
            customer_processing_thread.Join();
            timer.Stop();

            Console.WriteLine($"[PROFILE] Parallel execution took: {timer.ElapsedMilliseconds}");

            timer.Restart();
            ProcessProductInfo();
            ProcessCustomerAndRegionInfo();
            timer.Stop();

            Console.WriteLine($"[PROFILE] Sequential execution took: {timer.ElapsedMilliseconds}");

        }

        public static void InitRegions()
        {
            Regions = new List<string>();
            Regions.Add("Kyiv");
            Regions.Add("Lvivska");
            Regions.Add("Dnipropetrovska");
            Regions.Add("Khersonska");
        }

        public static void InitProducts()
        {
            ProductTypes = new List<ProductType>();
            ProductTypes.Add(new ProductType("Baked food", 0));
            ProductTypes.Add(new ProductType("Oil", 1));
            ProductTypes.Add(new ProductType("Food", 2));
            ProductTypes.Add(new ProductType("Other", 3));

            Products = new List<Product>();
            Products.Add(new Product(0, ProductTypes[0], "Bread"));
            Products.Add(new Product(0, ProductTypes[0], "Donat"));
            Products.Add(new Product(1, ProductTypes[1], "Oil"));
            Products.Add(new Product(1, ProductTypes[1], "SOil"));
            Products.Add(new Product(2, ProductTypes[2], "Sushi"));
            Products.Add(new Product(2, ProductTypes[2], "Onion"));
            Products.Add(new Product(3, ProductTypes[3], "Sofa"));
            Products.Add(new Product(3, ProductTypes[3], "Chair"));
        }

        public static void InitCustomers()
        {
            Customers = new List<Customer>();
            Customers.Add(new Customer(0, "LLC Miy Khlib", Regions[0]));
            Customers.Add(new Customer(1, "LLC UkrNaphta", Regions[1]));
            Customers.Add(new Customer(2, "LLC UkrFood", Regions[2]));
            Customers.Add(new Customer(3, "LLC TheCorporation", Regions[3]));
        }

        public static void InitOrders()
        {
            Orders = new List<Order>();
            Random random = new Random();
            for (int i = 0; i < NumOrders; i++)
            {
                // генерируем данные
                Order order = new Order(
                    (uint)random.Next(0, Customers.Count),
                    (uint)random.Next(0, 8),
                    (uint)random.Next(100, 100_000),
                    (uint)random.Next(50, 50_000),
                    new DateTime(random.NextInt64(new DateTime(2020, 1, 1).Ticks, DateTime.Now.Ticks)), // генерируем рандомное время
                    new DateTime(random.NextInt64(new DateTime(2020, 1, 1).Ticks, DateTime.Now.Ticks)),
                    (Status)random.Next(0, 2)

                );
                Orders.Add(order);
            }
        }

        public static void ProcessProductInfo()
        {
            Dictionary<uint, uint> products_popularity = new Dictionary<uint, uint>();
            for (uint i = 0; i < Products.Count; i++) { products_popularity.Add(i, 0); }

            Dictionary<uint, uint> products_types_popularity = new Dictionary<uint, uint>();
            for (uint i = 0; i < ProductTypes.Count; i++) { products_types_popularity.Add(i, 0); }

            uint best_product_id = 0;
            uint best_product_type_id = 0;

            foreach (Order order in Orders)
            {
                if (order.CreateDateTime < BeginLookUpDate || order.FinishDateTime > EndLookUpDate)
                { continue; }
                products_popularity[order.ProductId]++;
                products_types_popularity[Products[(int)order.ProductId].Type.Id]++;

            }

            foreach (var entry in products_popularity)
            {
                if (entry.Value > products_popularity[best_product_id])
                {
                    best_product_id = entry.Key;
                }
            }
            Console.WriteLine("Best product: " + best_product_id);

            foreach (var entry in products_types_popularity)
            {
                if (entry.Value > products_types_popularity[best_product_type_id])
                {
                    best_product_type_id = entry.Key;
                }
            }
            Console.WriteLine("Best product type: " + best_product_type_id);

        }

        public static void ProcessCustomerAndRegionInfo()
        {
            Dictionary<uint, uint> customers_popularity = new Dictionary<uint, uint>();
            for (uint i = 0; i < Customers.Count; i++) { customers_popularity.Add(i, 0); }

            Dictionary<string, uint> regions_popularity = new Dictionary<string, uint>();
            foreach (string region in Regions) { regions_popularity.Add(region, 0); }

            uint best_customer_id = 0;
            string best_region = Regions[0];
            uint expenses = 0;
            uint total_sum = 0;
            foreach (Order order in Orders)
            {
                if (order.CreateDateTime < BeginLookUpDate || order.FinishDateTime > EndLookUpDate)
                { continue; }
                customers_popularity[order.CustromerId]++;
                regions_popularity[Customers[(int)order.CustromerId].Region]++;
                expenses += order.Expenses;
                total_sum += order.TotalSum;
            }

            foreach (var entry in customers_popularity)
            {
                if (entry.Value > customers_popularity[best_customer_id])
                {
                    best_customer_id = entry.Key;
                }
            }
            Console.WriteLine("Best customer: " + best_customer_id);

            foreach (var entry in regions_popularity)
            {
                if (entry.Value > regions_popularity[best_region])
                {
                    best_region = entry.Key;
                }
            }
            Console.WriteLine("Best region: " + best_region);
            Console.WriteLine("Total sum: " + total_sum);
            Console.WriteLine("Expenses: " + expenses);
            Console.WriteLine("Profit: " + (total_sum - expenses));
        }

        public const uint NumOrders = 1000_000;

        public static DateTime BeginLookUpDate = new DateTime(2021, 7, 24);
        public static DateTime EndLookUpDate = DateTime.Now;

        public static List<string> Regions { get; set; }
        public static List<ProductType> ProductTypes { get; set; }
        public static List<Product> Products { get; set; }
        public static List<Customer> Customers { get; set; }
        public static List<Order> Orders { get; set; }

    }
}
