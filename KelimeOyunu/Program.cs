using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = ("Kelime Oyunu XX-XY v1.1");
            Oyun oyun = new Oyun();
            oyun.Baslat();   
        }
    }
}
