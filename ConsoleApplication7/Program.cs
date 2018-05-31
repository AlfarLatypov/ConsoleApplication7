using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly a = Assembly.LoadFrom(@"\\dc\Студенты\ПКО\SEB-171.2\C#\Exception\GeneratorName.dll");
            
            foreach (Type t in a.GetTypes())
            {
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
                            + " " + pInfo.Name);
                    }
                    Console.WriteLine("");
                }
            }
        }

        static void BinarySerialize(Person person)
        {
            Console.WriteLine("Object create!");

            //Создаим обхем BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs =
                new FileStream("person.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Object Serialize ss!");
            }

            //Десириализация
            using (FileStream fs =
                new FileStream("person.dat", FileMode.OpenOrCreate))
            {
                Person newPerson =
                    (Person)formatter.Deserialize(fs);
                Console.WriteLine(newPerson.Name);
                Console.WriteLine(newPerson.Year);
            }
        }

        static void SoapSerialize(Person person)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs =
                new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }
        }

        static void SoapSerialize(Person[] persons)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs =
                new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, persons);
            }
        }

        static object SoapDesirealize()
        {
            object persone = null;

            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs =
                new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                persone = formatter.Deserialize(fs);
            }

            return persone;
        }

        static Person[] SoapDesirealize(string t = "")
        {
            Person[] persone = null;

            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs =
                new FileStream("person.soap", FileMode.OpenOrCreate))
            {
                persone = (Person[])formatter.Deserialize(fs);
            }

            return persone;
        }

        public static void XmlSerialize(Person person)
        {
            XmlSerializer formatter =
                new XmlSerializer(typeof(Person));

            using (FileStream fs =
                new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }
        }

        public static void XmlSerialize(Person[] person)
        {
            XmlSerializer formatter =
                new XmlSerializer(typeof(Person[]));

            using (FileStream fs =
                new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }
        }

        public static void XmlSerialize(List<Person> person)
        {
            XmlSerializer formatter =
                new XmlSerializer(typeof(List<Person>));

            using (FileStream fs =
                new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
            }
        }

        public static void DeserializeSerialize()
        {
            List<Person> person = new List<Person>();

            XmlSerializer formatter =
                new XmlSerializer(typeof(List<Person>));

            using (FileStream fs =
                new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                person = (List<Person>)formatter.Deserialize(fs);
            }
        }

    }
}
