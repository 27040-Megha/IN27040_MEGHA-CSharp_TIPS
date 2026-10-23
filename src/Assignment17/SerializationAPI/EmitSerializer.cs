using System.Reflection;
using System.Reflection.Emit;

namespace SerializationAPI
{
    /// <summary>
    /// Provides a method to create a dynamic method at run-time to serialize objects
    /// </summary>
    public static class EmitSerializer
    {
        /// <summary>
        /// Create a Dynamic method to serialize objects to strings at run-time
        /// </summary>
        /// <returns>Delegate that takes a printer object as input, returns a serialized string output</returns>
        public static Func<Printer, string> CreateSerializeMethod()
        {
            var dynamicMethod = new DynamicMethod("Serialize", typeof(string), new[] { typeof(Printer) });
            var methodIL = dynamicMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldstr, "IsOn:{0};MachineName:{1};");
            methodIL.Emit(OpCodes.Ldarg_0);
            var privateField = typeof(Printer).GetField("_isOn", BindingFlags.NonPublic | BindingFlags.Instance);
            methodIL.Emit(OpCodes.Ldfld, privateField);
            methodIL.Emit(OpCodes.Box, typeof(bool));
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Callvirt, typeof(Printer).GetProperty("MachineName").GetMethod);
            var stringFormat = typeof(string).GetMethod("Format", new[] { typeof(string), typeof(object), typeof(object) });
            methodIL.Emit(OpCodes.Call, stringFormat);
            methodIL.Emit(OpCodes.Ret);
            return (Func<Printer, string>)dynamicMethod.CreateDelegate(typeof(Func<Printer, string>));
        }
    }
}
