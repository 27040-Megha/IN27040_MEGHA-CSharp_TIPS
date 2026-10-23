using System.Reflection;
using System.Text;

namespace SerializationAPI
{
    /// <summary>
    /// Contains method to serialize objects using Reflections
    /// </summary>
    public static class ReflectionSerializer
    {
        /// <summary>
        /// Serializes object using Reflections
        /// </summary>
        /// <param name="objectToSerialize">Object to be serialized</param>
        /// <returns>String representing the serialized object</returns>
        public static string Serialize(object objectToSerialize)
        {
            var sb = new StringBuilder();
            var type = objectToSerialize.GetType();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                sb.Append($"{field.Name} - {field.GetValue(objectToSerialize)};");
            }

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                sb.Append($"{property.Name} - {property.GetValue(objectToSerialize)};");
            }

            return sb.ToString();
        }
    }
}
