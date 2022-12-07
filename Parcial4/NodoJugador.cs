using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial4
{
    public class NodoJugador
    {
        private NodoJugador siguiente;

        public NodoJugador()
        { }

        public NodoJugador(String dorsal, String jugador, int goles, String fecha_nac, NodoJugador siguiente)
        {
            this.Dorsal = dorsal;
            this.Jugador = jugador;
            this.Goles = goles;
            this.Fecha = fecha_nac;
            this.Siguiente = siguiente;
        }

        public String Jugador { get; set; }
        public String Dorsal { get; set; }
        public int Goles { get; set; }
        public String Fecha { get; set; }
        public NodoJugador Siguiente { get; set; }



    }
}
