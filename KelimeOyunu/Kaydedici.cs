using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class Kaydedici
    {
        static int[] soruliste = new int[10];
        static int[] sureliste = new int[10];
        static int[] denemeliste = new int[10];
        static string[] kelimeliste = new string[10];
        static int sayac = 0, toplamsure = 0;

        public static void Hesaplama(int sorukac, int sure, int deneme, string kelime)
        {
            soruliste[sayac] = sorukac;
            sureliste[sayac] = sure;
            denemeliste[sayac] = deneme;
            kelimeliste[sayac] = kelime;
            sayac++;
        }

        public static void dosyayaYaz(string ad) // İstatiksel bilgiler txt dosyasına kaydedilir
        {
            string dosya_yolu = @ad+".txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine("---------------------------------------");
                sw.WriteLine("Soru : " + soruliste[i]);
                sw.WriteLine("Kelime : " + kelimeliste[i]);
                sw.WriteLine("Sure : " + sureliste[i] + " saniye");
                sw.WriteLine("Deneme Sayisi : " + denemeliste[i]);
            }

            for (int j = 0; j < 10; j++)
            {
                toplamsure = toplamsure + sureliste[j];
            }

            sayac = 0;

            sw.WriteLine("---------------------------------------");
            sw.WriteLine("Oyun İçin Harcanan Toplam Süre : " + toplamsure + " saniye");
            sw.WriteLine("---------------------------------------");

            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void dosyadanOku(string ad) // İstatiksel bilgiler txt dosyasından çekilir
        {
            try
            {
                string dosya_yolu = @ad + ".txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi = sw.ReadLine();

                while (yazi != null)
                {
                    Console.WriteLine(yazi);
                    yazi = sw.ReadLine();
                }

                sw.Close();
                fs.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Kullanıcı Adınıza Dair Bilgiler Bulunamadı.");
            }
        }
    }
}
