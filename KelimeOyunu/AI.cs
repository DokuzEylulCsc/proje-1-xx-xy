using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class AI
    {
        Sozcuk s = new Sozcuk();
        string tahmin; 
        public void Derece()
        {
            int x;
            try //hata kontrolü, harf vb. girildiğinde 
            {
                do  //derece seçimi
                {
                    Console.WriteLine("Zorluk derecesini giriniz 1/2/3");
                    x = int.Parse(Console.ReadLine());
                    if (x < 1 || x > 3) Console.WriteLine("Yanlis secim yaptiniz!");
                    else tahmin = s.Zorluk(x);
                } while (x != 1 && x != 2 && x != 3);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hatali islem yaptiniz!!!");
                Derece();
            }
        }


    }
}
