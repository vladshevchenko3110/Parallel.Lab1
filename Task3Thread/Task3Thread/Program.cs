using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Task3Thread
{
    public class Box
    {
        public int Width = 0;
        public int Length = 0;
        public int Height = 0;                
    }

    public class Program
    {                
        public static void Main(string[] args)
        {
            int multicount = 0;
            int simplecount = 0;
            
            int quantity = 10000000;
            Random random = new Random();
            var timer = new Stopwatch();

            List<Box> boxes1 = new List<Box>();
            for (int i = 0; i < quantity; i++)
            {
                Box box = new Box();
                
                box.Width = random.Next(20, 200);
                box.Length = random.Next(20, 200);
                box.Height = random.Next(20, 200);                                

                boxes1.Add(box);
            }

            List<Box> boxes2 = new List<Box>();
            for (int i = 0; i < quantity; i++)
            {
                Box box = new Box();

                box.Width = random.Next(20, 200);
                box.Length = random.Next(20, 200);
                box.Height = random.Next(20, 200);

                boxes2.Add(box);
            }

            List<Box> boxes3 = new List<Box>();
            for (int i = 0; i < quantity; i++)
            {
                Box box = new Box();

                box.Width = random.Next(20, 200);
                box.Length = random.Next(20, 200);
                box.Height = random.Next(20, 200);

                boxes3.Add(box);
            }

            List<Box> boxes4 = new List<Box>();
            for (int i = 0; i < quantity; i++)
            {
                Box box = new Box();

                box.Width = random.Next(20, 200);
                box.Length = random.Next(20, 200);
                box.Height = random.Next(20, 200);

                boxes4.Add(box);
            }                       
            
            Console.WriteLine("===== Multithread test =====");
            timer.Reset();
            List<Thread> threads = new List<Thread>();
            threads.Add(new Thread(() =>
            {                
                 foreach (Box box in boxes1)
                 {
                     if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                     {
                        Interlocked.Increment(ref multicount);
                     }
                 }                
                
            }));
            
            threads.Add(new Thread(() =>
            {                
                 foreach (Box box in boxes2)
                 {
                     if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                     {
                         Interlocked.Increment(ref multicount);
                     }
                 }               

            }));
            
            threads.Add(new Thread(() =>
            {                
                 foreach (Box box in boxes3)
                 {
                     if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                     {
                         Interlocked.Increment(ref multicount);
                     }
                 }                

            }));
            threads.Add(new Thread(() =>
            {                
                 foreach (Box box in boxes4)
                 {
                     if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                     {
                         Interlocked.Increment(ref multicount);
                     }
                 }
                
            }));

            timer.Start();
            foreach (Thread thread in threads)
            {                    
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            timer.Stop();
            Console.WriteLine("Quantities large boxes: " + multicount);      
         
            Console.WriteLine($"Multithreaded time: {timer.ElapsedMilliseconds}ms");        


            Console.WriteLine();
            Console.WriteLine("===== Sequential test =====");                

            timer.Reset();
            timer.Start();            
                
            foreach (Box box in boxes1)
            {
                if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                {
                    simplecount++;
                }                    
            }
            foreach (Box box in boxes2)
            {
                if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                {
                    simplecount++;
                }                   
            }
            foreach (Box box in boxes3)
            {
                if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                {
                    simplecount++;
                }                    
            }
            foreach (Box box in boxes4)
            {
                if (box.Length > 150 && box.Height > 150 && box.Width > 150)
                {
                    simplecount++;
                }                    
            }
            timer.Stop();
            Console.WriteLine("Quantities large boxes: " + simplecount);
            Console.WriteLine($"Sequential time: {timer.ElapsedMilliseconds}ms");                   
                        
            Console.ReadLine();
        }     
        
    }
}
