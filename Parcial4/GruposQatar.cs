using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial4
{
    public class GruposQatar
    {
        public static void gruposQatar()
        {
            using (StreamReader sr = new StreamReader("Grupos.txt"))
            {
                string line;

                Console.WriteLine("\n Grupos del mundial Qatar 2022 \n");
                while ((line = sr.ReadLine()) != null)
                {
                    string[] grupos = line.Split('|');
                    Console.WriteLine(grupos[0] + ": " + grupos[1] + " - " + grupos[2] + " - " + grupos[3] + " - " + grupos[4]);
                }

            }

        }

        public static void partidosQatar()
        {
            Selección equi1 = new Selección();
            Selección equi2 = new Selección();
            Selección equi3 = new Selección();
            Selección equi4 = new Selección();

            int rep = 0;

            while (rep == 0)
            {
                using (StreamReader sr = new StreamReader("Grupos.txt"))
                {
                    string line;

                    Console.WriteLine("Ingrese la letra mayuscula del grupo que desee visualizar los partidos (Ej: A, B, etc. )");
                    program.grupoPrueba = Console.ReadLine().ToString();

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] grupos = line.Split('|');

                        if (grupos[0] == program.grupoPrueba)
                        {
                            int valNum = 0;
                            
                            Console.WriteLine("\n Partidos del grupo " + program.grupoPrueba + "\n");

                            equi1.Equipo = grupos[1];
                            equi2.Equipo = grupos[2];
                            equi3.Equipo = grupos[3];
                            equi4.Equipo = grupos[4];

                            Console.WriteLine("Partido 1: " + grupos[1] + " vs " + grupos[2]);
                            Console.WriteLine("Ingrese el marcador de goles");                           
                            
                            while (valNum == 0)
                            {
                                Console.Write(grupos[1] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol11); //VALIDACIÓN DE NUMERO INT
                                if (result == true && program.gol11 >= 0)
                                {
                                    break;
                                }
                                else if(result == false || program.gol11<0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }
                            while (valNum == 0)
                            {
                                Console.Write(grupos[2] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol12);
                                if (result == true && program.gol12 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol12 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }

                            if (program.gol11 == program.gol12)
                            {
                                equi1.PTS++;
                                equi2.PTS++;

                                equi1.E++;
                                equi2.E++;

                                equi1.PJ++;
                                equi2.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui2();
                            }
                            else if (program.gol11 > program.gol12)
                            {
                                equi1.PTS = 3;
                                equi2.PTS = 0;

                                equi1.GF = program.gol11 - program.gol12;
                                equi2.GF = program.gol12 - program.gol11;

                                equi1.G++;
                                equi2.P++;

                                equi1.PJ++;
                                equi2.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui2();
                            }
                            else
                            {
                                equi1.PTS = 0;
                                equi2.PTS = 3;

                                equi1.GF = program.gol11 - program.gol12;
                                equi2.GF = program.gol12 - program.gol11;

                                equi1.P++;
                                equi2.G++;

                                equi1.PJ++;
                                equi2.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui2();
                            }
                            Console.WriteLine("\n");

                            Console.WriteLine("Partido 2: " + grupos[3] + " vs " + grupos[4]);
                            Console.WriteLine("Ingrese el marcador de goles");

                            while (valNum == 0)
                            {
                                Console.Write(grupos[3] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol13); //VALIDACIÓN DE NUMERO INT
                                if (result == true && program.gol13 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol13 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }
                            while (valNum == 0)
                            {
                                Console.Write(grupos[4] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol14);
                                if (result == true && program.gol14 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol14 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }

                            if (program.gol13 == program.gol14)
                            {
                                equi3.PTS++;
                                equi4.PTS++;

                                equi3.E++;
                                equi4.E++;

                                equi3.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui3();
                                Jugadores.goleadoresEqui4();
                            }
                            else if (program.gol13 > program.gol14)
                            {
                                equi3.PTS = 3;
                                equi4.PTS = 0;

                                equi3.GF = program.gol13 - program.gol14;
                                equi4.GF = program.gol14 - program.gol13;

                                equi3.G++;
                                equi4.P++;

                                equi3.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui3();
                                Jugadores.goleadoresEqui4();
                            }
                            else
                            {
                                equi3.PTS = 0;
                                equi4.PTS = 3;

                                equi3.GF = program.gol13 - program.gol14;
                                equi4.GF = program.gol14 - program.gol13;

                                equi3.P++;
                                equi4.G++;

                                equi3.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui3();
                                Jugadores.goleadoresEqui4();
                            }
                            Console.WriteLine("\n");

                            Console.WriteLine("Partido 3: " + grupos[1] + " vs " + grupos[3]);
                            Console.WriteLine("Ingrese el marcador de goles");

                            while (valNum == 0)
                            {
                                Console.Write(grupos[1] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol21); //VALIDACIÓN DE NUMERO INT
                                if (result == true && program.gol21 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol21 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }
                            while (valNum == 0)
                            {
                                Console.Write(grupos[3] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol23);
                                if (result == true && program.gol23 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol23 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }

                            if (program.gol21 == program.gol23)
                            {
                                equi1.PTS++;
                                equi3.PTS++;

                                equi1.E++;
                                equi3.E++;

                                equi1.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui3();
                            }
                            else if (program.gol21 > program.gol23)
                            {
                                equi1.PTS = equi1.PTS + 3;
                                equi3.PTS = equi3.PTS + 0;

                                equi1.GF = equi1.GF + (program.gol21 - program.gol23);
                                equi3.GF = equi3.GF + (program.gol23 - program.gol21);

                                equi1.G++;
                                equi3.P++;

                                equi1.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui3();
                            }
                            else if (program.gol21 < program.gol23)
                            {
                                equi1.PTS = equi1.PTS + 0;
                                equi3.PTS = equi3.PTS + 3;

                                equi1.GF = equi1.GF + (program.gol21 - program.gol23);
                                equi3.GF = equi3.GF + (program.gol23 - program.gol21);

                                equi1.P++;
                                equi3.G++;

                                equi1.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui3();
                            }
                            Console.WriteLine("\n");


                            Console.WriteLine("Partido 4: " + grupos[2] + " vs " + grupos[4]);
                            Console.WriteLine("Ingrese el marcador de goles");

                            while (valNum == 0)
                            {
                                Console.Write(grupos[2] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol22); //VALIDACIÓN DE NUMERO INT
                                if (result == true && program.gol22 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol22 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }
                            while (valNum == 0)
                            {
                                Console.Write(grupos[4] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol24);
                                if (result == true && program.gol24 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol24 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }

                            if (program.gol22 == program.gol24)
                            {
                                equi2.PTS++;
                                equi4.PTS++;

                                equi2.E++;
                                equi4.E++;

                                equi2.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui4();
                            }
                            else if (program.gol22 > program.gol24)
                            {
                                equi2.PTS = equi2.PTS + 3;
                                equi4.PTS = equi4.PTS + 0;

                                equi2.GF = equi2.GF + (program.gol22 - program.gol24);
                                equi4.GF = equi4.GF + (program.gol24 - program.gol22);

                                equi2.G++;
                                equi4.P++;

                                equi2.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui4();
                            }
                            else if (program.gol22 < program.gol24)
                            {
                                equi2.PTS = equi2.PTS + 0;
                                equi4.PTS = equi4.PTS + 3;

                                equi2.GF = equi2.GF + (program.gol22 - program.gol24);
                                equi4.GF = equi4.GF + (program.gol24 - program.gol22);

                                equi2.P++;
                                equi4.G++;

                                equi2.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui4();
                            }
                            Console.WriteLine("\n");

                            Console.WriteLine("Partido 5: " + grupos[1] + " vs " + grupos[4]);
                            Console.WriteLine("Ingrese el marcador de goles");

                            while (valNum == 0)
                            {
                                Console.Write(grupos[1] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol31); //VALIDACIÓN DE NUMERO INT
                                if (result == true && program.gol31 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol31 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }
                            while (valNum == 0)
                            {
                                Console.Write(grupos[4] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol34);
                                if (result == true && program.gol34 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol34 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }

                            if (program.gol31 == program.gol34)
                            {
                                equi1.PTS++;
                                equi4.PTS++;

                                equi1.E++;
                                equi4.E++;

                                equi1.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui4();

                            }
                            else if (program.gol31 > program.gol34)
                            {
                                equi1.PTS = equi1.PTS + 3;
                                equi4.PTS = equi4.PTS + 0;

                                equi1.GF = equi1.GF + (program.gol31 - program.gol34);
                                equi4.GF = equi4.GF + (program.gol34 - program.gol31);

                                equi1.G++;
                                equi4.P++;

                                equi1.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui4();
                            }
                            else if (program.gol31 < program.gol34)
                            {
                                equi1.PTS = equi1.PTS + 0;
                                equi4.PTS = equi4.PTS + 3;

                                equi1.GF = equi1.GF + (program.gol31 - program.gol34);
                                equi4.GF = equi4.GF + (program.gol34 - program.gol31);

                                equi1.P++;
                                equi4.G++;

                                equi1.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui4();
                            }
                            Console.WriteLine("\n");

                            Console.WriteLine("Partido 6: " + grupos[2] + " vs " + grupos[3]);
                            Console.WriteLine("Ingrese el marcador de goles");

                            while (valNum == 0)
                            {
                                Console.Write(grupos[2] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol32); //VALIDACIÓN DE NUMERO INT
                                if (result == true && program.gol32 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol32 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }
                            while (valNum == 0)
                            {
                                Console.Write(grupos[3] + " marcador:");
                                String gol = Console.ReadLine();
                                bool result = int.TryParse(gol, out program.gol33);
                                if (result == true && program.gol33 >= 0)
                                {
                                    break;
                                }
                                else if (result == false || program.gol33 < 0)
                                {
                                    Console.WriteLine("\t\t\tIngreso de valor erroneo");
                                    valNum = 0;
                                }
                            }

                            if (program.gol32 == program.gol33)
                            {
                                equi2.PTS++;
                                equi3.PTS++;

                                equi2.E++;
                                equi3.E++;

                                equi2.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui3();
                            }
                            else if (program.gol32 > program.gol33)
                            {
                                equi2.PTS = equi2.PTS + 3;
                                equi3.PTS = equi3.PTS + 0;

                                equi2.GF = equi2.GF + (program.gol32 - program.gol33);
                                equi3.GF = equi3.GF + (program.gol33 - program.gol32);

                                equi2.G++;
                                equi3.P++;

                                equi2.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui3();
                            }
                            else if (program.gol32 < program.gol33)
                            {
                                equi2.PTS = equi2.PTS + 0;
                                equi3.PTS = equi3.PTS + 3;

                                equi2.GF = equi2.GF + (program.gol32 - program.gol33);
                                equi3.GF = equi3.GF + (program.gol33 - program.gol32);

                                equi2.P++;
                                equi3.G++;

                                equi2.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui3();
                            }
                            Console.WriteLine("\n");
                            rep = 1;
                        }
                    }

                }
                if (rep == 0)
                {
                    Console.WriteLine("Ingreso equivocado, siga las indicaciones recomendadas");
                }
            }

            Console.WriteLine("\nResultados de Grupo " + program.grupoPrueba);
            Console.WriteLine("PJ|G|E|P|GD|PTS - Equipo" + "\n");

            List<Selección> list = new List<Selección>();
            list.Add(equi1);
            list.Add(equi2);
            list.Add(equi3);
            list.Add(equi4);

            foreach (var dato in list.OrderByDescending(list => list.PTS).ThenByDescending(list => list.GF))
            {
                Console.WriteLine(dato.PJ + "|" + dato.G + "|" + dato.E + "|" + dato.P + "|" + dato.GF + "|" + dato.PTS + " - " + dato.Equipo);
            }

            Jugadores.tablaDeJugadores();

        }
    }
}   
