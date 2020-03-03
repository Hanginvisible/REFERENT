using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CMCLIS.CVAN.CORE
{
    public class InvokeMethod
    {
        public static List<string> GetListMethods(string assemblyName, string namespaceName, string className)
        {
            try
            {
                List<string> list = new List<string>();
                Type calledType = Type.GetType(namespaceName + "." + className + "," + assemblyName);


                //MethodInfo[] methodInfos = Type.GetType("Class1").GetMethods(BindingFlags.Public | BindingFlags.Instance);
                MethodInfo[] methodInfos = calledType.GetMethods(BindingFlags.Public | BindingFlags.Static);

                ///get all the methods for the classname passed as string

                foreach (var item in methodInfos)
                {
                    list.Add(item.Name);
                }
                return list;
            }
            catch (Exception ex)
            {

                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        public static object InvokeStringMethod(string assemblyName, string namespaceName, string className, string methodName, Object[] stringParam)
        {
            try
            {
                // Get the Type for the class
                Type calledType = Type.GetType(namespaceName + "." + className + "," + assemblyName);

                // Invoke the method itself. The string returned by the method winds up in s
                object s = calledType.InvokeMember(
                    methodName,
                    BindingFlags.InvokeMethod | BindingFlags.Public |
                    BindingFlags.Static,
                    null,
                    null,
                    stringParam);

                // Return the string that was returned by the called method.
                return s;
            }
            catch (Exception ex)
            {

                LogEventError.LogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return "";
            }
        }
    }
}
