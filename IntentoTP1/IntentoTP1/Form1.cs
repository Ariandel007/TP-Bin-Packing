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

        //lista de paquetes, para el algoeritmo guillotina
        List<Paquete> paquetes = new List<Paquete>();


        bool estadoNivel = true;

        bool terminar = false;

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
            if (lstposicionEspacioLibres.Count == 0)
            {
                return;
            }


            if (lstposicionEspacioLibres.First.Value.largo < elementos.First.Value.largo)
            {
                lstposicionEspacioLibres.RemoveFirst();
                estadoNivel = true;
                ComprobarEspaciosLibres(lstposicionEspacioLibres);
            }

        }

        private void ButtonIniciarAlgoritmo_Click(object sender, EventArgs e)
        {


            ////Creando las lista de elementos:
            LinkedList<PosicionEspacioLibre> lstposicionEspacioLibres = new LinkedList<PosicionEspacioLibre>();

            lstposicionEspacioLibres.AddLast(new PosicionEspacioLibre(plancha.largo, plancha.alto));

            //ordenador de mayor a menor por alto
            elementos = new LinkedList<Elemento>(elementos.OrderByDescending(ef => ef.factorDeEncaje)
                .ThenByDescending(ea => ea.alto)
                .ToList());
            //realizar mas ordenamientos de desempate: TODO


            //Quitar elementos mas grandes que la plancha

            foreach (var ele in elementos)
            {
                if (ele.alto > plancha.alto || ele.largo > plancha.largo)
                {
                    elementos.Remove(ele);
                }
            }

            //elemento nuevo nivel
            Elemento primerElementoUltimoNuevoNivel = new Elemento(0, 0);

            while (elementos.Count > 0 && lstposicionEspacioLibres.Count > 0)
            {

                this.ComprobarEspaciosLibres(lstposicionEspacioLibres);

                //añadir elemento de primer nivel
                if (estadoNivel == true)
                {
                    primerElementoUltimoNuevoNivel = elementos.First.Value;
                    estadoNivel = false;
                }



                elementos.First.Value.x = lstposicionEspacioLibres.First.Value.x;
                elementos.First.Value.y = lstposicionEspacioLibres.First.Value.y;

                //añadir a los elementos empacados
                elementosEmpacados.AddLast(elementos.First.Value);



                //eliminar de la primera posicion de elementos:
                elementos.RemoveFirst();

                //crear otra posicion y definir posiciones
                PosicionEspacioLibre posicionEspacioLibre2 = new PosicionEspacioLibre() { x = 0,
                    y = primerElementoUltimoNuevoNivel.y + primerElementoUltimoNuevoNivel.alto,
                    alto = plancha.alto - (primerElementoUltimoNuevoNivel.alto + primerElementoUltimoNuevoNivel.y),
                    largo = plancha.largo
                };

                //crear otra posicion y definir posiciones
                PosicionEspacioLibre posicionEspacioLibre1 = new PosicionEspacioLibre(){
                    x = elementosEmpacados.Last.Value.x + elementosEmpacados.Last.Value.largo,
                    y = primerElementoUltimoNuevoNivel.y,
                    alto = primerElementoUltimoNuevoNivel.alto,
                   // largo = plancha.largo - x
                };
                posicionEspacioLibre1.largo = plancha.largo - posicionEspacioLibre1.x;


                lstposicionEspacioLibres.RemoveFirst();

                lstposicionEspacioLibres.AddFirst(posicionEspacioLibre2);
                lstposicionEspacioLibres.AddFirst(posicionEspacioLibre1);
            }


            int sumaAreaElementosEmpacados = 0;

            int c = 0;
            foreach (var ele in elementosEmpacados)
            {
                //Dibujar los rectangulos:
                DibujarRectangulo(ele.x, ele.y, ele.largo, ele.alto);
                //Mostrando en el listView
                listBoxElementosEmpacados.Items.Add("Elemento:" + (c + 1) + ":" + "Largo: " + ele.largo +"Alto: " + ele.alto);
                //calcular el area de elementos empaquetados:
                sumaAreaElementosEmpacados += ele.area;
                c++;
            }

            lblEspacioNoOcupado.Text = (((plancha.alto * plancha.largo) - sumaAreaElementosEmpacados) * 100 / (plancha.alto * plancha.largo)).ToString() + "%";

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

            listBoxElementosAEmpacar.Items.Add("Elemento:" + elementos.Count + "Largo: " + elementos.ElementAt(elementos.Count - 1).largo + " Alto:" + elementos.ElementAt(elementos.Count - 1).alto);


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

                        Paquete paquete = new Paquete() { largo = largo, alto = alto };
                        paquetes.Add(paquete);

                        listBoxElementosAEmpacar.Items.Add("Elemento:" + elementos.Count + "Largo: " + elementos.ElementAt(elementos.Count - 1).largo + " Alto:" + elementos.ElementAt(elementos.Count - 1).alto);

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void BtnIniicarGuillotina_Click(object sender, EventArgs e)
        {
            Arbolito arbolito = new Arbolito();

            arbolito.paquetes = paquetes;

            // ordernar de manera descendente segun el volumen
            arbolito.paquetes.ForEach(x => x.volumen = (x.alto * x.largo));
            arbolito.paquetes = arbolito.paquetes.OrderByDescending(x => x.volumen).ToList();

            // inicilizar el nodo raiz con el tamaño de la plancha

            arbolito.nodoRaiz = new Nodo { alto = plancha.alto, largo = plancha.largo };

            arbolito.empacar();

            int sumaAreaElementosEmpacados = 0;


            //mostrar paquetes
            int c = 0;
            foreach (var paquete in arbolito.paquetes)
            {
                //Dibujar los rectangulos:
                if (paquete.posicion != null)
                {
                    DibujarRectangulo(paquete.posicion.x, paquete.posicion.y, paquete.largo, paquete.alto);
                    sumaAreaElementosEmpacados += (paquete.alto * paquete.largo);
                    //Mostrando en el listView
                    listBoxElementosEmpacados.Items.Add("Elementos: "+(c+1)+" Largo: " + paquete.largo + "Alto: " + paquete.posicion);
                    c++;
                }
                
            }

            lblEspacioNoOcupado.Text = (((plancha.alto * plancha.largo) - sumaAreaElementosEmpacados) * 100 / (plancha.alto * plancha.largo)).ToString() + "%";

        }

    }
}