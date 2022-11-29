using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace PruebasDeTxt 
{ 
    class program
    {
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

        

    }
}
