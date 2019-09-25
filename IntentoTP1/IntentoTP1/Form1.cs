using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntentoTP1
{
    public partial class Form1 : Form
    {
        PosicionEspacioLibre plancha;
        LinkedList<Elemento> elementos = new LinkedList<Elemento>();

        //Lista de elementos empacados
        LinkedList<Elemento> elementosEmpacados = new LinkedList<Elemento>();

        bool estadoNivel = false;


        string[] lines;


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

        private void ComprobarEspaciosLibres(LinkedList<PosicionEspacioLibre> lstposicionEspacioLibres)
        {
            if (lstposicionEspacioLibres.Count==0)
            {
                return;
            }

            else if (lstposicionEspacioLibres.First.Value.largo < elementos.First.Value.largo || lstposicionEspacioLibres.First.Value.alto < elementos.First.Value.alto)
            {
                lstposicionEspacioLibres.RemoveFirst();
                estadoNivel = true;
                ComprobarEspaciosLibres(lstposicionEspacioLibres);
            }
        }

        private void ButtonIniciarAlgoritmo_Click(object sender, EventArgs e)
        {


            DeterminarFactorDeEncaje algoritmo = new DeterminarFactorDeEncaje();


            ////Creando las lista de elementos:
            LinkedList<PosicionEspacioLibre> lstposicionEspacioLibres = new LinkedList<PosicionEspacioLibre>();

            lstposicionEspacioLibres.AddLast(new PosicionEspacioLibre(plancha.largo, plancha.alto));


            ///ACA INICIA EL ALGORITMO:

            algoritmo.determinarFactorDeEncaje(elementos, lstposicionEspacioLibres.First.Value);

            //ordenamiento descendente por factor de encaje
            //elementos = elementos.OrderByDescending(e => e.factorDeEncaje).ToList();


            //ordenamiento descendente por factor de encaje, luego por area, luego por largo, luego por alto
            //elementos = elementos.OrderByDescending(ef => ef.factorDeEncaje)
            //    .ThenByDescending(ea => ea.area)
            //    .ThenByDescending(ela => ela.largo)
            //    .ThenByDescending(eal => eal.alto)
            //    .ToList();

            //si lo hacemos por alto se vuelve un algortimo shelf
            elementos = new LinkedList<Elemento>(elementos.OrderByDescending(ef => ef.alto).ToList());
            //realizar mas ordenamientos de desempate: TODO


            //Quitar elementos mas grandes que la plancha

            for (int i = 0; i < elementos.Count; i++)
            {
                if (elementos.ElementAt(i).alto > plancha.alto || elementos.ElementAt(i).largo > plancha.largo)
                {
                    elementos.Remove(elementos.ElementAt(i));
                    --i;
                }
            }

            //Hallar el elemento con menor altura:
            int alturaDelElementoMenosAlto = elementos.Min(el => el.alto);

            //elemento nuevo nivel
            Elemento elementoUltimoNuevoNivel=new Elemento(0,0);

            while (elementos.Count > 0)
            {
                if(elementos.Count==1)
                {
                    MessageBox.Show("excelente");
                }

                this.ComprobarEspaciosLibres(lstposicionEspacioLibres);

                //añadir a  elemento nuevo nivel

                // si se eliminaron los espacios
                if (lstposicionEspacioLibres.Count == 0 && elementos.Count > 0)
                {
                    PosicionEspacioLibre posicionEspacioLibreExtra = new PosicionEspacioLibre();
//                    posicionEspacioLibreExtra.x = elementoUltimoNuevoNivel.x;
                    posicionEspacioLibreExtra.x = 0;
                    posicionEspacioLibreExtra.y = elementoUltimoNuevoNivel.y + elementoUltimoNuevoNivel.alto;
                    posicionEspacioLibreExtra.largo = plancha.largo;
                    posicionEspacioLibreExtra.alto = plancha.alto - (posicionEspacioLibreExtra.y);
                    lstposicionEspacioLibres.AddLast(posicionEspacioLibreExtra);
                }

                if (estadoNivel == true)
                {
                    elementoUltimoNuevoNivel = elementos.First.Value;
                    // elementoUltimoNuevoNivel.x = 0;
                    estadoNivel = false;
                }



                elementos.First.Value.x = lstposicionEspacioLibres.First.Value.x;
                elementos.First.Value.y = lstposicionEspacioLibres.First.Value.y;

                //añadir a los elementos empacados
                elementosEmpacados.AddLast(elementos.ElementAt(0));



                //eliminar de la primera posicion de elementos:
                elementos.RemoveFirst();

                //crear posicion :
                PosicionEspacioLibre posicionEspacioLibre2 = new PosicionEspacioLibre();

                //definir origen:
                posicionEspacioLibre2.x = elementosEmpacados.Last.Value.x;
                posicionEspacioLibre2.y = elementosEmpacados.Last.Value.y + elementosEmpacados.Last.Value.alto;


                if (lstposicionEspacioLibres.First.Value.alto< posicionEspacioLibre2.y)
                {
                    lstposicionEspacioLibres.RemoveFirst();
                }


                ////////////////////////////////////////////////////
                if (lstposicionEspacioLibres.Count == 0 && elementos.Count > 0)
                {
                    PosicionEspacioLibre posicionEspacioLibreExtra = new PosicionEspacioLibre();
                    posicionEspacioLibreExtra.x = elementoUltimoNuevoNivel.x;
                    posicionEspacioLibreExtra.y = elementoUltimoNuevoNivel.y + elementoUltimoNuevoNivel.alto;
                    posicionEspacioLibreExtra.largo = plancha.largo;
                    posicionEspacioLibreExtra.alto = plancha.alto - (posicionEspacioLibreExtra.y);
                    lstposicionEspacioLibres.AddLast(posicionEspacioLibreExtra);

                }

                //si salio negativa la altura
                if (lstposicionEspacioLibres.First.Value.alto < posicionEspacioLibre2.y)
                {
                    lstposicionEspacioLibres.RemoveFirst();
                }

                //si se eliminaron los espacios disponibles pero aun quedan elementos
                if (lstposicionEspacioLibres.Count == 0 && elementos.Count > 0)
                {
                    PosicionEspacioLibre posicionEspacioLibreExtra = new PosicionEspacioLibre();
                    posicionEspacioLibreExtra.x = elementoUltimoNuevoNivel.x;
                    posicionEspacioLibreExtra.y = elementoUltimoNuevoNivel.y + elementoUltimoNuevoNivel.alto;
                    posicionEspacioLibreExtra.largo = plancha.largo;
                    posicionEspacioLibreExtra.alto = plancha.alto - (posicionEspacioLibreExtra.y);
                    lstposicionEspacioLibres.AddLast(posicionEspacioLibreExtra);
                }

                //si es emnor a lo que queda
                if (lstposicionEspacioLibres.Count==0||lstposicionEspacioLibres.Last.Value.alto < alturaDelElementoMenosAlto)
                    break;

                posicionEspacioLibre2.alto = lstposicionEspacioLibres.First.Value.alto - posicionEspacioLibre2.y;

                posicionEspacioLibre2.largo = plancha.largo - posicionEspacioLibre2.x;


                //crear otra posicion
                PosicionEspacioLibre posicionEspacioLibre1 = new PosicionEspacioLibre();

                //definir origen:
                posicionEspacioLibre1.x = elementosEmpacados.Last.Value.x + elementosEmpacados.Last.Value.largo;
                posicionEspacioLibre1.y = elementosEmpacados.Last.Value.y;
                //

                posicionEspacioLibre1.alto = elementosEmpacados.ElementAt(elementosEmpacados.Count - 1).alto;

                posicionEspacioLibre1.largo = plancha.largo - posicionEspacioLibre1.x;


                lstposicionEspacioLibres.RemoveFirst();

                lstposicionEspacioLibres.AddFirst(posicionEspacioLibre2);
                lstposicionEspacioLibres.AddFirst(posicionEspacioLibre1);
            }


            int sumaAreaElementosEmpacados=0;

            for (int i = 0; i < elementosEmpacados.Count; i++)
            {
                //Dibujar los rectangulos:
                DibujarRectangulo(elementosEmpacados.ElementAt(i).x, elementosEmpacados.ElementAt(i).y,
                    elementosEmpacados.ElementAt(i).largo, elementosEmpacados.ElementAt(i).alto);

                //Mostrando en el listView
                listBoxElementosEmpacados.Items.Add("Elemento:" + (i + 1) + ":" + "Largo: " + elementosEmpacados.ElementAt(i).largo +
                    "Alto: " + elementosEmpacados.ElementAt(i).alto);

                //calcular el area de elementos empaquetados:
                sumaAreaElementosEmpacados += elementosEmpacados.ElementAt(i).area;
            }

            lblEspacioNoOcupado.Text = (((plancha.alto * plancha.largo) - sumaAreaElementosEmpacados)*100/ (plancha.alto * plancha.largo)).ToString()+"%";

        }

        public void DibujarRectangulo(int x, int y, int largo, int alto)
        {
            Graphics rectangulo;
            rectangulo = pictureBox1.CreateGraphics();
            Pen lapiz = new Pen(Color.DarkBlue);
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

            //Definiendo la plancha
            plancha = new PosicionEspacioLibre(largo, alto);
            plancha.x = 0;
            plancha.y = 0;
            //
        }

        private void ButtonElementos_Click(object sender, EventArgs e)
        {
            int largo = int.Parse(txtbAnchoElemento.Text);
            int alto = int.Parse(txtbAltoElemento.Text);
            Elemento elemento = new Elemento(largo, alto);
            elementos.AddLast(elemento);

            listBoxElementosAEmpacar.Items.Add("Elemento:"+ elementos.Count + "Largo: "+elementos.ElementAt(elementos.Count-1).largo+" Alto:"+elementos.ElementAt(elementos.Count - 1).alto);


        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void BtnAbrirTxt_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "e:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //obtener el path del archivo especificado
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                         lines = System.IO.File.ReadAllLines(@filePath);
                    }
                }
            }
            try
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] split = lines[i].Split(new Char[] { ' ' });

                    if (i == 0)
                    {
                        int largo = int.Parse(split[0]);
                        int alto = int.Parse(split[1]);

                        //Modificar tamaño  de picturebox
                        Size size = new Size(largo, alto);
                        pictureBox1.Size = size;

                        //Definiendo la plancha
                        plancha = new PosicionEspacioLibre(largo, alto);
                        plancha.x = 0;
                        plancha.y = 0;
                        //
                    }
                    else
                    {
                        int largo = int.Parse(split[0]);
                        int alto = int.Parse(split[1]);
                        Elemento elemento = new Elemento(largo, alto);
                        elementos.AddLast(elemento);

                        listBoxElementosAEmpacar.Items.Add("Elemento:" + elementos.Count + "Largo: " + elementos.ElementAt(elementos.Count - 1).largo + " Alto:" + elementos.ElementAt(elementos.Count - 1).alto);

                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}