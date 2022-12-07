using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial4
{
    public class Login
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

            foreach (Usuario usuario in lista)
            {
                if (usuario.Nombre == nombre && usuario.Password == password)
                {
                    result = true;
                    break;
                }
            }
            return result;

        }

    }
}
