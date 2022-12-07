using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial4
{
    public class Selección
    {
        public Selección()
        { }

        public Selección(String equipo, int partidos, int ganado, int empatado, int perdido, int golF, int puntos)
        {
            this.Equipo = equipo;
            this.PJ = partidos;
            this.G = ganado;
            this.E = empatado;
            this.P = perdido;
            this.GF = golF;
            this.PTS = puntos;
        }

        public String Equipo { get; set; }
        public int PJ { get; set; }
        public int G { get; set; }
        public int E { get; set; }
        public int P { get; set; }
        public int GF { get; set; }
        public int PTS { get; set; }

    }
}
