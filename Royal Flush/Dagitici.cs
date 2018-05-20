using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
   internal  class Dagitici
    {
        public static List<Kart> Dagit<T>(T gKartlar)
        {
            Random r = new Random();
            Kart kart = new Kart();
            List<Kart> el = new List<Kart>();
            List<Kart> kartlar = new List<Kart>();
            kartlar = gKartlar as List<Kart>;
            int j;
            for (int i = 0; i < kartlar.Count; i++)
            {
                j = r.Next(52);
                kart = kartlar[j];
                kartlar[j] = kartlar[i];
                kartlar[i] = kart;

            }
          
            while (el.Count != 5)
            {
                kart = kartlar[r.Next(52)];
                if (!kart.Verildi)
                { 
                    kart.Verildi = true;
                    el.Add(kart);
                }
            }

            return el;
        }
    }
}
