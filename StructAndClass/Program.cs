using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructAndClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new DemoClass()
            {
                Name = "kun_class"
            };
            var p2 = new DemoStruct()
            {
                Name = "kun_struct"
            };

            Console.WriteLine(p1.GetInvalidName());
            Console.WriteLine(p2.GetInvalidName());
        }
    }
}
