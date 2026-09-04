using System;
using System.Collections.Generic;
using GarbageCollection.Domain.Model;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExecuteTask4WithGC();
            ExecuteTask4WithOutGC();
        }

        public static void ExecuteTask4WithOutGC()
        {
            for (int i = 0; i < 100; i++)
            {
                CreateObject();
            }
        }

        public static void ExecuteTask4WithGC()
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