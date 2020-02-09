using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aknakereso
{
    class Program
    {


        static void Feltöltés(char[,] pálya)
        {
            for (int sor = 0; sor < pálya.GetLength(0); sor++)
            {
                for (int oszlop = 0; oszlop < pálya.GetLength(1); oszlop++)
                {
                    pálya[sor, oszlop] = '_';
                }
            }
        }

        static void Main(string[] args)
        {
            char[,] pálya = new char[10, 10];
            Console.WriteLine("Add meg a bombák számát: ");
            int bombaSzám = int.Parse(Console.ReadLine());
            Feltöltés(pálya);
            BombaSorsoló(pálya, bombaSzám);
            bool legyenBomba = false;
            Kirajzoló(pálya, legyenBomba);
            
            int lépx;
            int lépy;
            do
            {
                Lépés(pálya, out lépx, out lépy);  //bekér egy sor és oszlop indexet és kirak egy X-et.
            } while (pálya[lépx, lépy] != 'B');
            
            Tipp(pálya, lépx, lépy);

            //Függvény, ami megadja hogy az adott hely(x,y) szomszédjában hány db bomba van. Házi



            Console.ReadKey();
        }

        static int Tipp(char[,] pálya, int lépx, int lépy)
        {
            int db=0;
            for (int i = lépx-1; i <=lépx+1; i++)
            {
                for (int j = lépy-1; j <=lépy+1; j++)
                {
                    if (lépx-1=='B'|| lépx + 1 == 'B'||lépy-1=='B'|| lépy + 1 == 'B')
                    {
                        db++;
                    }
                }
            }
            return db;
        }

        static void Lépés(char[,] pálya, out int lépx, out int lépy)
        {
            Console.WriteLine("X koordináta:");
            lépx = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Y koordináta:");
            lépy = int.Parse(Console.ReadLine()) - 1;
            if (lépx > 10 || lépy > 10)
            {
                Console.WriteLine("Csak 10 és az alatti kordinátákat adhat meg!");
                Console.WriteLine("X koordináta:");
                lépx = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Y koordináta:");
                lépy = int.Parse(Console.ReadLine()) - 1;
            }

            if (pálya[lépx, lépy] == 'B')
            {
                Console.WriteLine("YOU DIED");
            }
            else
            {
                pálya[lépx, lépy] = 'X';
                Kirajzoló(pálya, false);
            }

            

        }

        static void Kirajzoló(char[,] pálya, bool legyenBomba)
        {
            for (int i = 0; i < pálya.GetLength(0); i++)
            {
                for (int j = 0; j < pálya.GetLength(1); j++)
                {
                    if (legyenBomba)
                    {
                        Console.Write(pálya[i, j]);
                    }
                    else if (pálya[i, j] != 'X')
                    {
                        Console.Write('_');
                    }

                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }

        static void BombaSorsoló(char[,] pálya, int bombaSzám)
        {
            Random rnd = new Random();
            int sor;
            int oszlop;
            for (int i = 0; i < bombaSzám; i++)
            {

                do
                {
                    sor = rnd.Next(10);
                    oszlop = rnd.Next(10);
                } while (pálya[sor, oszlop] == 'B');
                pálya[sor, oszlop] = 'B';
            }
        }
    }
}