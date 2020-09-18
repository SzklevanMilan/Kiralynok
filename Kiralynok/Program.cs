using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralyno
{
    class Tabla
    {
        char[,] T;//Tömb
        char UresCella;
        int UresOszlopokSzama;
        int UresSorokSzama;
        public Tabla(char ch)
        {
            T = new char[8, 8];
            UresCella = ch;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    T[i, j] = UresCella;
                }
            }
        }
        public void Elhelyez(int N)
        {
            //1. Véletlen helyérték létrehozása
            //Random osztály értékek halmaza [0,7]
            //véletlen sor és oszlop
            //elhelyezzük a "K"t csak akkor, ha "#" van
            Random vel = new Random();
            for (int i = 0; i < N; i++)
            {
                int sor = vel.Next(0, 8);
                int oszlop = vel.Next(0, 8);
                while (T[sor, oszlop] == 'K')
                {
                    sor = vel.Next(0, 8);
                    oszlop = vel.Next(0, 8);
                }
                T[sor, oszlop] = 'K';
            }
        }
        public void FajlbaIr(StreamWriter fajl)
        {
            //fajl.WriteLine("Ez egy szöveg.");
            for (int i = 0; i < 8; i++)
            {
                string sor = "";
                for (int j = 0; j < 8; j++)
                {
                    sor += T[i, j];
                }
                fajl.WriteLine(sor);
            }
        }
        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,-2}", T[i, j]);
                }
            }
        }
        public bool UresOszlop(int oszlop)
        {
            //Ha talál "K" akkor hamissal tér vissza
            //üres-e a sor
            /*1 ciklus, a soron végig
             * ha T[sor[i] meg T[i, oszlop]
             * */
            //Ez is jó!!!!!
            
              /*int i = 0;
            while (i<8 && T[i,oszlop]!='K')
            {
                i++;
            }
            if (i<8)
            {
                return false;
            }
            else
            {
                return true;
            }*/
            


            bool k = true;
            for (int i = 0; i < 8; i++)
            {
                if (T[i, oszlop] == 'K')
                {
                    k = false;
                }
            }
            return k;
       }

        public bool UresSor(int sor)
        {
                bool k = true;
                for (int i = 0; i < 8; i++)
                {
                    if (T[i, sor] == 'K')
                    {
                        k = false;
                    }
                }
                return k;
                //Ez is jó!!
                /*int i = 0;
                while (i < 8 && T[sor, i] != 'K')
                {
                    i++;
                }
                if (i < 8)
                {
                    return false;
                }
                else
                {
                    return true;
                }*/
            }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat:");
            Console.WriteLine();
            Tabla t = new Tabla('#');
            Tabla[] tablak = new Tabla[64];

            Console.WriteLine("Üres tábla: ");
            t.Megjelenit();
            Console.WriteLine();
            t.Elhelyez(1);
            Console.WriteLine();
            Console.WriteLine("Királynő elhelyezése:");
            t.Megjelenit();
            Console.WriteLine();
            t.Elhelyez(7);
            Console.WriteLine();
            Console.WriteLine("Véletlen darab királynő elhelyezése: ");
            t.Megjelenit();
            Console.WriteLine();
            Console.WriteLine("Melyik sor: ");
            int sor = int.Parse(Console.ReadLine());

            if (t.UresSor(sor))
            {
                Console.WriteLine("A megadott sor nem üres.");
            }
            else
            {
                Console.WriteLine("A megadott sor üres.");
            }
            t.UresSor(5);
            Console.WriteLine("Melyik oszlop: ");
            int oszlop = int.Parse(Console.ReadLine());

            if (t.UresSor(oszlop))
            {
                Console.WriteLine("A megadott oszlop nem üres.");
            }
            else
            {
                Console.WriteLine("A megadott oszlop üres.");
            }
            t.UresOszlop(3);
            Console.WriteLine();

            Console.WriteLine("8.feladat: Az üres oszlopok és sorok száma:");
            int UresSor = 0;
            int UresOszlop = 0;
            for (int i = 0; i < 8; i++)
            {
                if (t.UresOszlop(i) == true)
                {
                    UresOszlop++;
                }
                if (t.UresSor(i) == true)
                {
                    UresSor++;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Üres sorok száma: {0}.",UresSor);
            Console.WriteLine("Üres oszlopok száma: {0}.",UresOszlop);
            Console.WriteLine();

            StreamWriter ki = new StreamWriter("adatok.txt");
            for (int i = 0; i < 64; i++)
            {
                tablak[i] = new Tabla('*');
            }

                for (int i = 0; i < 64; i++)
                {
                    tablak[i].Elhelyez(i + 1);
                    tablak[i].FajlbaIr(ki);
                    ki.WriteLine();
                }
            ki.Close();

            Console.ReadKey();
        }
    }
}
