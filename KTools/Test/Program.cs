using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new List<string>();
            ls.Add("Hello world!!!");

           // KTools.Serializer.XMLSerializer.Serialize<List<string>>(ls, "d:/1.txt");
           //var l= KTools.Serializer.XMLSerializer.DeSerialize<List<string>>("d:/1.txt");

            //var str = "Hello world!!!";
            //KTools.Serializer.SoapSerializer.Serialize<string>(str, "d:/2.dat", (e) => { Console.WriteLine("错误："+e.ToString()); });
            //var l = KTools.Serializer.SoapSerializer.DeSerialize<string>("d:/2.dat");

            Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}
