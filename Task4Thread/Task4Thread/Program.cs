using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


namespace Task4Thread
{
    public class Customer
    {
        public int ID;
        public int Age;
        public string FirstName;
        public string LastName;  
    } 
 
    public class Program
    {
        public static void Main(string[] args)
        {
            int quantity = 1000000;
            Random random = new Random();
            var timer = new Stopwatch();
            string[] FirstNames = new string[200];
            for (int i = 0; i < 200; i++)
            {
                FirstNames[i] = $"FirstName{i}";
            }
            string[] LastNames = new string[200];
            for (int i = 0; i < 200; i++)
            {
                LastNames[i] = $"LastName{i}";
            }      
            bool customerisfoundlist1 = false;
            bool customerisfoundlist2 = false;
            bool customerisfoundlist3 = false;
            bool customerisfoundlist4 = false;
                  
            
            List<Customer> customers1 = new List<Customer>();
            for (int i = 0; i < quantity; i++)
            {
                Customer customer = new Customer();
                customer.ID = i;
                customer.Age = random.Next(20,70);
                customer.FirstName = FirstNames[random.Next(0,FirstNames.Length)];
                customer.LastName = LastNames[random.Next(0, LastNames.Length)];                

                customers1.Add(customer);
            }
            List<Customer> customers2 = new List<Customer>();
            for (int i = 0; i < quantity; i++)
            {
                Customer customer = new Customer();
                customer.ID = (i+quantity);
                customer.Age = random.Next(20, 70);
                customer.FirstName = FirstNames[random.Next(0, FirstNames.Length)];
                customer.FirstName = LastNames[random.Next(0, LastNames.Length)];

                customers2.Add(customer);
            }
            List<Customer> customers3 = new List<Customer>();
            for (int i = 0; i < quantity; i++)
            {
                Customer customer = new Customer();
                customer.ID = (i+2*quantity);
                customer.Age = random.Next(20, 70);
                customer.FirstName = FirstNames[random.Next(0, FirstNames.Length)];
                customer.LastName = LastNames[random.Next(0, LastNames.Length)];

                customers3.Add(customer);
            }
            List<Customer> customers4 = new List<Customer>();
            for (int i = 0; i < quantity; i++)
            {
                Customer customer = new Customer();
                customer.ID = (i+3*quantity);
                customer.Age = random.Next(20, 70);
                customer.FirstName = FirstNames[random.Next(0, FirstNames.Length)];
                customer.LastName = LastNames[random.Next(0, LastNames.Length)];

                customers4.Add(customer);
            }            

            Console.WriteLine("===== Multithread tests =====");
            timer.Reset();
            List<Thread> threads = new List<Thread>();
            
            threads.Add(new Thread(() =>
            {
                foreach (Customer customer in customers1)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {
                        
                        customerisfoundlist1 = true;
                        
                    }
                    
                }
            }));
            threads.Add(new Thread(() =>
            {
                foreach (Customer customer in customers2)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {                        
                        customerisfoundlist2 = true;
                        
                    }
                    
                }
            }));
            threads.Add(new Thread(() =>
            {
                foreach (Customer customer in customers3)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {                        
                        customerisfoundlist3 = true;
                        
                    }
                    
                }
            }));
            threads.Add(new Thread(() =>
            {
                foreach (Customer customer in customers4)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {                       
                        customerisfoundlist4 = true;                        
                    }
                    
                }
            }));
            threads.Add(new Thread(() =>
            {
                timer.Start();
                while (!customerisfoundlist1 && !customerisfoundlist2 && !customerisfoundlist3 && !customerisfoundlist4)
                {
                    if (!threads[0].IsAlive && !threads[1].IsAlive && !threads[2].IsAlive && !threads[3].IsAlive)
                    {
                        break;
                    }
                }
                foreach (Thread thread in threads)
                {                 
                    thread.Abort();
                }
                timer.Stop();
            }));

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            if (customerisfoundlist1)
                Console.WriteLine("Customer found in the first list");
            else if (customerisfoundlist2)
                Console.WriteLine("Customer found in the second list");
            else if (customerisfoundlist3)
                Console.WriteLine("Customer found in the third list");
            else if (customerisfoundlist4)
                Console.WriteLine("Customer found in the fourth list");
            else
                Console.WriteLine("Customer not found");

            Console.WriteLine($"Multithreaded time: {timer.ElapsedMilliseconds}ms");

            Console.WriteLine();
            Console.WriteLine("===== Sequential tests =====");
            customerisfoundlist1 = false;
            customerisfoundlist2 = false;
            customerisfoundlist3 = false;
            customerisfoundlist4 = false;

            timer.Reset();
            timer.Start();
            found:
            while (!customerisfoundlist1 && !customerisfoundlist2 && !customerisfoundlist3 && !customerisfoundlist4)
            {
                foreach (Customer customer in customers1 )
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {
                        customerisfoundlist1 = true;  
                        goto found;
                    }
                }
                foreach (Customer customer in customers2)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {
                        customerisfoundlist2 = true;  
                        goto found;
                    }
                }
                foreach (Customer customer in customers3)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {
                        customerisfoundlist3 = true;
                        goto found;
                    }
                }
                foreach (Customer customer in customers4)
                {
                    if (customer.FirstName == "FirstName45" && customer.LastName == "LastName95" && customer.Age == 54)
                    {
                        customerisfoundlist4 = true;
                        goto found;
                    }
                }
                break;
            }                             
            
            timer.Stop();
            if (customerisfoundlist1)
                Console.WriteLine("Customer found in the first list");
            else if (customerisfoundlist2)
                Console.WriteLine("Customer found in the second list");
            else if (customerisfoundlist3)
                Console.WriteLine("Customer found in the third list");
            else if (customerisfoundlist4)
                Console.WriteLine("Customer found in the fourth list");
            else
                Console.WriteLine("Customer not found");
            Console.WriteLine($"Sequential time: {timer.ElapsedMilliseconds}ms");

            Console.ReadLine();
        }

    }
}
