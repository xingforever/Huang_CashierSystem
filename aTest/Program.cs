using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int ad = 5;
            int fd = Convert.ToInt32(Math.Ceiling(ad / 2.0));
            Console.WriteLine(fd);
            Console.ReadKey();
        }
    }
}
