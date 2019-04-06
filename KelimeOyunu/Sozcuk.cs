using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KelimeOyunu
{
    public class Sozcuk
    {
        private void DosyaOkuma()
        {
            string dosyayolu = @"kelimeler.txt";
            FileStream fs = new FileStream(dosyayolu, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("iso-8859-9"), false); //turkce karakterlere duyarlılık
            string[] yazi = new string[159];
            int i = 0;
            while (sr.EndOfStream != true)
            {
                yazi[i] = sr.ReadLine();
                Console.WriteLine(yazi[i]);
                i++;
            }
            Console.ReadKey();
        }

        public Sozcuk() //yapıcı sınıf, programda bir kere çalışacağı için diğer sınıflardan erişimi kapattım
        {
            DosyaOkuma();
        }
    }
}
