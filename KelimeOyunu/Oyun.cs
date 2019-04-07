using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class Oyun
    {
        public void Baslat() 
        {
            Console.WriteLine("OYUNCU ADINIZI GIRINIZ");
            string ad = Console.ReadLine();
            Oyuncu oyuncu = new Oyuncu(ad);
            Console.WriteLine("HOS GELDİNİZ {0}", oyuncu.OyuncuAdi);
            AI yapayzeka = new AI();
            yapayzeka.Derece();
           
        }
    }
}
