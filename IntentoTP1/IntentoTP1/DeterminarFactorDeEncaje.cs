using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentoTP1
{
    class DeterminarFactorDeEncaje
    {
        public void determinarFactorDeEncaje(List<Elemento> elementos, PosicionEspacioLibre posicionEspacioLibres)
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos.ElementAt(i).alto < posicionEspacioLibres.alto && elementos.ElementAt(i).largo < posicionEspacioLibres.largo)
                    elementos.ElementAt(i).factorDeEncaje++;

                if (elementos.ElementAt(i).largo == posicionEspacioLibres.largo)
                    elementos.ElementAt(i).factorDeEncaje++;

                if (elementos.ElementAt(i).alto == posicionEspacioLibres.alto)
                    elementos.ElementAt(i).factorDeEncaje++;

            }
        }
    }
}
