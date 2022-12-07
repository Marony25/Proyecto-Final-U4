using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial4
{
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
}
