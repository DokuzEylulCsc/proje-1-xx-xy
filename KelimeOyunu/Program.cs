using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*KAYNAKÇA 
 * https://www.yazilimkodlama.com/programlama/c-txt-dosyasi-okuma-ve-turkce-karakter-sorunu-cozumu/
 * https://www.kodlamamerkezi.com/c-net/c-ile-dosya-okuma-ve-yazma-islemleri/
 * https://www.youtube.com/user/mxsoysal
 * https://www.udemy.com/c-sharp-kursu/learn/v4/t/lecture/8921152?start=0
 */
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
