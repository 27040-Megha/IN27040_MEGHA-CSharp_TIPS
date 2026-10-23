using System.Reflection;
using System.Reflection.Emit;
using MockingFramework;

namespace Assignments
{
    /// <summary>
    /// Provides an entry point to the Application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        public static void Main()
        {
            try
            {
                var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DownloaderAssembly"), AssemblyBuilderAccess.Run);
                var module = assembly.DefineDynamicModule("DownloaderModule");
                var type = module.DefineType("BudgetReport", TypeAttributes.Public | TypeAttributes.Class);
                type.AddInterfaceImplementation(typeof(IDownloadable));
                CreateDownloadMethod(type, typeof(IDownloadable).GetMethod("DownloadPdf"), "Pdf downloaded successfully!");
                CreateDownloadMethod(type, typeof(IDownloadable).GetMethod("DownloadDocx"), "Word Document downloaded successfully!");
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
            var instance = Activator.CreateInstance(instanceType);
            var downloader = (IDownloadable)instance;
            Console.WriteLine(downloader.DownloadPdf() + "\n" + downloader.DownloadDocx());
        }

        private static void CreateDownloadMethod(TypeBuilder type, MethodInfo interfaceMethod, string message)
        {
            var methodAttributes = MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot;
            var method = type.DefineMethod(interfaceMethod.Name, methodAttributes, typeof(string), Type.EmptyTypes);
            var methodIL = method.GetILGenerator();
            methodIL.Emit(OpCodes.Ldstr, message);
            methodIL.Emit(OpCodes.Ret);
        }
    }
}