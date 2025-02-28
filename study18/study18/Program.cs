using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study18
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            Console.WriteLine($"Current Date and Time: {now}");

            var duration = new TimeSpan(1, 30, 0);
            Console.WriteLine($"Duration: {duration}");
        }
    }
}
