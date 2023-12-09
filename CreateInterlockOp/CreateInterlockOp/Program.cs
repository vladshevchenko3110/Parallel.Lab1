using System;
using System.Diagnostics;
using System.Threading;


namespace Task5Thread
{    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n===== Interlocked test =====");
            InterLockedDefault(); 
            Console.WriteLine("\n===== MyInterlocked test =====");
            MyInterLocked();                   
            
        }
        public static void InterLockedDefault()
        {
            Stopwatch timer = new Stopwatch();
            int intvalue = 0;
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++) 
                {
                    Interlocked.Increment(ref intvalue);                   
                }
                
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    Interlocked.Increment(ref intvalue);                    
                }
            });
            timer.Start();
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            timer.Stop();
            Console.WriteLine("Result: " + intvalue);
            Console.WriteLine($"Interlocked time: {timer.ElapsedMilliseconds} ");
        }
        public static void MyInterLocked()
        {
            object obj = new object();
            Stopwatch timer = new Stopwatch();
            int intvalue = 0;
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    MyInterlocked.Increment(ref intvalue);

                }

            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    MyInterlocked.Increment(ref intvalue);
                }
            });
            
            timer = new Stopwatch();
            timer.Start();
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            timer.Stop();
            Console.WriteLine("Result: " + intvalue);
            Console.WriteLine($"MyInterlocked time: {timer.ElapsedMilliseconds} ");
        }
        
    }
}
