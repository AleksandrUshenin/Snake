using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Zmeika
{
    class Program
    {
        static int x = 10;
        static int y = 10;
        static int DlinnaZ = 4;
        static int[] xm = new int[6];
        static int[] ym = new int[6];
        static int cicle = 0;
        static int R1 = 0;
        static int R2 = 0;
        static string Z = "0";
        public static ConsoleKeyInfo keyPressed;
        public static int TimeZ = 350;
        static void Main(string[] args)
        {
            int H = Console.BufferHeight;
            int W = Console.BufferWidth;
            int Wh = Console.WindowHeight;
            int Ww = Console.WindowWidth;
            Console.Write(" {0} {1} - {2} {3}", H, W, Wh, Ww);
            //Console.ReadLine();
            Console.SetWindowSize(80, 30);
            Console.SetBufferSize(80, 30);
            Console.CursorVisible = false;
            Visov();
            Eat();
            Dvigenie1();
            Programma();
            Console.ReadLine(); 
        }
        static void Visov()
        {
            StartPograma start = new StartPograma();
            start.Vhod();
        }
        static void ProverkaNaOblost()
        {
            int W = Console.BufferWidth;
            int H = Console.BufferHeight;
            if (x == 0) { x = W-2; }
            if (x == W-1) { x = 0; }

            if (y == 0) { y = H-2; }
            if (y == H-1) { y = 1; }
        }
        static void Dvigenie1()
        {
            keyPressed = Console.ReadKey(true);
            Thread myThread = new Thread(new ThreadStart(Dvigenie2));
            myThread.Start();
            do
            {
                if ((keyPressed.Key == ConsoleKey.Enter)) { Thread.Sleep(5000); }
                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    y--;
                    ProverkaNaOblost();
                    Console.SetCursorPosition(x, y);
                    Console.Write(Z);
                }
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    y++;
                    ProverkaNaOblost();
                    Console.SetCursorPosition(x, y);
                    Console.Write(Z);
                }
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                    ProverkaNaOblost();
                    Console.SetCursorPosition(x, y);
                    Console.Write(Z);
                } if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    x++;
                    ProverkaNaOblost();
                    Console.SetCursorPosition(x, y);
                    Console.Write(Z);
                }
                Programma();
                Thread.Sleep(TimeZ);
            }
            while (keyPressed.Key != ConsoleKey.Escape);
            Console.WriteLine("End");
            Dvigenie1();
        }
        static void Dvigenie2()
        {
            keyPressed = Console.ReadKey(true);
            Dvigenie2();
        }
        static void Programma()
        {
            Display();
            Console.SetCursorPosition(x, y);
            xm[cicle] = x;
            ym[cicle] = y;
            cicle++;
            Dlina();
        }
        static void Dlina() 
        {
            if (DlinnaZ == 0)
            {
                int[] x2 = new int[xm.Length + 1];
                int[] y2 = new int[xm.Length + 1];
                for (int u = 0; u < xm.Length; u++)
                { x2[u] = xm[u]; y2[u] = ym[u]; }
                Console.SetCursorPosition(x2[0], y2[0]);
                Console.Write(" ");
                for (int i = 0; i < xm.Length; i++)
                {
                    xm[i] = x2[i + 1];
                    ym[i] = y2[i + 1];
                }
            }
            if ((x == R1) && (y == R2))
            {
                Console.Beep(700, 300);
                if (TimeZ > 10) { TimeZ -= 5; }
                int[] x2 = new int[xm.Length + 1];
                int[] y2 = new int[xm.Length + 1];
                for (int u = 0; u < xm.Length; u++)
                { 
                    x2[u] = xm[u]; y2[u] = ym[u]; 
                }
                xm = x2;
                ym = y2;

                DlinnaZ += 1;
                Eat();
            }
            if (cicle == xm.Length) { cicle--; }
            if (DlinnaZ != 0)
            {
                DlinnaZ--;
            }
        }
        static void Eat() 
        {
            Random rand = new Random();
            R1 = rand.Next(1, 79);
            R2 = rand.Next(1, 29);
            Console.SetCursorPosition(R1, R2);
            Console.WriteLine("X");
            Console.SetCursorPosition(x, y);
        }
        static void Display()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("x =" + x + " y =" + y + " Dl =" + DlinnaZ + " cic =" + cicle + " | X.Len =" + xm.Length);
            Console.SetCursorPosition(x, y);
        }
    }
    class StartPograma
    {
        string versionProgram = "v2.0";
        public void Vhod()
        {
            DisplayRamka();
            DisplayN();
            Console.ReadLine();
            Console.Clear();
        }
        void DisolayMenu()
        { 
        }
        void DisplayN()
        {
            string[] bloksS = { ",d8888b", "b88P  Y88b", "Y88b", "Y888b.", "8Y88b.", "88b", "y88b  d88P", "Y8888P" };
            int[] sX = { 5, 4, 5, 6, 9, 11, 4, 6};
            int[] sY = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            string[] bloksN = {"88888b.", "888  88b", "888  888", "888  888", "888  888"};
            int[] nX = {  16, 16, 16, 16, 16 };
            int[] nY = {  5, 6, 7, 8, 9 };
            string[] bloksA = { "88888b.", "88b", ".d888888", "888  888", "Y888888" };
            int[] aX = { 26, 30, 25, 25, 26 };
            int[] aY = { 5, 6, 7, 8, 9 };
            string[] bloksK = { "888", "888", "888", "888  888", "888  88P", "888888K", "888  88b", "888  888" };
            int[] kX = { 34, 34, 34, 34, 34, 34, 34, 34 };
            int[] kY = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            string[] bloksE = { ".d88b", "d8P  Y8b", "88888888", "Y8b.", "Y888888" };
            int[] eX = { 44, 43, 43, 43, 44 };
            int[] eY = { 5, 6, 7, 8, 9 };
            DisplayAll(bloksS, sX, sY);
            DisplayAll(bloksN, nX, nY);
            DisplayAll(bloksA, aX, aY);
            DisplayAll(bloksK, kX, kY);
            DisplayAll(bloksE, eX, eY);
            Console.SetCursorPosition(55, 9);
            Console.Write(versionProgram);
        }
        void DisplayAll(string[] line, int[] x, int[] y)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 0; i < line.Length; i++)
            {
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write(line[i]);
            }
        }
        public void DisplayRamka()
        {
            int xL = Console.BufferWidth;
            int yL = Console.BufferHeight;
            for (int i = 0; i < xL - 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("*");
                Console.SetCursorPosition(i, yL - 1);
                Console.Write("*");
            };
            for (int i = 0; i < yL - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(xL - 1, i);
                Console.Write("*");
            }
            for (int i = 0; i < 50; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(6 + i, 12);
                Console.Write("_");
                Console.SetCursorPosition(6 + i, 26);
                Console.Write("_");
                if (i < 14)
                {
                    Console.SetCursorPosition(5, 13 + i);
                    Console.Write("|");
                    Console.SetCursorPosition(56, 13 + i);
                    Console.Write("|");
                }
            }
        }
    }
}
