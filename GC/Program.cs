using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GC
{
    class Program
    {
        public static void Main(string[] args)
        {
            var t = new Timer(TimerCallback, null, 0, 2000);

            Console.ReadLine();
        }

        private static void TimerCallback(object o)
        {
            Console.WriteLine($"In TimerCallback: {DateTime.Now}");
            System.GC.Collect();
        }
    }
}
