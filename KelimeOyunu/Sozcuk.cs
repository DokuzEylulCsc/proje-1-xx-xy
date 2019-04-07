using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //dosya okuma işlemi için

namespace KelimeOyunu
{
    public class Sozcuk
    {
        string[] yazi = new string[159];

        private void DosyaOkuma()
        {
            string dosyayolu = @"kelimeler.txt";
            FileStream fs = new FileStream(dosyayolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("iso-8859-9"), false); //turkce karakterlere duyarlılık
            int i = 0;
            while (sr.EndOfStream != true)
            {
                yazi[i] = sr.ReadLine();
                i++;
            }
        }

        public Sozcuk() //yapıcı sınıf, programda bir kere çalışacağı için diğer sınıflardan erişimi kapattım
        {
            DosyaOkuma();
        }

        Random random = new Random();

        public string Zorluk(int x) //zorluk derecesi secimi
        {
            if (x == 1)
            {
                return yazi[random.Next(55)];
            }
            else if (x == 2)
            {
                return yazi[random.Next(55, 108)];
            }
            else return yazi[random.Next(108, 159)];
        }
    }
}
