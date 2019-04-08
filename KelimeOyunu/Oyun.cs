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
            bool yeniden = false;
            string c;
            Console.WriteLine("OYUNCU ADINIZI GIRINIZ");
            string ad = Console.ReadLine();
            Oyuncu oyuncu = new Oyuncu(ad);
            Console.WriteLine("HOS GELDİNİZ {0}", oyuncu.OyuncuAdi);
            AI yapayzeka = new AI(oyuncu);
            do //yeniden oynamasının kontrolu
            {
                yapayzeka.Derece();
                Console.WriteLine("Kelime girin");
                yapayzeka.Karar(Console.ReadLine()); //Güncellendi.

                do //oyuncu tekrar oyun oynamak isterse, E veya H disinda bir sey girmesinin kontrolu
                {
                    Console.WriteLine("Yeni Oyun oynamak ister misiniz?");
                    c = Console.ReadLine();
                    if (c == "e" || c == "E")
                    {
                        yeniden = true;
                        break;
                    }
                    else if (c == "h" || c == "H")
                    {
                        yeniden = false;
                        break;
                    }
                    
                    else Console.WriteLine("Yanlis giris yaptınız!");

                } while (c != "e" || c != "E" || c != "h" || c != "H");

            } while (yeniden == true);
        }
    }
}
