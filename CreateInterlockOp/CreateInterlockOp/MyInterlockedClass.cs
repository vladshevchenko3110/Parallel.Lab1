using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Thread
{
    public static class MyInterlocked
    {
        private static object _lock = new object();
        public static int Increment(ref int value)
        {
            lock (_lock)
            {
                return value++;
            }
        }
        public static long Increment(ref long value)
        {
            lock (_lock)
            {
                return value++;
            }
        }
        public static int Decrement(ref int value)
        {
            lock (_lock)
            {
                return value--;
            }
        }
        public static long Decrement(ref long value)
        {
            lock (_lock)
            {
                return value--;
            }
        }
        public static int Add(ref int value1,int value2)
        {
            lock (_lock)
            {
                return value1+value2;
            }
        }
        public static long Add(ref long value1, long value2)
        {
            lock (_lock)
            {
                return value1 + value2;
            }
        }
        public static long Read(ref long value)
        {
            lock (_lock)
            {
                return value;
            }
        }
        public static int Exchange(ref int value1, int value2 )
        {
            lock (_lock)
            {
                value1 = value2;
                return value1;
            }
        }
        public static long Exchange(ref long value1, long value2)
        {
            lock (_lock)
            {
                value1 = value2;
                return value1;
            }
        }
        public static float Exchange(ref float value1, float value2)
        {
            lock (_lock)
            {
                value1 = value2;
                return value1;
            }
        }
        public static double Exchange(ref double value1, double value2)
        {
            lock (_lock)
            {
                value1 = value2;
                return value1;
            }
        }
        public static object Exchange(ref object obj1, object obj2)
        {
            lock (_lock)
            {
                obj1 = obj2;
                return obj1;
            }
        }
        public static T Exchange<T>(ref T obj1, T obj2) where T:class
        {
            lock (_lock)
            {
                obj1 = obj2;
                return obj1;
            }
        }
        public static IntPtr Exchange(ref IntPtr obj1, IntPtr obj2)
        {
            lock (_lock)
            {
                obj1 = obj2;
                return obj1;
            }
        }
        public static int CompareExchange(ref int value1, int value2, int value3)
        {
            lock (_lock)
            {
                if(value1==value3)
                    value1 = value2;
                return value1;
            }
        }
        public static float CompareExchange(ref float value1, float value2, float value3)
        {
            lock (_lock)
            {
                if (value1 == value3)
                    value1 = value2;
                return value1;
            }
        }
        public static double CompareExchange(ref double value1, double value2, double value3)
        {
            lock (_lock)
            {
                if (value1 == value3)
                    value1 = value2;
                return value1;
            }
        }
        public static long CompareExchange(ref long value1, long value2, long value3)
        {
            lock (_lock)
            {
                if (value1 == value3)
                    value1 = value2;
                return value1;
            }
        }
        public static object CompareExchange(ref object obj1, object obj2, object obj3)
        {
            lock (_lock)
            {
                if (obj1 == obj3)
                    obj1 = obj2;
                return obj1;
            }
        }
        public static T CompareExchange<T>(ref T obj1, T obj2, T obj3)where T:class
        {
            lock (_lock)
            {
                if (obj1 == obj3)
                    obj1 = obj2;
                return obj1;
            }
        }
        public static IntPtr CompareExchange(ref IntPtr obj1, IntPtr obj2, IntPtr obj3)
        {
            lock (_lock)
            {
                if (obj1 == obj3)
                    obj1 = obj2;
                return obj1;
            }
        }



    }
}
