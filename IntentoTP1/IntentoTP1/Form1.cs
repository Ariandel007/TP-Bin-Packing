using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntentoTP1
{
    public partial class Form1 : Form
    {
        PosicionEspacioLibre tabla;
        List<Elemento> elementos = new List<Elemento>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Lable4_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ButtonIniciarAlgoritmo_Click(object sender, EventArgs e)
        {


            DeterminarFactorDeEncaje algoritmo = new DeterminarFactorDeEncaje();


            ////Creando las lista de elementos:

            //Elemento elemento1 = new Elemento(26, 32);
            //Elemento elemento2 = new Elemento(13, 53);
            //Elemento elemento3 = new Elemento(63, 35);
            //Elemento elemento4 = new Elemento(47, 55);
            //Elemento elemento5 = new Elemento(300, 120);
            //Elemento elemento6 = new Elemento(123, 103);
            //Elemento elemento7 = new Elemento(45, 40);
            //Elemento elemento8 = new Elemento(54, 45);
            //Elemento elemento9 = new Elemento(34, 10);
            //Elemento elemento10 = new Elemento(30, 20);
            //Elemento elemento11 = new Elemento(30, 20);


            //elementos.Add(elemento1);
            //elementos.Add(elemento2);
            //elementos.Add(elemento3);
            //elementos.Add(elemento4);
            //elementos.Add(elemento5);
            //elementos.Add(elemento6);
            //elementos.Add(elemento7);
            //elementos.Add(elemento8);
            //elementos.Add(elemento9);
            //elementos.Add(elemento10);
            //elementos.Add(elemento11);

            //Lista de elementos que han sido empaquetados:
            List<Elemento> listaElementosEmpacados = new List<Elemento>();
            //Creando la lista posiciones

            List<PosicionEspacioLibre> lstposicionEspacioLibres = new List<PosicionEspacioLibre>();
            lstposicionEspacioLibres.Add(new PosicionEspacioLibre(tabla.largo, tabla.alto));

            //Lista de elementos empacados
            List<Elemento> elementosEmpacados = new List<Elemento>();



            ///ACA INICIA EL ALGORITMO:


            algoritmo.determinarFactorDeEncaje(elementos, lstposicionEspacioLibres.ElementAt(0));

            //ordenamiento descendente por factor de encaje
            //elementos = elementos.OrderByDescending(e => e.factorDeEncaje).ToList();

            //Hallar el elemento con menor altura:
            int alturaDelElementoMenosAlto = elementos.Min(el => el.alto);

            //ordenamiento descendente por factor de encaje, luego por area, luego por largo, luego por alto
            elementos = elementos.OrderByDescending(ef => ef.factorDeEncaje)
                .ThenByDescending(ea => ea.area)
                .ThenByDescending(ela => ela.largo)
                .ThenByDescending(eal => eal.alto)
                .ToList();

            //realizar mas ordenamientos de desempate: TODO


            //Quitar elementos mas grandes que la tabla

            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos.ElementAt(i).alto > tabla.alto || elementos.ElementAt(i).largo > tabla.largo)
                {
                    elementos.RemoveAt(i);
                    --i;
                }
            }


            while (elementos.Count > 0 && lstposicionEspacioLibres.Count > 0)
            {

                //comprobar que la posicion encaja y removar si no encaja, Si el elemento no encaja y la lista de posicones es igual a 1 terminar: TODO

                if (lstposicionEspacioLibres.ElementAt(0).largo < elementos.ElementAt(0).largo || lstposicionEspacioLibres.ElementAt(0).alto < elementos.ElementAt(0).alto)
                {
                    lstposicionEspacioLibres.RemoveAt(0);
                }

                if (lstposicionEspacioLibres.Count == 0)
                {
                    break;
                }
                //////////////////////////////////////////////////////////////////////////////



                elementos.ElementAt(0).x = lstposicionEspacioLibres.ElementAt(0).x;
                elementos.ElementAt(0).y = lstposicionEspacioLibres.ElementAt(0).y;

                //añadir a los elementos empacados
                elementosEmpacados.Add(elementos.ElementAt(0));

                //eliminar de la primera posicion de elementos:
                elementos.RemoveAt(0);

                //crear posicion :
                PosicionEspacioLibre posicionEspacioLibre2 = new PosicionEspacioLibre();

                //definir origen:
                posicionEspacioLibre2.x = elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).x;
                posicionEspacioLibre2.y = elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).y + elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).alto;

                ////

                posicionEspacioLibre2.alto = lstposicionEspacioLibres.ElementAt(0).alto - posicionEspacioLibre2.y;

                // posicionEspacioLibre2.largo = lstposicionEspacioLibres.ElementAt(0).largo - posicionEspacioLibre2.x;
                posicionEspacioLibre2.largo = tabla.largo - posicionEspacioLibre2.x;


                //crear otra posicion
                PosicionEspacioLibre posicionEspacioLibre1 = new PosicionEspacioLibre();

                //definir origen:
                posicionEspacioLibre1.x = elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).x + elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).largo;
                posicionEspacioLibre1.y = elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).y;
                //

                posicionEspacioLibre1.alto = elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).alto;

                //  posicionEspacioLibre1.largo = lstposicionEspacioLibres.ElementAt(0).largo - posicionEspacioLibre1.x;
                posicionEspacioLibre1.largo = tabla.largo - posicionEspacioLibre1.x;


                //quitar la ultima posicion(la posicion original)
                lstposicionEspacioLibres.RemoveAt(0);

                //si en posicion 2 el largo es menor que el elemento de menor alto
                if (posicionEspacioLibre2.alto < alturaDelElementoMenosAlto)
                {
                    posicionEspacioLibre1.alto += posicionEspacioLibre2.alto;
                    lstposicionEspacioLibres.Insert(0, posicionEspacioLibre1);

                }
                else//de lo contario insertar al final las dos posiciones
                {
                    lstposicionEspacioLibres.Insert(0, posicionEspacioLibre2);
                    lstposicionEspacioLibres.Insert(0, posicionEspacioLibre1);
                }
            }

            for (int i = 0; i < elementosEmpacados.Count; i++)
            {
                DibujarRectangulo(elementosEmpacados.ElementAt(i).x, elementosEmpacados.ElementAt(i).y,
                    elementosEmpacados.ElementAt(i).largo, elementosEmpacados.ElementAt(i).alto);

            }


        }

        public void DibujarRectangulo(int x, int y, int largo, int alto)
        {
            Graphics rectangulo;
            rectangulo = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.Red);
            //x,y,largo,altura
            rectangulo.DrawRectangle(lapiz, x, y, largo, alto);
        }

        private void BtnEstablecerPlancha_Click(object sender, EventArgs e)
        {
            int largo = int.Parse(txtbAnchoCuadro.Text);
            int alto = int.Parse(txtbAltoCuadro.Text);

            //Modificar tamaño  de picturebox
            Size size = new Size(largo, alto);
            pictureBox1.Size = size;

            //Definiendo la tabla
            tabla = new PosicionEspacioLibre(largo, alto);
            tabla.x = 0;
            tabla.y = 0;

            //
        }

        private void ButtonElementos_Click(object sender, EventArgs e)
        {
            int largo = int.Parse(txtbAnchoElemento.Text);
            int alto = int.Parse(txtbAltoElemento.Text);
            Elemento elemento = new Elemento(largo, alto);
            elementos.Add(elemento);
        }
    }
}