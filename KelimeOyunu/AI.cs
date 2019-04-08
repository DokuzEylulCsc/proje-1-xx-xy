using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace KelimeOyunu
{

    class AI
    {
        Oyuncu oyuncu;

        public AI(Oyuncu o)
        {
            oyuncu = o;
        }

        Sozcuk s = new Sozcuk();

        static string tahmin;

        public int x;
        public int soru;
        public static int sure;
        public int deneme = 1;

        public void Derece()
        {
            try //hata kontrolü, harf vb. girildiğinde 
            {
                do  //derece seçimi
                {
                    Console.WriteLine("Zorluk derecesini giriniz Kolay (1) / Orta (2) /Zor (3)");
                    x = int.Parse(Console.ReadLine());
                    if (x < 1 || x > 3) Console.WriteLine("Yanlis secim yaptiniz!");
                    else tahmin = s.Zorluk(x);
                } while (x != 1 && x != 2 && x != 3);
                Console.WriteLine(tahmin);
                soru = 0;
                SetTimer(true);
            }
            catch (Exception)
            {
                Console.WriteLine("Hatali islem yaptiniz!!!");
                Derece();
            }
        }

        public void Karar(string kelime) //disaridan alınan kelime ile yapay zekanın ürettigi kelime karsilastirilir
        {
            do
            {
                if (Kontrol(kelime) == false || Uzunluk(kelime) == false) //uzunluk ve karakter kontrolu
                {
                    Console.WriteLine("\nGirdiginiz kelime dile ait olmayan karakterler iceriyor veya iki kelimenin uzunlugu esit degil.");
                    deneme++;
                }
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
                    deneme++;
                }
                Tur();
                SetTimer(false);
            } while (tahmin == kelime && soru == 0);
        }
        
        private void Tur()
        {
            soru++;
            if (soru < 10)
            {
                Console.WriteLine("\nTEBRİKLER, BİLDİNİZ / Kalan Soru : " + (10 - soru) + "\nKelime Girin");
                Kaydedici.Hesaplama(soru, sure, deneme, tahmin); // Kaydedici classında Hesaplama fonksiyonuna istatiksel veriler gönderilir.
                deneme = 1;
                sure = 0;
                tahmin = s.Zorluk(x); // Sonraki tur için yeni kelime isteği
                Console.WriteLine(tahmin);
                Karar(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("\nTEBRİKLER, Tüm Soruları Cevapladınız.");
                Kaydedici.Hesaplama(soru, sure, deneme, tahmin);
                sure = 0;
                Kaydedici.dosyayaYaz(oyuncu.OyuncuAdi); // Tüm sorular bilindikten sonra istatistikler oyuncuAdi.txt şeklinde kaydedilir.
                Kaydedici.dosyadanOku(oyuncu.OyuncuAdi); // Oyun bitiminde istatistikler gösterilir.
            }
        }

        public static void SetTimer(bool durum) //Timer fonksiyonu;
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(SureArttir);
            aTimer.Interval = 1000;
            aTimer.Enabled = durum;
        }

        private static void SureArttir(Object source, ElapsedEventArgs e) //Oyunlar için süre tutan fonksiyonumuz.
        {
            sure++;
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
