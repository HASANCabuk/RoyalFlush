using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
  internal class Oyun { 

        Bilgisayar bilgisayar = new Bilgisayar();     
        public void OyunBasla()
        {
            Oyuncu oyuncu = new Oyuncu(bilgisayar);
            while (oyuncu.bakiye<1000 && oyuncu.bahisMiktari!=0)//oyuncunu bahis miktarını 0 olmaması veya bakiyesini 1000 SP aşmaması halinde oyun devam eder
            {
                bilgisayar.KartOlustur();//bilgisayar her oyunda yeni kart oluşturur
                oyuncu.Iletisim();
            }
            if (oyuncu.bakiye>=1000)
            { 
                Console.WriteLine("Güle güle {0},{1} tur oynadın ve {2} SP ile oyunu tamamladın.", oyuncu.Adi, oyuncu.tur, oyuncu.bakiye);
            }
            else
            Console.WriteLine("Güle güle {0},{1} tur oynadın ve {2} SP ile oyunu tamamladın.",oyuncu.Adi,oyuncu.tur-1,oyuncu.bakiye);    
          
        }
    }
}
