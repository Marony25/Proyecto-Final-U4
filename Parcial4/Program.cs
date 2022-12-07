using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Parcial4
{
    class program
    {
        public static String grupoPrueba;

        //Gol juego 1
        public static int gol11;
        public static int gol12;
        public static int gol13;
        public static int gol14;

        //Gol juego 2
        public static int gol21;
        public static int gol22;
        public static int gol23;
        public static int gol24;

        //Gol juego 3
        public static int gol31;
        public static int gol32;
        public static int gol33;
        public static int gol34;

        static void Main(String[] args)
        {
            //Oportunidades de acceso.
            int rechazo = 0;
            bool rep = true;
            while (rep == true)
            {
                //Login
                Console.WriteLine("Ingrese sus credenciales");
                Console.Write("Usuario: ");
                String usuarioPrueba = Console.ReadLine().ToString();
                Console.Write("Contraseña: ");
                String contraseñaPrueba = Console.ReadLine().ToString();

                //Validar login
                if (Login.Autenticar(usuarioPrueba, contraseñaPrueba))
                {
                    Console.WriteLine("\nAcceso Concedido, buen día " + usuarioPrueba);
                    GruposQatar.gruposQatar();
                    Console.WriteLine("\n");
                    GruposQatar.partidosQatar();
                    Console.ReadKey();
                    break;
                }
                else
                {
                    if(rechazo < 2)
                    {
                        rechazo++;
                        Console.WriteLine("\nCredenciales erroneas");
                        Console.WriteLine("Oportunidades restantes: " + (3-rechazo) + "\n");                        
                    }
                    else if (rechazo == 2)
                    {
                        rep = false;
                        Console.WriteLine("\nOportunidades agotadas");
                        Console.WriteLine("Cerrando program...");
                    }
                }
            }

        }
    }
}
