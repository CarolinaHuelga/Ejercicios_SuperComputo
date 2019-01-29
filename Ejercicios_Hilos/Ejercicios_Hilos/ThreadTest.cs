using System;
using System.Threading;

namespace Ejercicios_Hilos
{
    public class ThreadTest
    {
        static bool done;
        static readonly object locker = new object();

        static void Main(string[] args)
        {
            // EJERCICIO 3
            new Thread(Go).Start();
            Go();
            // EJERCICIO 2
            /*
            ThreadTest tt = new ThreadTest();       // Crea una instancia en común
            new Thread(tt.Go).Start();
            tt.Go();
            Console.ReadKey();
            */
            /* 
            //EJERCICIO 1
            Thread t = new Thread(WriteY);
            t.Start();

            for (int i = 0; i < 100000; i++)
                Console.Write("x");
            */
            Console.ReadKey();
          
        }

        /// <summary>
        /// Go es una instancia
        /// Bloqueo
        /// EJERCICIO 3
        /// </summary>
        static void Go()
        {
            lock (locker)
            {
              if (!done)
                {
                    Console.WriteLine("Done :D"); done = true;
                }
            }
        }

        /// <summary>
        /// Go es una instancia
        /// EJERCICIO 2
        /// </summary>
        /*void Go()
        {
            if (!done)
            {
                done = true;
                Console.WriteLine("Done :D");
            }
        }*/
        /// <summary>
        /// Impresiones de y
        /// EJERCICIO 1
        /// </summary>
        public static void WriteY()
        {
            for (int i = 0; i < 100000; i++)
                Console.Write("y");
        }
    }
}
