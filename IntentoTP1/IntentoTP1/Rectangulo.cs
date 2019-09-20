using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentoTP1
{
    class Rectangulo
    {

        public int largo { get; set; }

        public int alto { get; set; }

        public int x { get; set; }

        public int y { get; set; }

        public Rectangulo() { }
        protected Rectangulo(int largo, int alto)
        {
            this.largo = largo;
            this.alto = alto;
        }

    }
}
