namespace GraficoCSharp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtCadena = new System.Windows.Forms.TextBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.lblCadena = new System.Windows.Forms.Label();
            this.lblPosX = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numIniX = new System.Windows.Forms.NumericUpDown();
            this.numIniY = new System.Windows.Forms.NumericUpDown();
            this.numTamano = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numIniX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIniY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamano)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(23, 14);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(89, 30);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtCadena
            // 
            this.txtCadena.Location = new System.Drawing.Point(189, 14);
            this.txtCadena.Margin = new System.Windows.Forms.Padding(4);
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.Size = new System.Drawing.Size(1008, 23);
            this.txtCadena.TabIndex = 1;
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(23, 50);
            this.btnGraficar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(89, 30);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // lblCadena
            // 
            this.lblCadena.AutoSize = true;
            this.lblCadena.Location = new System.Drawing.Point(119, 14);
            this.lblCadena.Name = "lblCadena";
            this.lblCadena.Size = new System.Drawing.Size(62, 16);
            this.lblCadena.TabIndex = 3;
            this.lblCadena.Text = "Cadena:";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.Location = new System.Drawing.Point(119, 50);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(67, 16);
            this.lblPosX.TabIndex = 4;
            this.lblPosX.Text = "Inicio X: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(315, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Inicio Y: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tamaño Línea:";
            // 
            // numIniX
            // 
            this.numIniX.Location = new System.Drawing.Point(189, 50);
            this.numIniX.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numIniX.Name = "numIniX";
            this.numIniX.Size = new System.Drawing.Size(97, 23);
            this.numIniX.TabIndex = 10;
            this.numIniX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numIniX.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numIniY
            // 
            this.numIniY.Location = new System.Drawing.Point(387, 50);
            this.numIniY.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numIniY.Name = "numIniY";
            this.numIniY.Size = new System.Drawing.Size(97, 23);
            this.numIniY.TabIndex = 11;
            this.numIniY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numIniY.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // numTamano
            // 
            this.numTamano.Location = new System.Drawing.Point(634, 48);
            this.numTamano.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTamano.Name = "numTamano";
            this.numTamano.Size = new System.Drawing.Size(97, 23);
            this.numTamano.TabIndex = 12;
            this.numTamano.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTamano.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 611);
            this.Controls.Add(this.numTamano);
            this.Controls.Add(this.numIniY);
            this.Controls.Add(this.numIniX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPosX);
            this.Controls.Add(this.lblCadena);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.txtCadena);
            this.Controls.Add(this.btnGenerar);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Cadena que genera gráfico";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numIniX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIniY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtCadena;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Label lblCadena;
        private System.Windows.Forms.Label lblPosX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numIniX;
        private System.Windows.Forms.NumericUpDown numIniY;
        private System.Windows.Forms.NumericUpDown numTamano;
    }
}

