using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiralynok
{
    class Tabla
    {
        private char[,] T;
        private char Urescella;
        private int UresOszlopokSzama;
        private int UresSorokSzama;
        public Tabla(char ch)
        {
            T = new char[8, 8];
            Urescella = ch;
            int s = 8;
            int o = 8;
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < o; j++)
                {
                    T[i,j] = Urescella;
                }
            }
        }
        public void Elhelyez()
        { 
        
        }
        public void FajlbaIr()
        { 
        
        }
        public void Megjelenit()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,-2}",T[i,j]);
                }
            }
        }
        public int UresOszlop()
        {
            return 0;
        }
        public int UresSor()
        {
            return 0; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Királynők feladat:");
            Tabla t = new Tabla('#');
            Console.WriteLine("Üres tábla: ");
            t.Megjelenit();
            Console.ReadKey();
        }
    }
}
