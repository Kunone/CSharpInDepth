using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorAndYield
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var i in new CountingEnumerable())
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("$$$$$$$$$$$$$");
            //foreach (var i in new CountingYield())
            //{
            //    Console.WriteLine(i);
            //}

            //foreach (var value in Compare3Execution.ImmedicateExecution(3))
            //    Console.WriteLine(value);
            //foreach(var value in Compare3Execution.DeferredEager(3))
            //    Console.WriteLine(value);
            //foreach(var value in Compare3Execution.DeferredLazy(3))
            //    Console.WriteLine(value);
            Predicate<>
            var items = Enumerable.Range(0, 5);
            foreach(var item in items.Where(i=>i%2!=0))
            {
                Console.WriteLine(item);
            }
        }
    }
}
