using System.Reflection;

namespace Assignments
{
    /// <summary>
    /// Provides entry point to Application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of Application
        /// </summary>
        public static void Main()
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\Library\bin\Debug\net6.0\Library.dll");
                var assembly = Assembly.LoadFrom(filePath);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    Console.WriteLine($"TYPE: {type.Name}");
                    var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
                    GetAndDisplayFieldInfo(type, flags);
                    GetAndDisplayPropertyInfo(type, flags);
                    GetAndDisplayMethodInfo(type, flags);
                    GetAndDisplayEventsInfo(type, flags);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static void GetAndDisplayFieldInfo(Type type, BindingFlags flags)
        {
            Console.WriteLine("FIELD INFO");
            var fieldInfo = type.GetFields(flags);
            foreach (var field in fieldInfo)
            {
                Console.WriteLine($"{field.FieldType.Name} {field.Name}");
            }
        }

        private static void GetAndDisplayPropertyInfo(Type type, BindingFlags flags)
        {
            Console.WriteLine("PROPERTY INFO");
            var propertyInfo = type.GetProperties(flags);
            foreach (var property in propertyInfo)
            {
                Console.WriteLine($"{property.PropertyType.Name} {property.Name}");
            }
        }

        private static void GetAndDisplayMethodInfo(Type type, BindingFlags flags)
        {
            Console.WriteLine("METHOD INFO");
            var methodInfo = type.GetMethods(flags);
            foreach (var method in methodInfo)
            {
                Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
            }
        }

        private static void GetAndDisplayEventsInfo(Type type, BindingFlags flags)
        {
            Console.WriteLine("EVENTS INFO");
            var eventsInfo = type.GetEvents(flags);
            foreach (var eventInfo in eventsInfo)
            {
                Console.WriteLine($"{eventInfo.EventHandlerType?.Name} {eventInfo.Name}");
            }
        }
    }
}