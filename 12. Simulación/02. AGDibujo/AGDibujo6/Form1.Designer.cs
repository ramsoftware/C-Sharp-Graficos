namespace AGDibujo {
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
            this.lblMejor = new System.Windows.Forms.Label();
            this.lblCiclos = new System.Windows.Forms.Label();
            this.lblPoblacion = new System.Windows.Forms.Label();
            this.txtMejor = new System.Windows.Forms.TextBox();
            this.btnGenetico = new System.Windows.Forms.Button();
            this.dgDibujo = new System.Windows.Forms.DataGridView();
            this.c1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMejor = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTamGenotipo = new System.Windows.Forms.Label();
            this.numPoblacion = new System.Windows.Forms.NumericUpDown();
            this.numCiclos = new System.Windows.Forms.NumericUpDown();
            this.numTamGenotipo = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblManual = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDibujo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMejor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoblacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCiclos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamGenotipo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMejor
            // 
            this.lblMejor.AutoSize = true;
            this.lblMejor.Location = new System.Drawing.Point(495, 169);
            this.lblMejor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMejor.Name = "lblMejor";
            this.lblMejor.Size = new System.Drawing.Size(204, 16);
            this.lblMejor.TabIndex = 23;
            this.lblMejor.Text = "Mejor individuo hallado al final";
            // 
            // lblCiclos
            // 
            this.lblCiclos.AutoSize = true;
            this.lblCiclos.Location = new System.Drawing.Point(495, 50);
            this.lblCiclos.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCiclos.Name = "lblCiclos";
            this.lblCiclos.Size = new System.Drawing.Size(143, 16);
            this.lblCiclos.TabIndex = 21;
            this.lblCiclos.Text = "Ciclos de generación";
            // 
            // lblPoblacion
            // 
            this.lblPoblacion.AutoSize = true;
            this.lblPoblacion.Location = new System.Drawing.Point(495, 16);
            this.lblPoblacion.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPoblacion.Name = "lblPoblacion";
            this.lblPoblacion.Size = new System.Drawing.Size(124, 16);
            this.lblPoblacion.TabIndex = 20;
            this.lblPoblacion.Text = "Tamaño Población";
            // 
            // txtMejor
            // 
            this.txtMejor.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMejor.Location = new System.Drawing.Point(501, 190);
            this.txtMejor.Margin = new System.Windows.Forms.Padding(5);
            this.txtMejor.Multiline = true;
            this.txtMejor.Name = "txtMejor";
            this.txtMejor.ReadOnly = true;
            this.txtMejor.Size = new System.Drawing.Size(493, 164);
            this.txtMejor.TabIndex = 19;
            // 
            // btnGenetico
            // 
            this.btnGenetico.Location = new System.Drawing.Point(493, 113);
            this.btnGenetico.Margin = new System.Windows.Forms.Padding(5);
            this.btnGenetico.Name = "btnGenetico";
            this.btnGenetico.Size = new System.Drawing.Size(219, 42);
            this.btnGenetico.TabIndex = 18;
            this.btnGenetico.Text = "Ejecutar algoritmo genético";
            this.btnGenetico.UseVisualStyleBackColor = true;
            this.btnGenetico.Click += new System.EventHandler(this.btnGenetico_Click);
            // 
            // dgDibujo
            // 
            this.dgDibujo.AllowUserToResizeColumns = false;
            this.dgDibujo.AllowUserToResizeRows = false;
            this.dgDibujo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDibujo.ColumnHeadersVisible = false;
            this.dgDibujo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.c6,
            this.c7,
            this.c8,
            this.c9,
            this.c10});
            this.dgDibujo.Location = new System.Drawing.Point(17, 37);
            this.dgDibujo.Margin = new System.Windows.Forms.Padding(5);
            this.dgDibujo.MultiSelect = false;
            this.dgDibujo.Name = "dgDibujo";
            this.dgDibujo.ReadOnly = true;
            this.dgDibujo.RowHeadersVisible = false;
            this.dgDibujo.Size = new System.Drawing.Size(229, 317);
            this.dgDibujo.TabIndex = 17;
            this.dgDibujo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDibujo_CellClick);
            // 
            // c1
            // 
            this.c1.HeaderText = "";
            this.c1.MinimumWidth = 2;
            this.c1.Name = "c1";
            this.c1.ReadOnly = true;
            this.c1.Width = 20;
            // 
            // c2
            // 
            this.c2.FillWeight = 20F;
            this.c2.HeaderText = "";
            this.c2.Name = "c2";
            this.c2.ReadOnly = true;
            this.c2.Width = 20;
            // 
            // c3
            // 
            this.c3.HeaderText = "";
            this.c3.Name = "c3";
            this.c3.ReadOnly = true;
            this.c3.Width = 20;
            // 
            // c4
            // 
            this.c4.HeaderText = "";
            this.c4.Name = "c4";
            this.c4.ReadOnly = true;
            this.c4.Width = 20;
            // 
            // c5
            // 
            this.c5.HeaderText = "";
            this.c5.Name = "c5";
            this.c5.ReadOnly = true;
            this.c5.Width = 20;
            // 
            // c6
            // 
            this.c6.HeaderText = "";
            this.c6.Name = "c6";
            this.c6.ReadOnly = true;
            this.c6.Width = 20;
            // 
            // c7
            // 
            this.c7.HeaderText = "";
            this.c7.Name = "c7";
            this.c7.ReadOnly = true;
            this.c7.Width = 20;
            // 
            // c8
            // 
            this.c8.HeaderText = "";
            this.c8.Name = "c8";
            this.c8.ReadOnly = true;
            this.c8.Width = 20;
            // 
            // c9
            // 
            this.c9.HeaderText = "";
            this.c9.Name = "c9";
            this.c9.ReadOnly = true;
            this.c9.Width = 20;
            // 
            // c10
            // 
            this.c10.HeaderText = "";
            this.c10.Name = "c10";
            this.c10.ReadOnly = true;
            this.c10.Width = 20;
            // 
            // dgMejor
            // 
            this.dgMejor.AllowUserToResizeColumns = false;
            this.dgMejor.AllowUserToResizeRows = false;
            this.dgMejor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMejor.ColumnHeadersVisible = false;
            this.dgMejor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgMejor.Location = new System.Drawing.Point(254, 37);
            this.dgMejor.Margin = new System.Windows.Forms.Padding(5);
            this.dgMejor.MultiSelect = false;
            this.dgMejor.Name = "dgMejor";
            this.dgMejor.ReadOnly = true;
            this.dgMejor.RowHeadersVisible = false;
            this.dgMejor.Size = new System.Drawing.Size(229, 317);
            this.dgMejor.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 20F;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 20;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 20;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 20;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 20;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 20;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 20;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 20;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 20;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 20;
            // 
            // lblTamGenotipo
            // 
            this.lblTamGenotipo.AutoSize = true;
            this.lblTamGenotipo.Location = new System.Drawing.Point(495, 84);
            this.lblTamGenotipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTamGenotipo.Name = "lblTamGenotipo";
            this.lblTamGenotipo.Size = new System.Drawing.Size(140, 16);
            this.lblTamGenotipo.TabIndex = 40;
            this.lblTamGenotipo.Text = "Tamaño de genotipo";
            // 
            // numPoblacion
            // 
            this.numPoblacion.Location = new System.Drawing.Point(648, 9);
            this.numPoblacion.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPoblacion.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPoblacion.Name = "numPoblacion";
            this.numPoblacion.Size = new System.Drawing.Size(114, 23);
            this.numPoblacion.TabIndex = 42;
            this.numPoblacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPoblacion.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numCiclos
            // 
            this.numCiclos.Location = new System.Drawing.Point(648, 48);
            this.numCiclos.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.numCiclos.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCiclos.Name = "numCiclos";
            this.numCiclos.Size = new System.Drawing.Size(114, 23);
            this.numCiclos.TabIndex = 43;
            this.numCiclos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCiclos.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // numTamGenotipo
            // 
            this.numTamGenotipo.Location = new System.Drawing.Point(648, 82);
            this.numTamGenotipo.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numTamGenotipo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTamGenotipo.Name = "numTamGenotipo";
            this.numTamGenotipo.Size = new System.Drawing.Size(114, 23);
            this.numTamGenotipo.TabIndex = 44;
            this.numTamGenotipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTamGenotipo.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Dibujo hecho por usted";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "Y por el algoritmo genético";
            // 
            // lblManual
            // 
            this.lblManual.Location = new System.Drawing.Point(817, 20);
            this.lblManual.Name = "lblManual";
            this.lblManual.Size = new System.Drawing.Size(177, 165);
            this.lblManual.TabIndex = 47;
            this.lblManual.Text = "Convenciones";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 370);
            this.Controls.Add(this.lblManual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numTamGenotipo);
            this.Controls.Add(this.numCiclos);
            this.Controls.Add(this.numPoblacion);
            this.Controls.Add(this.lblTamGenotipo);
            this.Controls.Add(this.dgMejor);
            this.Controls.Add(this.lblMejor);
            this.Controls.Add(this.lblCiclos);
            this.Controls.Add(this.lblPoblacion);
            this.Controls.Add(this.txtMejor);
            this.Controls.Add(this.btnGenetico);
            this.Controls.Add(this.dgDibujo);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmo genético";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDibujo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgMejor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPoblacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCiclos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamGenotipo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMejor;
        private System.Windows.Forms.Label lblCiclos;
        private System.Windows.Forms.Label lblPoblacion;
        private System.Windows.Forms.TextBox txtMejor;
        private System.Windows.Forms.Button btnGenetico;
        private System.Windows.Forms.DataGridView dgDibujo;
        private System.Windows.Forms.DataGridViewTextBoxColumn c1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c2;
        private System.Windows.Forms.DataGridViewTextBoxColumn c3;
        private System.Windows.Forms.DataGridViewTextBoxColumn c4;
        private System.Windows.Forms.DataGridViewTextBoxColumn c5;
        private System.Windows.Forms.DataGridViewTextBoxColumn c6;
        private System.Windows.Forms.DataGridViewTextBoxColumn c7;
        private System.Windows.Forms.DataGridViewTextBoxColumn c8;
        private System.Windows.Forms.DataGridViewTextBoxColumn c9;
        private System.Windows.Forms.DataGridViewTextBoxColumn c10;
        private System.Windows.Forms.DataGridView dgMejor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label lblTamGenotipo;
        private System.Windows.Forms.NumericUpDown numPoblacion;
        private System.Windows.Forms.NumericUpDown numCiclos;
        private System.Windows.Forms.NumericUpDown numTamGenotipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblManual;
    }
}

