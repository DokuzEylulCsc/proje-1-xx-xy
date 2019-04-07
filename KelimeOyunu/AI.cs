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
        static string tahmin; 
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
                Console.WriteLine(tahmin);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hatali islem yaptiniz!!!");
                Derece();
            }
        }

        public void Karar(string kelime) //disaridan alınan kelime ile yapay zekanın ürettigi kelime karsilastirilir
        {
            
            if (kelime == tahmin) Console.WriteLine("TEBRİKLER, BİLDİNİZ");
            else
            {
                if (Kontrol(kelime) == false || Uzunluk(kelime) == false) //uzunluk ve karakter kontrolu
                    Console.WriteLine("\nGirdiginiz kelime dile ait olmayan karakterler iceriyor veya iki kelimenin uzunlugu esit degil.");
                else Karsilastirma(kelime); //sıkıntı yoksa karsilastirma metoduna gonderilir
                while (kelime != tahmin)  //kelime ile tahmin esit olmadıgı surece yeni kelime istemesi icin
                {
                    

                    Console.WriteLine("\nYeni kelime girin");
                    kelime = Console.ReadLine();
                    if (Kontrol(kelime) == false || Uzunluk(kelime) == false) //yeni girilen kelime icin kontrol
                    {
                        do
                        {
                            Console.WriteLine("\nGirdiginiz kelime dile ait olmayan karakterler iceriyor veya iki kelimenin uzunlugu esit degil.");
                            Console.WriteLine("\nYeni kelime girin");
                            kelime = Console.ReadLine();
                        } while (Kontrol(kelime) == false || Uzunluk(kelime) == false);
                    }
                    Karsilastirma(kelime);
                }
                Console.WriteLine("\nTEBRİKLER, BİLDİNİZ");
            }
        }
        
        private bool Uzunluk(string kelime) // yapay zekanın urettigi kelimenin uzunluguyla girilen kelimenin uzunlugunu karsilastirma
        {
            if (tahmin.Length == kelime.Length)
                return true;
            return false;
        }

         private bool Kontrol(string kelime) //kelimenin içerisinde turkce karakter içermeyen harfler varsa
        {
            for (int i = 0; i < kelime.Length; i++)
            {
                if (!(Char.IsLetter(kelime[i]) || kelime[i] != 'q' || kelime[i] != 'w' || kelime[i] != 'x' || kelime[i] != 'Q' || kelime[i] != 'W' || kelime[i] != 'X' || kelime[0] != 'Ğ' || kelime[0] != 'ğ'))
                {
                    return false;
                }
            }
            return true;
        }

        private void Karsilastirma(string kelime) //girilen kelimenin sozcukte yer alıp almadıgının kontrolu
        {
            int i;
            Console.Write("Sozcukte yer alan harfler: ");
            bool varMi=false;
            for(i=0; i<tahmin.Length;i++)
            {
                for (int j = 0; j < kelime.Length; j++)
                {
                    if (tahmin[i] == kelime[j])
                    {
                        Console.Write("{0}, ", kelime[j]);
                        varMi = true; //iceren aynı harf varsa
                    }
                }
            }
            if (varMi == false)
                Console.Write("YOK"); //iceren aynı harf yoksa
            varMi = false;
            Console.WriteLine();
            Console.Write("Eslesme saglanan harfler: ");

            for(i=0; i<tahmin.Length;i++) //eslesme saglanan harflerin kontrolu
            {
               if(tahmin[i]==kelime[i])
                {
                    Console.Write("{0}, ", tahmin[i]); //saglandiysa
                    varMi = true;
                }
            }
            if (varMi == false)
                Console.WriteLine("YOK");


        }

        

    }
}
