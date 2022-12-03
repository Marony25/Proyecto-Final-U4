using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ExpTxt
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


        static void Main(String[] Args)
        {

            //Login
            Console.WriteLine("Ingrese sus credenciales");
            Console.Write("Usuario: ");
            String usuarioPrueba = Console.ReadLine().ToString();
            Console.Write("Contraseña: ");
            String contraseñaPrueba = Console.ReadLine().ToString();

            //Validar login

            if(UsuarioLoginHelper.Autenticar(usuarioPrueba, contraseñaPrueba))
            {
                Console.WriteLine("Acceso permitido");
            }

            GruposQatar.gruposQatar();
            Console.WriteLine("\n");
            GruposQatar.partidosQatar();

            //Creación de archivo de texto
            TextWriter archivo = new StreamWriter("archivo.txt");
            Console.WriteLine("Ingresar texto");
            String texto = Console.ReadLine().ToString();
            archivo.WriteLine(texto);   //Se guarda el texto con esto.
            archivo.Close();

            //lectura del archivo
            TextReader leer_archivo = new StreamReader("archivo.txt");
            Console.WriteLine(leer_archivo.ReadToEnd());
            leer_archivo.Close();


            //Prueba para parcial
            TextWriter archivo2 = new StreamWriter("Participantes.txt");
            archivo2.Close();
            ExampleAsync();

            System.Threading.Thread.Sleep(1000);

            //lectura del archivo
            TextReader leer_archivo2 = new StreamReader("Participantes.txt");
            Console.WriteLine(leer_archivo2.ReadToEnd());
            leer_archivo2.Close();


        }

        public static async Task ExampleAsync()
        {
            Console.WriteLine("Ingrese los equipos participantes del mundial\n");
            String[] lines = new String[32];
            for (int i = 0; i < 32; i++)
            {   
                Console.WriteLine("Ingrese el equipo "+(i+1));
                lines[i] = Console.ReadLine().ToString();
                Console.WriteLine("\n");
            }
            await File.WriteAllLinesAsync("Participantes.txt", lines);
        }

        public class Usuario
        {
            public Usuario(String nombre, String password)
            {
                this.Nombre = nombre;
                this.Password = password;
            }
            public String Nombre { get; set; }
            public String Password { get; set; }
        }

        public class UsuarioLoginHelper
        {
            public static List<Usuario> GetUsuarios()
            {
                List<Usuario> lista = new List<Usuario>();

                using (StreamReader sr = new StreamReader("Login.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] infousu = line.Split('|');
                        Usuario usu = new Usuario(infousu[0], infousu[1]);
                        lista.Add(usu);
                    }
                }
                return lista;
            }
            public static bool Autenticar(string nombre, string password)
            {
                bool result = false;

                List<Usuario> lista = GetUsuarios();

                foreach(Usuario usu in lista)
                {
                    if(usu.Nombre == nombre && usu.Password == password)
                    {
                        result = true;
                        break;
                    }
                }

                return result;

            }

        }

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
                        Console.WriteLine(grupos[0] +": "+ grupos[1] +" - "+ grupos[2]+" - " + grupos[3] + " - " + grupos[4]);
                    }

                }

            }

            public static void partidosQatar()
            {
                using (StreamReader sr = new StreamReader("Grupos.txt"))
                {
                    string line;

                    NodoJ equi1 = new NodoJ();
                    NodoJ equi2 = new NodoJ();
                    NodoJ equi3 = new NodoJ();
                    NodoJ equi4 = new NodoJ();

                    Console.WriteLine("Ingrese la letra mayuscula del grupo que desee visualizar los partidos (Ej: A, B, etc. )");
                    grupoPrueba = Console.ReadLine().ToString();

                    Console.WriteLine("\n Grupos del mundial Qatar 2022 \n");
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] grupos = line.Split('|');

                        if (grupos[0] == grupoPrueba)
                        {
                            equi1.Equipo = grupos[1];
                            equi2.Equipo = grupos[2];
                            equi3.Equipo = grupos[3];
                            equi4.Equipo = grupos[4];
                            
                            Console.WriteLine("Partido 1: " + grupos[1]+" vs " + grupos[2]);
                            Console.WriteLine("Ingrese el marcador de goles");
                            Console.Write(grupos[1]+" marcador:");
                            gol11 = int.Parse(Console.ReadLine());
                            Console.Write(grupos[2] + " marcador:");
                            gol12 = int.Parse(Console.ReadLine());
                            if(gol11 == gol12)
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
                            else if (gol11 > gol12)
                            {
                                equi1.PTS = 3;
                                equi2.PTS = 0;
                                
                                equi1.GF = gol11 - gol12;
                                equi2.GF = gol12 - gol11;
                                
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

                                equi1.GF = gol11 - gol12;
                                equi2.GF = gol12 - gol11;

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
                            Console.Write(grupos[3] + " marcador:");
                            gol13 = int.Parse(Console.ReadLine());
                            Console.Write(grupos[4] + " marcador:");
                            gol14 = int.Parse(Console.ReadLine());
                            if (gol13 == gol14)
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
                            else if (gol13 > gol14)
                            {
                                equi3.PTS = 3;
                                equi4.PTS = 0;

                                equi3.GF = gol13 - gol14;
                                equi4.GF = gol14 - gol13;

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

                                equi3.GF = gol13 - gol14;
                                equi4.GF = gol14 - gol13;

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
                            Console.Write(grupos[1] + " marcador:");
                            gol21 = int.Parse(Console.ReadLine());
                            Console.Write(grupos[3] + " marcador:");
                            gol23 = int.Parse(Console.ReadLine());
                            if (gol21 == gol23)
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
                            else if (gol21 > gol23)
                            {
                                equi1.PTS = equi1.PTS + 3;
                                equi3.PTS = equi3.PTS + 0;

                                equi1.GF = equi1.GF + (gol21 - gol23);
                                equi3.GF = equi3.GF +(gol23 - gol21);

                                equi1.G++;
                                equi3.P++;

                                equi1.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui3();
                            }
                            else if (gol21 < gol23)
                            {
                                equi1.PTS = equi1.PTS + 0;
                                equi3.PTS = equi3.PTS + 3;

                                equi1.GF = equi1.GF + (gol21 - gol23);
                                equi3.GF = equi3.GF + (gol23 - gol21);

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
                            Console.Write(grupos[2] + " marcador:");
                            gol22 = int.Parse(Console.ReadLine());
                            Console.Write(grupos[4] + " marcador:");
                            gol24 = int.Parse(Console.ReadLine());
                            if (gol22 == gol24)
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
                            else if (gol22 > gol24)
                            {
                                equi2.PTS = equi2.PTS + 3;
                                equi4.PTS = equi4.PTS + 0;

                                equi2.GF = equi2.GF + (gol22 - gol24);
                                equi4.GF = equi4.GF + (gol24 - gol22);

                                equi2.G++;
                                equi4.P++;

                                equi2.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui4();
                            }
                            else if (gol22 < gol24)
                            {
                                equi2.PTS = equi2.PTS + 0;
                                equi4.PTS = equi4.PTS + 3;

                                equi2.GF = equi2.GF + (gol22 - gol24);
                                equi4.GF = equi4.GF + (gol24 - gol22);

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
                            Console.Write(grupos[1] + " marcador:");
                            gol31 = int.Parse(Console.ReadLine());
                            Console.Write(grupos[4] + " marcador:");
                            gol34 = int.Parse(Console.ReadLine());
                            if (gol31 == gol34)
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
                            else if (gol31 > gol34)
                            {
                                equi1.PTS = equi1.PTS + 3;
                                equi4.PTS = equi4.PTS + 0;

                                equi1.GF = equi1.GF + (gol31 - gol34);
                                equi4.GF = equi4.GF + (gol34 - gol31);

                                equi1.G++;
                                equi4.P++;

                                equi1.PJ++;
                                equi4.PJ++;

                                Jugadores.goleadoresEqui1();
                                Jugadores.goleadoresEqui4();
                            }
                            else if (gol31 < gol34)
                            {
                                equi1.PTS = equi1.PTS + 0;
                                equi4.PTS = equi4.PTS + 3;

                                equi1.GF = equi1.GF + (gol31 - gol34);
                                equi4.GF = equi4.GF + (gol34 - gol31);

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
                            Console.Write(grupos[2] + " marcador:");
                            gol32 = int.Parse(Console.ReadLine());
                            Console.Write(grupos[3] + " marcador:");
                            gol33 = int.Parse(Console.ReadLine());
                            if (gol32 == gol33)
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
                            else if (gol32 > gol33)
                            {
                                equi2.PTS = equi2.PTS + 3;
                                equi3.PTS = equi3.PTS + 0;

                                equi2.GF = equi2.GF + (gol32 - gol33);
                                equi3.GF = equi3.GF + (gol33 - gol32);

                                equi2.G++;
                                equi3.P++;

                                equi2.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui3();
                            }
                            else if (gol32 < gol33)
                            {
                                equi2.PTS = equi2.PTS + 0;
                                equi3.PTS = equi3.PTS + 3;

                                equi2.GF = equi2.GF + (gol32 - gol33);
                                equi3.GF = equi3.GF + (gol33 - gol32);

                                equi2.P++;
                                equi3.G++;

                                equi2.PJ++;
                                equi3.PJ++;

                                Jugadores.goleadoresEqui2();
                                Jugadores.goleadoresEqui3();
                            }
                            Console.WriteLine("\n");
                        }

                    }

                    Console.WriteLine("Resultados (Equipo|PJ|G|E|P|GD|PTS)");

                    List<NodoJ> list = new List<NodoJ>();
                    list.Add(equi1);
                    list.Add(equi2);
                    list.Add(equi3);
                    list.Add(equi4);

                    list.OrderBy(list => list.PTS);

                    foreach (var dato in list.OrderByDescending(list => list.PTS).ThenByDescending(list => list.GF))
                    {
                        Console.WriteLine(dato.Equipo +"\t"+ "|" + dato.PJ + "|" + dato.G + "|" + dato.E + "|" + dato.P + "|" + dato.GF + "|" + dato.PTS);
                    }

                    Jugadores.tablaDeJugadores();

                }

            }

        }

        

    }
}
