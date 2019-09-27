using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentoTP1
{
    class Nodo
    {
        public Nodo nodoDerecho { get; set; }
        public Nodo nodoAbajo { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int largo { get; set; }
        public int alto { get; set; }
        public bool estaOcupado { get; set; }
    }
}