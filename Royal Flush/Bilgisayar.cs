using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
   internal  class Bilgisayar
    {
        private  string[] tur = new string[] { "D", "S", "H", "C" };
        private  string[] degisken = new string[] { "A", "2", "3", "4" , "5" , "6" , "7" , "8" , "9" , "10" , "J" , "Q" , "K" };
        internal List<Kart> kartlar = new List<Kart>();
        internal void KartOlustur()
        {
            Kart kart=new Kart();
            kartlar.Clear();
            foreach (var item in tur)
            {
                for( int i=0;i<degisken.Length;i++)
                {
                    kart = new Kart();
                    kart.TurAdi = item;
                    kart.Verildi = false;
                    kart.DegiskenAdi = degisken[i];
                    kart.No = i + 1;
                    kartlar.Add(kart);
                }
            }        
        }
       internal List<Kart> KartDegistir(List<Kart> degisecekler,List<Kart> el)
        {
            Random r = new Random();
            Kart kart = new Kart();
            for (int i = 0; i <el.Count; i++)
            {
                for (int j= 0; j < degisecekler.Count; j++)
                {
                    if (el[i].TurAdi+ el[i].DegiskenAdi== degisecekler[j].TurAdi + degisecekler[j].DegiskenAdi)
                    {
                        el.RemoveAt(i);
                    }
                }
            }        
            while (el.Count!=5)
            {
                kart = kartlar[r.Next(0, 52)];
                if (!kart.Verildi)
                {
                    kart.Verildi = true;
                    el.Add(kart); 
                }
            }

            return el;
        }
        internal  int  Degerlendir(List<Kart> el)
        {
            if (RoyalFlush(el))
            {
                return 250;
            }
            else if (StraightFlush(el))
            {
                return 50;
            }
            else if (FourOfaKind(el))
            {
                return 25;
            }
            else if (FullHouse(el))
            {
                return 9;
            }
            else if (Flush(el))
            {
                return 6;
            }
            else if (Straight(el))
            {
                return 4;
            }
            else if (ThreeOfaKind(el))
            {
                return 3;
            }
            else if (TwoPair(el))
            {
                return 2;
            }
            else if (JacksOrBetter(el))
            {
                return 1;
            }
                                     
            Console.WriteLine("Bu el kazanamadın!");
            return 0;
        }
        private bool RoyalFlush(List<Kart> el)
        {
            string[] ryl = new string[] { "A", "K", "Q", "J", "10" };
            int royal = 0;
            for (int i = 0; i < el.Count; i++)
            {
                for (int j = 0; j < ryl.Length; j++)
                {
                    if (el[i].DegiskenAdi == ryl[j])
                    {
                        ryl[j] = "0";
                        royal++;
                    }
                   
                }
            }
            if (royal == 5)
            {
                Console.WriteLine("Elinde royal flush var!");
                return true;
            }else
            return false;
        }                              
        private bool StraightFlush(List<Kart> el)
        {
            int straight = 0;
            List<int> elNo = new List<int>();
                            
                foreach (var item in el)
                {
                    if (el[0].TurAdi==item.TurAdi)
                    {
                    straight++;
                    }
                elNo.Add(item.No);
                }
              elNo.Sort();
            if (straight==5)
            {
                bool sirali=true;
                for (int i = 0; i <elNo.Count-1; i++)
                {
                    if (elNo[i + 1] - elNo[i] == 1) { }
                    else
                        sirali = false;
                }
                if (sirali==true)
                {
                    Console.WriteLine("Elinde straight flush var!");
                    return true;
                }               
            }                               
            return false;
        }
        private bool  FourOfaKind(List<Kart> el)
        {
            int kare = 0;
            foreach (var item in el)
            {
                kare = 0;
                foreach (var item2 in el)
                {
                    if (item.DegiskenAdi == item2.DegiskenAdi)
                    {
                        kare++;                        
                    }                   
                }
                if (kare == 4)
                {
                    break;
                }
            }
            if (kare==4)
            {
                Console.WriteLine("Elinde Four Of A Kind var!");
                return true;
            }
            return false;
           
        }
        private bool FullHouse(List<Kart> el)
        {
            int ful3 = 0,ful2=0,a;
            foreach (var item in el)
            {
                ful3 = 0;
                if (int.TryParse(item.DegiskenAdi, out a))
                {
                    foreach (var item2 in el)
                    {

                        if (item.DegiskenAdi == item2.DegiskenAdi)
                        {
                            ful3++;
                        }


                    }
                }
                else
                {
                    return false;
                }
                if (ful3 == 3)
                {
                    break;
                }
            }
            foreach (var item in el)
            {
                ful2 = 0;
                foreach (var item2 in el)
                {
                    if (item.DegiskenAdi == item2.DegiskenAdi)
                    {
                        ful2++;
                    }
                }
                if (ful2 == 2)
                {
                    break;
                }
            }
            if (ful3 == 3 && ful2 == 2)
            {
                Console.WriteLine("Elinde Full House var!");
                return true;
            }
           

            return false;
        }
        private bool Flush(List<Kart> el)
        {

            int flush = 0;
            foreach (var item in el)
            {
                if (el[0].TurAdi==item.TurAdi)
                {
                    flush++;
                }
            }
            if (flush==5)
            {
                Console.WriteLine("Elinde Flush Var.");
                return true;
            }
            return false;
        }
        private bool Straight(List<Kart> el)
        {
            List<int> elNo = new List<int>();
            foreach (var item in el)
            {
                elNo.Add(item.No);
            }
            elNo.Sort();
            bool sirali = true;
            for (int i = 0; i < elNo.Count - 1; i++)
            {
                if (elNo[i + 1] - elNo[i] == 1) { }
                else
                    sirali = false;
            }
            if (sirali == true)
            {
                Console.WriteLine("Elinde Straight var!");
                return true;
            }
            return false;
        }
        private bool ThreeOfaKind(List<Kart> el)
        {
            int ful3 = 0;
            foreach (var item in el)
            {
                ful3 = 0;
                    foreach (var item2 in el)
                    {
                        if (item.DegiskenAdi == item2.DegiskenAdi)
                        {
                            ful3++;
                        }
                    }
                if (ful3 == 3)
                {
                    Console.WriteLine("Elinizde Three Of A Kind Var");
                    return true;
                }
            }
            return false;
        }
        private bool TwoPair(List<Kart> el)
        {
            int pair = 0;
            List<int> elNo = new List<int>();
            foreach (var item in el)
            {
                elNo.Add(item.No);
            }
            elNo.Sort();

            for (int i = 0; i < elNo.Count-1; i++)
            {
                if (elNo[i+1]-elNo[i]==0)
                {
                    pair++;
                }
            }
            if (pair==2)
            {
                Console.WriteLine("Elinde Two Pair Var");
                return true;
            }

            return false;
        }
        private bool JacksOrBetter(List<Kart> el)
        {
            int jack = 0;
            List<int> elNo = new List<int>();
            foreach (var item in el)
            {
                elNo.Add(item.No);
            }
            elNo.Sort();

            for (int i = 0; i < elNo.Count - 1; i++)
            {
                if (elNo[i + 1] - elNo[i] == 0)
                {
                    jack++;
                }
            }
            if (jack == 1)
            {
                Console.WriteLine("Elinde Jacks Or Better Var");
                return true;
            }
            return false;
        }
    }
}
