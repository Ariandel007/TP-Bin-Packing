using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentoTP1
{
    class PosicionEspacioLibre : Rectangulo
    {
        public int x { get; set; }

        public int y { get; set; }

        public PosicionEspacioLibre()
        { }
        public PosicionEspacioLibre(int largo, int alto) : base(largo, alto)
        {
            this.largo = largo;
            this.alto = alto;
        }


    }
}
