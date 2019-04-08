using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class Oyuncu
    {
        private string adi;
        public Oyuncu(string isim) //nesne olusturulurken "adi"nin girilmesi icin, zorunlu kılıyor
        {
            this.adi = isim;
        }

        public string OyuncuAdi //adi isimli degiskene dogrudan disaridan erisilmesin diye
        {
            get
            {
                return this.adi;
            }
            set
            {
                this.adi = value;
            }
        }

        /*AI aa = new AI();
        public void KelimeGonder(string sozcuk) //disaridan alinan kelimeyi karar fonksiyonuna gönderir
        {
            aa.Karar(sozcuk);
        }*/
    }
}
