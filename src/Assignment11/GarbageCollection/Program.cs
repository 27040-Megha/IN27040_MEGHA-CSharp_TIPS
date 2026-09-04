using System;
using GarbageCollection.Domain.Model;

namespace Assignments
{
    public class Program
    {
        private static void Main(string[] args)
        {
            GC.Collect();
            Console.WriteLine("WITH GC");
            DisplayHeapMemoryUsage();
            ExecuteTask4WithGC();
            DisplayHeapMemoryUsage();
            Console.WriteLine("WITHOUT GC");
            DisplayHeapMemoryUsage();
            ExecuteTask4WithOutGC();
            DisplayHeapMemoryUsage();
        }

        private static void DisplayHeapMemoryUsage()
        {
            long currentHeapMemory = GC.GetTotalMemory(false);
            Console.WriteLine($"Current Memory: {currentHeapMemory}");
        }

        private static void ExecuteTask4WithOutGC()
        {
            for (int i = 0; i < 100; i++)
            {
                CreateObject();
            }
        }

        private static void ExecuteTask4WithGC()
        {
            for (int i = 0; i < 100; i++)
            {
                CreateObject();
                GC.Collect();
            }
        }

        private static void CreateObject()
        {
            var student = new Student();
            student = null;
        }
    }
}