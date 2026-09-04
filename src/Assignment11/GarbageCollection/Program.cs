using System;
using GarbageCollection.Domain.Model;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ExecuteTask4WithGC();
            ExecuteTask4WithOutGC();
        }

        public static void ExecuteTask4WithOutGC()
        {
            Student student;
            for (int i = 0; i < 100; i++)
            {
                student = new Student();
            }
        }
    }
}