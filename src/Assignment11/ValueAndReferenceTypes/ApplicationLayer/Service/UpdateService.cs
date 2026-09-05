using System;
using System.Reflection;
using ValueAndReferenceTypes.Domain.Model;
using ValueAndReferenceTypes.Domain.Strcuts;

namespace ValueAndReferenceTypes.ApplicationLayer.Service
{
    /// <summary>
    /// Contains Business logic to update the data
    /// </summary>
    public class UpdateService
    {
        /// <summary>
        /// Edits the Data objects
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="item">Existing object</param>
        /// <param name="newItem">Object with updated details</param>
        public void Modify<T>(T item, T newItem)
        {
            Type objectType = item.GetType();
            PropertyInfo[] properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                var propertyValueToUpdate = property.GetValue(newItem);
                property.SetValue(item, propertyValueToUpdate);
            }
        }
    }
}
