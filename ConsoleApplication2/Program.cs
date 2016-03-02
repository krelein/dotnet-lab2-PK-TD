using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Plansza P = new Plansza();

            P.GenerujPlansze(10, 10);

            while(true)
            {
                Console.Clear();
                P.Wyswietl();
                P.Iteruj();
                P.Zwieksz();             
                Thread.Sleep(300);
       
            }

        }

    
    }

    class Plansza
    {
        public int[,] plansza;
        private int[,] pom;
        private int wys, szer;
        public void GenerujPlansze(int x, int y)
        {
            wys = x; szer = y;

            plansza = new int[x,y];
            Random rnd = new Random();

            for (int i = 0; i < x; ++i)
                for (int j = 0; j < y; ++j)
                {
                    if (rnd.Next(4) == 0)
                        plansza[i, j] = 1;
                    else
                        plansza[i, j] = 0;
                }
                    
        }

        public void Wyswietl()
        {
            for (int i = 0; i < wys; ++i)
            {
                for (int j = 0; j < szer; ++j)
                {
                    if (plansza[i, j] == 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                    
                }
                Console.Write("\n");
            }
        }

        public void Iteruj()
        {
            pom = new int[wys, szer];

            for (int i = 0; i < wys; ++i) // reprodukcja
                for (int j = 0; j < szer; ++j)
                {
                    pom[i, j] = 0;
                    if (Sasiedzi(i, j) == 3 && plansza[i,j] == 0)
                        pom[i, j] = 1;
                }

            for (int i = 0; i < wys; ++i) // ginie
                for (int j = 0; j < szer; ++j)
                {
                    if (Sasiedzi(i, j) < 2 || Sasiedzi(i, j) > 3)
                        plansza[i, j] = 0;
                }


            for (int i = 0; i < wys; ++i) // przepisanie
                for (int j = 0; j < szer; ++j)
                {                 
                        if(pom[i,j] == 1)
                        plansza[i, j] = 1;
                }
        }

        public int Sasiedzi(int a, int b)
        {
            int ile=0;

            if(a!=0)
            {
                if (b != 0)
                    if (plansza[a - 1, b - 1] == 1)
                        ++ile;

                if (plansza[a - 1, b] == 1)
                    ++ile;

                if (b != szer-1)
                    if (plansza[a - 1, b + 1] == 1)
                        ++ile;
            }

           if (b != 0)
               if (plansza[a, b - 1] == 1)
                    ++ile;

           if (b != szer-1)
               if (plansza[a, b + 1] == 1)
                     ++ile;

           if (a != wys-1)
           {

               if (b != 0)
                   if (plansza[a + 1, b - 1] == 1)
                       ++ile;

               if (plansza[a + 1, b] == 1)
                   ++ile;

               if (b != szer-1)
                   if (plansza[a + 1, b + 1] == 1)
                       ++ile;
           }

            return ile;
        }

        public void Zwieksz()
        {
            bool gora, dol, prawo, lewo;

            gora = false;
            dol = false;
            prawo = false;
            lewo = false;

            for (int i = 0; i < szer; ++i) // gora
                if (plansza[0, i] == 1)
                    gora = true;

            for (int i = 0; i < szer; ++i) // dol
                if (plansza[wys -1, i] == 1)
                    dol = true;

            for (int i = 0; i < szer; ++i) // lewo
                if (plansza[i , 0] == 1)
                    lewo = true;

            for (int i = 0; i < szer; ++i) // prawo
                if (plansza[i, szer-1] == 1)
                    prawo = true;
      

            if(gora || dol || prawo || lewo)
            {
                wys = wys +2;
                szer = szer +2;

                pom = new int[wys, szer];
                

                for (int i = 0; i < wys; ++i) // reprodukcja
                    for (int j = 0; j < szer; ++j)
                    {
                        pom[i, j] = 0;
                        
                    }

              

                for (int i = 1; i < wys-1; ++i) // reprodukcja
                    for (int j = 1; j < szer-1; ++j)
                    {
                        pom[i, j] = plansza[i-1, j-1];
                    }

                plansza = new int[wys, szer];

                for (int i = 0; i < wys; ++i) // reprodukcja
                    for (int j = 0; j < szer; ++j)
                    {
                        plansza[i, j] = pom[i, j];

                    }

            }


           
        }

       
    }


}
