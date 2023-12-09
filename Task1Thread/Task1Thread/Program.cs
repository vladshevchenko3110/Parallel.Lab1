using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Thread
{
    public class Program
    {
        static void CreateThread()
        {
            Thread thread = Thread.CurrentThread;
            Console.WriteLine($"ID: {thread.ManagedThreadId}  || Priority: {thread.Priority}  || State: {thread.ThreadState}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Create 10 thread:");
            for (int i = 0; i < 10; i++)
            {                
                Thread thread = new Thread(CreateThread);
                thread.Name = $"Thread #{i + 1}";
                thread.Priority = ThreadPriority.AboveNormal; 
                thread.Start();
            }
        }
    }
}
