namespace DynamicMethodInvoker
{
    /// <summary>
    /// Contains a method to invoke method of an instance at run-time
    /// </summary>
    public class MethodInvoker
    {
        /// <summary>
        /// Gets the type of instance, get the method with specified name and invokes the method at run-time
        /// </summary>
        /// <param name="instance">Object</param>
        /// <param name="methodName">Method name to be invoked</param>
        public void InvokeMethod(object instance, string methodName)
        {
            var type = instance.GetType();
            var method = type.GetMethod(methodName);
            method.Invoke(instance, null);
        }
    }
}
