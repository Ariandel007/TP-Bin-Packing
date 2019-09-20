using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentoTP1
{
    class Elemento : Rectangulo
    {
        public int area { get; set; }
        public int factorDeEncaje { get; set; }

        public Elemento(int largo, int alto) : base(largo, alto)
        {
            this.largo = largo;
            this.alto = alto;
            this.area = largo * alto;
            this.factorDeEncaje = 0;
        }


    }
}
