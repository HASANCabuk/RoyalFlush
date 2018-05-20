using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
    internal  class Oyuncu
    {
        Bilgisayar bilgisayar = new Bilgisayar();
        List<Kart> el = new List<Kart>();//elindeki karların listesi
        public Oyuncu(Bilgisayar b)
        {
            bilgisayar = b;
        }
        internal string Adi { get; set; }
        internal int  bakiye=100,bahisMiktari=-1,tur=0;
        private int kazanc,a,sayac=0;
        private string Degis { get; set; }
        private  List<Kart> degisecek = new List<Kart>();// degişecek karların listesi
           internal void Iletisim()
        {
            tur++;
            if (tur==1)
            {
                Console.WriteLine("Lutfen ismini gir");
                do
                {                    
                    Adi = Console.ReadLine();
                    Console.WriteLine(int.TryParse(Adi,out a)==false ? "":"Lütfen harflerden oluşan bir isim giriniz");

                } while (int.TryParse(Adi, out a));
              
                Console.WriteLine("Merhaba {0}. {1} SP bakiyen var", Adi, bakiye);
            }          
            do
            {
                Console.WriteLine("Lütfen {0}. tur için bahis miktarını gir(1-5 veya çıkmak için 0)", tur);
                try
                {                  
                    bahisMiktari = Convert.ToInt32(Console.ReadLine());
                    if (bahisMiktari == 0)
                    {
                        return;
                    }
                }                 
                catch (Exception )
                {
                    Console.WriteLine("Lütfen tamsayılı bir  deger giriniz");
                }
             
            } while (bahisMiktari<0||bahisMiktari>5);
            bakiye = bakiye - bahisMiktari;
            el = Dagitici.Dagit<List<Kart>>(bilgisayar.kartlar);
            Console.Write("Kartların şunlar:");
            for (int i = 0; i < el.Count; i++)
            {
                Console.Write("({0}){1} ",i+1,el[i].TurAdi+ el[i].DegiskenAdi);
            }
            Console.WriteLine("\nHangilerini degiştirmek istersin! Degiştirmek istemiyorsanız (0) giriniz");
            do
            {              
                Degis =Console.ReadLine();
                Console.WriteLine(Int32.TryParse(Degis, out a) == true ? "" : "Dogru aralıkta deger giriniz");
            } while (!int.TryParse(Degis,out a));           
                for (int i = 0; i < Degis.Length; i++)
                {                  
                        if (Convert.ToInt32(Degis[i].ToString()) <= 0|| Convert.ToInt32(Degis[i].ToString())>5)
                        {
                        sayac++;
                        Console.Write("Kartların şunlar:");
                        for (int j = 0; j < el.Count; j++)
                         {
                        Console.Write("({0}){1} ", j + 1, el[j].TurAdi + el[j].DegiskenAdi);
                         }
                         kazanc = bahisMiktari * bilgisayar.Degerlendir(el);
                         bakiye += kazanc;
                        Console.WriteLine("{0} SP verildi. Yeni bakiyen {1}", kazanc, bakiye);                     
                        break;
                          }
                       else
                      degisecek.Add(el[Convert.ToInt32(Degis[i].ToString()) - 1]);
                }
            if (sayac==0)
            {
                el = bilgisayar.KartDegistir(degisecek, el);
                degisecek.Clear();
                Console.Write("Yeni kartların şunlar:");
                for (int i = 0; i < el.Count; i++)
                {
                    Console.Write("({0}){1} ", i + 1, el[i].TurAdi + el[i].DegiskenAdi);
                }
                kazanc = bahisMiktari * bilgisayar.Degerlendir(el);
                bakiye += kazanc;
                Console.WriteLine("{0} SP verildi. Yeni bakiyen {1}", kazanc, bakiye);
            }                                                              
        }
    }
}
