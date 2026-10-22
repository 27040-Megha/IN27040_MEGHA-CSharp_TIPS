using System;

namespace DynamicObjectInspector
{
    /// <summary>
    /// Contains method that inspects object at run-time using reflections
    /// </summary>
    public class ObjectInspector
    {
        /// <summary>
        /// Gets the type of objects, its properties and displays each property along with its name and value
        /// </summary>
        /// <param name="instance">Object to be inspected</param>
        public void DisplayProperties(object instance)
        {
            var type = instance.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(instance);
                Console.WriteLine($"{property.Name} - {propertyValue}");
            }
        }

        /// <summary>
        /// Updates the value of a property of an object at run-time
        /// </summary>
        /// <param name="instance">Object whose property has to be updated</param>
        /// <param name="propertyName">Property name to be updated</param>
        /// <param name="newValue">New value that has to be set</param>
        public void UpdateProperty(object instance, string propertyName, object newValue)
        {
            var property = instance.GetType().GetProperty(propertyName);
            property.SetValue(instance, newValue);
        }
    }
}
