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

            KTools.Serializer.XMLSerializer.Serialize<List<string>>(ls, "d:/1.txt");
           var l= KTools.Serializer.XMLSerializer.DeSerialize<List<string>>("d:/1.txt");
            Console.WriteLine(l[0]);
            Console.ReadLine();
        }
    }
}
