using System.Reflection;
using System.Reflection.Emit;

namespace Assignments
{
    /// <summary>
    /// Provides an entry point to the Application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        public static void Main()
        {
            try
            {
                var assembly = CreateDynamicAssembly("UserAssembly");
                var module = CreateDynamicModule(assembly, "UserModule");
                var type = module.DefineType("User", TypeAttributes.Public | TypeAttributes.Class);
                CreateProperty(type, "UserName");
                CreateMethod(type);
                CreateAndExecuteDynamicType(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }

        private static void CreateAndExecuteDynamicType(TypeBuilder type)
        {
            var instanceType = type.CreateType();
            var userInstance = Activator.CreateInstance(instanceType);
            SetPropertyValue(instanceType, userInstance, "UserName", "Megha");
            Console.WriteLine($"User Name: {GetPropertyValue(instanceType, userInstance, "UserName")}");
            Console.WriteLine($"{InvokeMethod(instanceType, userInstance, "CreateUser")}");
        }

        private static string InvokeMethod(Type type, object instance, string methodName)
        {
            return (string)type.GetMethod(methodName).Invoke(instance, null);
        }

        private static string GetPropertyValue(Type type, object userInstance, string propertyName)
        {
            return (string)type.GetProperty(propertyName).GetValue(userInstance);
        }

        private static void SetPropertyValue(Type instanceType, object userInstance, string propertyName, string propertyValue)
        {
            instanceType.GetProperty(propertyName).SetValue(userInstance, propertyValue);
        }

        private static void CreateMethod(TypeBuilder type)
        {
            var methodBuilder = type.DefineMethod("CreateUser", MethodAttributes.Public, typeof(string), Type.EmptyTypes);
            var methodIL = methodBuilder.GetILGenerator();
            methodIL.Emit(OpCodes.Ldstr, $"User account created successfully!");
            methodIL.Emit(OpCodes.Ret);
        }

        private static void CreateProperty(TypeBuilder type, string propertyName)
        {
            string fieldName = $"_{propertyName.ToLower()}";
            var field = type.DefineField(fieldName, typeof(string), FieldAttributes.Private);
            var property = type.DefineProperty(propertyName, PropertyAttributes.None, typeof(string), null);
            var getterMethod = type.DefineMethod($"get_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName, typeof(string), Type.EmptyTypes);
            var getter = CreateAccessor("get", getterMethod, field);
            var setterMethod = type.DefineMethod($"set_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName, typeof(void), new Type[] { typeof(string) });
            var setter = CreateAccessor("set", setterMethod, field);
            property.SetGetMethod(getter);
            property.SetSetMethod(setter);
        }

        private static MethodBuilder CreateAccessor(string accessorType, MethodBuilder accessorMethod, FieldBuilder field)
        {
            var accessorIL = accessorMethod.GetILGenerator();
            accessorIL.Emit(OpCodes.Ldarg_0);
            if (string.Equals(accessorType, "get"))
            {
                accessorIL.Emit(OpCodes.Ldfld, field);
            }
            else
            {
                accessorIL.Emit(OpCodes.Ldarg_1);
                accessorIL.Emit(OpCodes.Stfld, field);
            }

            accessorIL.Emit(OpCodes.Ret);
            return accessorMethod;
        }

        private static ModuleBuilder CreateDynamicModule(AssemblyBuilder assembly, string moduleName)
        {
            return assembly.DefineDynamicModule(moduleName);
        }

        private static AssemblyBuilder CreateDynamicAssembly(string assemblyName)
        {
            return AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run);
        }
    }
}