using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
    class Program
    {
        static void Main(string[] args)
        {
            Oyun oyun = new Oyun();
            oyun.OyunBasla();
            Console.Read();
        }
    }
}
