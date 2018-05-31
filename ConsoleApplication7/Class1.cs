using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    public class MyTestClass
    {
        double d, f;
        public MyTestClass(double d, double f)
        {
            this.d = d;
            this.f = f;
        }

        public double Sum()
        {
            return d + f;
        }

        public override string ToString()
        {
            return "MyTestClass";
        }
    }

    public class Reflection
    {
        public static void MethodReflection<T>(T obj)
            where T : class
        {
            Type t = typeof(T);

            //получаем кооллекцию методов
            MethodInfo[] Marr = t.GetMethods();
            foreach (MethodInfo item in Marr)
            {
                Console.WriteLine(" --> " +
                    item.ReturnType.Name +
                    " \t" + item.Name);

                ParameterInfo[] p = item.GetParameters();
                foreach (ParameterInfo pInfo in p)
                {
                    Console.Write(pInfo.ParameterType.Name
                        +" "+ pInfo.Name);
                }
                Console.WriteLine("");
            }
        }
    }
}
