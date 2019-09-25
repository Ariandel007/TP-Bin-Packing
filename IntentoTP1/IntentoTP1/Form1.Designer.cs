namespace IntentoTP1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbAnchoCuadro = new System.Windows.Forms.TextBox();
            this.txtbAltoCuadro = new System.Windows.Forms.TextBox();
            this.lable4 = new System.Windows.Forms.Label();
            this.buttonElementos = new System.Windows.Forms.Button();
            this.txtbAltoElemento = new System.Windows.Forms.TextBox();
            this.txtbAnchoElemento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEstablecerPlancha = new System.Windows.Forms.Button();
            this.buttonIniciarAlgoritmo = new System.Windows.Forms.Button();
            this.listBoxElementosAEmpacar = new System.Windows.Forms.ListBox();
            this.listBoxElementosEmpacados = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEspacioNoOcupado = new System.Windows.Forms.Label();
            this.btnAbrirTxt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1007, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuadro de Empaque";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1007, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Largo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1007, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Alto:";
            // 
            // txtbAnchoCuadro
            // 
            this.txtbAnchoCuadro.Location = new System.Drawing.Point(1070, 48);
            this.txtbAnchoCuadro.Name = "txtbAnchoCuadro";
            this.txtbAnchoCuadro.Size = new System.Drawing.Size(100, 20);
            this.txtbAnchoCuadro.TabIndex = 3;
            // 
            // txtbAltoCuadro
            // 
            this.txtbAltoCuadro.Location = new System.Drawing.Point(1070, 78);
            this.txtbAltoCuadro.Name = "txtbAltoCuadro";
            this.txtbAltoCuadro.Size = new System.Drawing.Size(100, 20);
            this.txtbAltoCuadro.TabIndex = 4;
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Location = new System.Drawing.Point(1007, 154);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(109, 13);
            this.lable4.TabIndex = 7;
            this.lable4.Text = "Elementos a empacar";
            this.lable4.Click += new System.EventHandler(this.Lable4_Click);
            // 
            // buttonElementos
            // 
            this.buttonElementos.Location = new System.Drawing.Point(1083, 232);
            this.buttonElementos.Name = "buttonElementos";
            this.buttonElementos.Size = new System.Drawing.Size(75, 23);
            this.buttonElementos.TabIndex = 12;
            this.buttonElementos.Text = "Empacar";
            this.buttonElementos.UseVisualStyleBackColor = true;
            this.buttonElementos.Click += new System.EventHandler(this.ButtonElementos_Click);
            // 
            // txtbAltoElemento
            // 
            this.txtbAltoElemento.Location = new System.Drawing.Point(1070, 206);
            this.txtbAltoElemento.Name = "txtbAltoElemento";
            this.txtbAltoElemento.Size = new System.Drawing.Size(100, 20);
            this.txtbAltoElemento.TabIndex = 11;
            // 
            // txtbAnchoElemento
            // 
            this.txtbAnchoElemento.Location = new System.Drawing.Point(1070, 180);
            this.txtbAnchoElemento.Name = "txtbAnchoElemento";
            this.txtbAnchoElemento.Size = new System.Drawing.Size(100, 20);
            this.txtbAnchoElemento.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1007, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Alto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1007, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ancho:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(12, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(310, 255);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnEstablecerPlancha
            // 
            this.btnEstablecerPlancha.Location = new System.Drawing.Point(1083, 104);
            this.btnEstablecerPlancha.Name = "btnEstablecerPlancha";
            this.btnEstablecerPlancha.Size = new System.Drawing.Size(87, 35);
            this.btnEstablecerPlancha.TabIndex = 14;
            this.btnEstablecerPlancha.Text = "Establecer Plancha";
            this.btnEstablecerPlancha.UseVisualStyleBackColor = true;
            this.btnEstablecerPlancha.Click += new System.EventHandler(this.BtnEstablecerPlancha_Click);
            // 
            // buttonIniciarAlgoritmo
            // 
            this.buttonIniciarAlgoritmo.BackColor = System.Drawing.Color.Lime;
            this.buttonIniciarAlgoritmo.Location = new System.Drawing.Point(1025, 348);
            this.buttonIniciarAlgoritmo.Name = "buttonIniciarAlgoritmo";
            this.buttonIniciarAlgoritmo.Size = new System.Drawing.Size(160, 75);
            this.buttonIniciarAlgoritmo.TabIndex = 15;
            this.buttonIniciarAlgoritmo.Text = "INICIAR PROCESO";
            this.buttonIniciarAlgoritmo.UseVisualStyleBackColor = false;
            this.buttonIniciarAlgoritmo.Click += new System.EventHandler(this.ButtonIniciarAlgoritmo_Click);
            // 
            // listBoxElementosAEmpacar
            // 
            this.listBoxElementosAEmpacar.FormattingEnabled = true;
            this.listBoxElementosAEmpacar.Location = new System.Drawing.Point(799, 51);
            this.listBoxElementosAEmpacar.Name = "listBoxElementosAEmpacar";
            this.listBoxElementosAEmpacar.Size = new System.Drawing.Size(154, 238);
            this.listBoxElementosAEmpacar.TabIndex = 16;
            // 
            // listBoxElementosEmpacados
            // 
            this.listBoxElementosEmpacados.FormattingEnabled = true;
            this.listBoxElementosEmpacados.Location = new System.Drawing.Point(802, 382);
            this.listBoxElementosEmpacados.Name = "listBoxElementosEmpacados";
            this.listBoxElementosEmpacados.Size = new System.Drawing.Size(151, 225);
            this.listBoxElementosEmpacados.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(799, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Elementos a empacar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(814, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Elementos empacados:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(1057, 588);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(128, 37);
            this.btnNuevo.TabIndex = 20;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(912, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Espacio en la plancha no ocupado:";
            // 
            // lblEspacioNoOcupado
            // 
            this.lblEspacioNoOcupado.AutoSize = true;
            this.lblEspacioNoOcupado.Location = new System.Drawing.Point(1080, 306);
            this.lblEspacioNoOcupado.Name = "lblEspacioNoOcupado";
            this.lblEspacioNoOcupado.Size = new System.Drawing.Size(33, 13);
            this.lblEspacioNoOcupado.TabIndex = 22;
            this.lblEspacioNoOcupado.Text = "100%";
            // 
            // btnAbrirTxt
            // 
            this.btnAbrirTxt.Location = new System.Drawing.Point(12, 12);
            this.btnAbrirTxt.Name = "btnAbrirTxt";
            this.btnAbrirTxt.Size = new System.Drawing.Size(148, 23);
            this.btnAbrirTxt.TabIndex = 23;
            this.btnAbrirTxt.Text = "Abrir un txt de elementos";
            this.btnAbrirTxt.UseVisualStyleBackColor = true;
            this.btnAbrirTxt.Click += new System.EventHandler(this.BtnAbrirTxt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 643);
            this.Controls.Add(this.btnAbrirTxt);
            this.Controls.Add(this.lblEspacioNoOcupado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBoxElementosEmpacados);
            this.Controls.Add(this.listBoxElementosAEmpacar);
            this.Controls.Add(this.buttonIniciarAlgoritmo);
            this.Controls.Add(this.btnEstablecerPlancha);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonElementos);
            this.Controls.Add(this.txtbAltoElemento);
            this.Controls.Add(this.txtbAnchoElemento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.txtbAltoCuadro);
            this.Controls.Add(this.txtbAnchoCuadro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbAnchoCuadro;
        private System.Windows.Forms.TextBox txtbAltoCuadro;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.Button buttonElementos;
        private System.Windows.Forms.TextBox txtbAltoElemento;
        private System.Windows.Forms.TextBox txtbAnchoElemento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEstablecerPlancha;
        private System.Windows.Forms.Button buttonIniciarAlgoritmo;
        private System.Windows.Forms.ListBox listBoxElementosAEmpacar;
        private System.Windows.Forms.ListBox listBoxElementosEmpacados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEspacioNoOcupado;
        private System.Windows.Forms.Button btnAbrirTxt;
    }
}

