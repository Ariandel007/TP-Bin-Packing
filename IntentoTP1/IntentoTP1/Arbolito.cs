using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentoTP1
{
    class Arbolito
    {

        public List<Paquete> paquetes = new List<Paquete>();
        public Nodo nodoRaiz { get; set; }

        public Arbolito() { }

        public Nodo dividirNodo(Nodo node, int altoPaquete, int largoPaquete)
        {
           //amarcar como ocupado
            node.estaOcupado = true;

            //asignar coordenadas y dimensiones
            node.nodoAbajo = new Nodo { x = node.x, y = node.y + altoPaquete, largo = node.largo, alto = node.alto - altoPaquete };
            node.nodoDerecho = new Nodo { x = node.x + largoPaquete, y = node.y, largo = node.largo - largoPaquete, alto = altoPaquete };
            //node.nodoDerecho = new Nodo { x = node.x + largoPaquete, y = node.y, largo = node.largo - largoPaquete, alto = altoPaquete };


            return node;
        }

        public Nodo encontrarNodo(Nodo nodoRaiz, int altoPaquete, int largoPaquete)
        {
            if (nodoRaiz.estaOcupado)
            {
                var nodoSiguiente = encontrarNodo(nodoRaiz.nodoAbajo, altoPaquete, largoPaquete);

                //si en el espacio de abajo no se puede asignar ningun paquete entonces probara con el de la derecha
                if (nodoSiguiente == null)
                {
                    nodoSiguiente = encontrarNodo(nodoRaiz.nodoDerecho, altoPaquete, largoPaquete);
                }

                return nodoSiguiente;
            }
            //determinar si el elemento puede encajar
            else if (altoPaquete <= nodoRaiz.alto && largoPaquete <= nodoRaiz.largo)
            {
                return nodoRaiz;
            }
            else
            {
                return null;
            }
        }

        public void empacar()
        {
            //recorrer lista
            foreach (var paquete in paquetes)
            {
                //encontrar un nodo al cual se le pueda empaquetar
                var node = encontrarNodo(nodoRaiz, paquete.alto, paquete.largo);

                if (node != null)
                {
                    // dividir en subrectangulos
                    paquete.posicion = dividirNodo(node, paquete.alto, paquete.largo);
                }
            }
        }


    }
}
