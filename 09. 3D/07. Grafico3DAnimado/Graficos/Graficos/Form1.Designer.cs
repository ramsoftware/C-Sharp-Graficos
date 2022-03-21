namespace Graficos
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
            this.components = new System.ComponentModel.Container();
            this.numGiroX = new System.Windows.Forms.NumericUpDown();
            this.numGiroY = new System.Windows.Forms.NumericUpDown();
            this.numGiroZ = new System.Windows.Forms.NumericUpDown();
            this.lblGiroX = new System.Windows.Forms.Label();
            this.lblGiroY = new System.Windows.Forms.Label();
            this.lblGiroZ = new System.Windows.Forms.Label();
            this.timerAnimar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numGiroX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiroY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiroZ)).BeginInit();
            this.SuspendLayout();
            // 
            // numGiroX
            // 
            this.numGiroX.Location = new System.Drawing.Point(1042, 20);
            this.numGiroX.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.numGiroX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numGiroX.Name = "numGiroX";
            this.numGiroX.Size = new System.Drawing.Size(84, 27);
            this.numGiroX.TabIndex = 0;
            this.numGiroX.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numGiroX.ValueChanged += new System.EventHandler(this.numGiroX_ValueChanged);
            // 
            // numGiroY
            // 
            this.numGiroY.Location = new System.Drawing.Point(1042, 64);
            this.numGiroY.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.numGiroY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numGiroY.Name = "numGiroY";
            this.numGiroY.Size = new System.Drawing.Size(84, 27);
            this.numGiroY.TabIndex = 1;
            this.numGiroY.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numGiroY.ValueChanged += new System.EventHandler(this.numGiroY_ValueChanged);
            // 
            // numGiroZ
            // 
            this.numGiroZ.Location = new System.Drawing.Point(1042, 111);
            this.numGiroZ.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.numGiroZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numGiroZ.Name = "numGiroZ";
            this.numGiroZ.Size = new System.Drawing.Size(84, 27);
            this.numGiroZ.TabIndex = 2;
            this.numGiroZ.ValueChanged += new System.EventHandler(this.numGiroZ_ValueChanged);
            // 
            // lblGiroX
            // 
            this.lblGiroX.AutoSize = true;
            this.lblGiroX.BackColor = System.Drawing.Color.White;
            this.lblGiroX.Location = new System.Drawing.Point(949, 20);
            this.lblGiroX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiroX.Name = "lblGiroX";
            this.lblGiroX.Size = new System.Drawing.Size(84, 18);
            this.lblGiroX.TabIndex = 4;
            this.lblGiroX.Text = "Giro en X";
            // 
            // lblGiroY
            // 
            this.lblGiroY.AutoSize = true;
            this.lblGiroY.BackColor = System.Drawing.Color.White;
            this.lblGiroY.Location = new System.Drawing.Point(949, 64);
            this.lblGiroY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiroY.Name = "lblGiroY";
            this.lblGiroY.Size = new System.Drawing.Size(84, 18);
            this.lblGiroY.TabIndex = 5;
            this.lblGiroY.Text = "Giro en Y";
            // 
            // lblGiroZ
            // 
            this.lblGiroZ.AutoSize = true;
            this.lblGiroZ.BackColor = System.Drawing.Color.White;
            this.lblGiroZ.Location = new System.Drawing.Point(949, 111);
            this.lblGiroZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiroZ.Name = "lblGiroZ";
            this.lblGiroZ.Size = new System.Drawing.Size(84, 18);
            this.lblGiroZ.TabIndex = 6;
            this.lblGiroZ.Text = "Giro en Z";
            // 
            // timerAnimar
            // 
            this.timerAnimar.Enabled = true;
            this.timerAnimar.Tick += new System.EventHandler(this.timerAnimar_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1137, 635);
            this.Controls.Add(this.lblGiroZ);
            this.Controls.Add(this.lblGiroY);
            this.Controls.Add(this.lblGiroX);
            this.Controls.Add(this.numGiroZ);
            this.Controls.Add(this.numGiroY);
            this.Controls.Add(this.numGiroX);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pintar gráficos de ecuaciones del tipo Z = F(X,Y, T) donde T es el tiempo";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.numGiroX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiroY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiroZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numGiroX;
        private System.Windows.Forms.NumericUpDown numGiroY;
        private System.Windows.Forms.NumericUpDown numGiroZ;
        private System.Windows.Forms.Label lblGiroX;
        private System.Windows.Forms.Label lblGiroY;
        private System.Windows.Forms.Label lblGiroZ;
        private System.Windows.Forms.Timer timerAnimar;
    }
}

