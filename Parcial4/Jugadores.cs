using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial4
{
    public class Jugadores
    {
        //Equipos
        static string equi1I;
        static string equi2I;
        static string equi3I;
        static string equi4I;

        //Jugadores
        static string equi1J;
        static string equi2J;
        static string equi3J;
        static string equi4J;

        //Nodos
        static NodoJugador primero = null;
        static NodoJugador ultimo = null;

        public static void equiposIdentificador()
        {
            using (StreamReader sr = new StreamReader("Grupos.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] grupos = line.Split('|');
                    {
                        if (grupos[0] == program.grupoPrueba)
                        {
                            equi1I = grupos[1];
                            equi2I = grupos[2];
                            equi3I = grupos[3];
                            equi4I = grupos[4];
                        }
                    }
                }
            }
        }

        public static void equiposJSelector()
        {
            using (StreamReader sr = new StreamReader("EnlaceJ.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] grupos = line.Split('|');
                    {
                        if (grupos[0] == program.grupoPrueba)
                        {
                            equi1J = grupos[1];
                            equi2J = grupos[2];
                            equi3J = grupos[3];
                            equi4J = grupos[4];
                        }
                    }
                }
            }
        }

        public static void goleadoresEqui1()
        {
            Jugadores.equiposIdentificador();
            Jugadores.equiposJSelector();

            if (program.gol11 > 0)
            {
                using (StreamReader sr = new StreamReader(equi1J))
                {
                    string line;              
                    Console.WriteLine("\n" + "Jugadores de " + equi1I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol11)
                {
                    int rep = 0;
                    while(rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi1J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi1I + ": ");
                            string goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (goleador == jugadores[0])
                                {

                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }
                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }
                program.gol11 = 0;
            }
            else if (program.gol21 > 0)
            {
                using (StreamReader sr = new StreamReader(equi1J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi1I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }


                int x = 0;
                while (x != program.gol21)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi1J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi1I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                        Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }
                program.gol21 = 0;
            }
            else if (program.gol31 > 0)
            {
                using (StreamReader sr = new StreamReader(equi1J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi1I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol31)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi1J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi1I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }

                            }

                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }
                program.gol31 = 0;
            }
        }

        public static void goleadoresEqui2()
        {
            Jugadores.equiposIdentificador();
            Jugadores.equiposJSelector();

            if (program.gol12 > 0)
            {
                using (StreamReader sr = new StreamReader(equi2J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi2I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol12)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi2J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi2I + ": ");
                            string goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (goleador == jugadores[0])
                                {

                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }
                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }
                program.gol12 = 0;
            }
            else if (program.gol22 > 0)
            {
                using (StreamReader sr = new StreamReader(equi2J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi2I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }


                int x = 0;
                while (x != program.gol22)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi2J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi2I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }
                program.gol22 = 0;
            }
            else if (program.gol32 > 0)
            {
                using (StreamReader sr = new StreamReader(equi2J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi2I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol32)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi2J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi2I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }

                            }

                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }               
                program.gol32 = 0;
            }
        }

        public static void goleadoresEqui3()
        {
            Jugadores.equiposIdentificador();
            Jugadores.equiposJSelector();

            if (program.gol13 > 0)
            {
                using (StreamReader sr = new StreamReader(equi3J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi3I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol13)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi3J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi3I + ": ");
                            string goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (goleador == jugadores[0])
                                {

                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }

                            }

                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }               
                program.gol13 = 0;
            }
            else if (program.gol23 > 0)
            {
                using (StreamReader sr = new StreamReader(equi3J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi3I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }
                int x = 0;
                while (x != program.gol23)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi3J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi3I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }

                            }

                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }               
                program.gol23 = 0;
            }
            else if (program.gol33 > 0)
            {
                using (StreamReader sr = new StreamReader(equi3J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi3I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol33)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi3J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi3I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }
                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }               
                program.gol33 = 0;
            }
        }

        public static void goleadoresEqui4()
        {
            Jugadores.equiposIdentificador();
            Jugadores.equiposJSelector();

            if (program.gol14 > 0)
            {
                using (StreamReader sr = new StreamReader(equi4J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi4I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol14)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi4J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi4I + ": ");
                            string goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (goleador == jugadores[0])
                                {

                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }
                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }                
                program.gol14 = 0;
            }
            else if (program.gol24 > 0)
            {
                using (StreamReader sr = new StreamReader(equi4J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi4I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }


                int x = 0;
                while (x != program.gol24)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi4J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi4I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }
                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }               
                program.gol24 = 0;
            }
            else if (program.gol34 > 0)
            {
                using (StreamReader sr = new StreamReader(equi4J))
                {
                    string line;

                    Console.WriteLine("\n" + "Jugadores de " + equi1I + "\n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] jugadores = line.Split('|');
                        Console.WriteLine(" " + "[" + jugadores[0] + "]" + "\t|  " + jugadores[1]);
                    }
                    Console.WriteLine("\n Ingrese el numero de DORSAL del jugador para indentificarlo\n");

                }

                int x = 0;
                while (x != program.gol34)
                {
                    int rep = 0;
                    while (rep == 0)
                    {
                        using (StreamReader sr = new StreamReader(equi4J))
                        {
                            string line;

                            Console.Write("Gol " + (x + 1) + " de " + equi4I + ": ");
                            String goleador = Console.ReadLine().ToString();

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] jugadores = line.Split('|');
                                if (jugadores[0] == goleador)
                                {
                                    NodoJugador nuevo = new NodoJugador();
                                    nuevo.Dorsal = jugadores[0];
                                    nuevo.Jugador = jugadores[1];
                                    nuevo.Goles++;
                                    nuevo.Fecha = jugadores[3];

                                    if (primero == null)
                                    {
                                        primero = nuevo;
                                        primero.Siguiente = null;
                                        ultimo = nuevo;
                                    }
                                    else
                                    {
                                        NodoJugador actual = new NodoJugador();
                                        actual = primero;
                                        int z = 0;
                                        while (actual != null)
                                        {
                                            if (actual.Jugador == nuevo.Jugador)
                                            {
                                                actual.Goles++;
                                                z++;
                                                break;
                                            }
                                            actual = actual.Siguiente;
                                        }
                                        if (z == 0)
                                        {
                                            ultimo.Siguiente = nuevo;
                                            nuevo.Siguiente = null;
                                            ultimo = nuevo;
                                        }

                                    }
                                    rep = 1;
                                    x++;
                                }
                            }
                        }
                        if (rep == 0)
                        {
                            Console.WriteLine("\t\tDorsal ingresado erroneo");
                        }
                    }
                }
                program.gol34 = 0;
            }
        }

        public static void tablaDeJugadores()
        {
            NodoJugador actual = new NodoJugador();
            actual = primero;

            List<NodoJugador> listJ = new List<NodoJugador>();

            while (actual != null)
            {
                listJ.Add(actual);
                actual = actual.Siguiente;
            }

            Console.WriteLine("\nTabla de posiciones goleadores");

            foreach (var dato in listJ.OrderByDescending(listJ => listJ.Goles))
            {
                DateTime fecha;
                fecha = DateTime.ParseExact(dato.Fecha, "dd/MM/yyyy", null);

                int diaNacimiento = fecha.Day;
                int mesNacimiento = fecha.Month;
                int añoNacimiento = fecha.Year;

                DateTime hoy = DateTime.Now;
                int diaActual = hoy.Day;
                int mesActual = hoy.Month;
                int añoActual = hoy.Year;

                int años;

                if(diaActual < diaNacimiento && mesActual <= mesNacimiento)
                {
                    años = (añoActual - añoNacimiento) - 1;
                }
                else
                {
                    años = añoActual - añoNacimiento;
                }
                Console.WriteLine("Goles: " + dato.Goles + "| " + "[" + dato.Dorsal + "] | " + dato.Jugador + "| Edad: " + años + " años");
            }
        }
    }
}
