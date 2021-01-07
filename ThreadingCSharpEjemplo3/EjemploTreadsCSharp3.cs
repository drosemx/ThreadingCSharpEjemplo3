using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;

namespace ThreadingCSharpEjemplo3
{
    class EjemploTreadsCSharp3
    {
        class EjemploThreadsCSharp3
        {
            private static int miTotalDeCirculos =7000000;
            private static int miCantidadDeProcesadores = Environment.ProcessorCount;
            private static Thread[] threadsArray;
            private static ArrayList[] colCirculos;

            private static ArrayList colFinal = new ArrayList();

            public static void Main()
            {
                threadsArray = new Thread[miCantidadDeProcesadores];
                 colCirculos = new ArrayList[miCantidadDeProcesadores];

                int miNumeroThread;

                for (miNumeroThread = 0; miNumeroThread < miCantidadDeProcesadores; miNumeroThread++)
                {
                    threadsArray[miNumeroThread] = new Thread(new ThreadStart(procesoThread));
                    threadsArray[miNumeroThread].Name = miNumeroThread.ToString();
                    threadsArray[miNumeroThread].Start();
                    Thread.Sleep(0);
                }
                for (miNumeroThread = 0; miNumeroThread < miCantidadDeProcesadores; miNumeroThread++)
                {

                    threadsArray[miNumeroThread].Join();

                }
                for (miNumeroThread = 0; miNumeroThread < miCantidadDeProcesadores; miNumeroThread++)
                {
                    
                    colFinal.AddRange(colCirculos[miNumeroThread]);
                    
                }
            }

            public static void procesoThread()
            {
                long i;
                int miNumeroThread = Convert.ToInt32(Thread.CurrentThread.Name);
                long miCantidadDeCirculos = miTotalDeCirculos / miCantidadDeProcesadores;
                int miMultiplicador = miNumeroThread + 1;

                Circulo loCirculo;
                colCirculos[miNumeroThread] = new ArrayList((int)miCantidadDeCirculos);

                for (i = 1; i <= miCantidadDeCirculos; i++)
                {
                    loCirculo = new Circulo();
                    loCirculo.Radio = ((i * miMultiplicador) % 255);
                    loCirculo.calcularDiametro();
                    colCirculos[miNumeroThread].Add(loCirculo);
                }
            }

        }
    }
}
