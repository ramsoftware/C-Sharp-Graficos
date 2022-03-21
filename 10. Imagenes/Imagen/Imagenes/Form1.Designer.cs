namespace Imagenes {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.dlgCargaImagen = new System.Windows.Forms.OpenFileDialog();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnGrises = new System.Windows.Forms.Button();
            this.btnGris2 = new System.Windows.Forms.Button();
            this.btnRotar = new System.Windows.Forms.Button();
            this.btnZoom = new System.Windows.Forms.Button();
            this.pnlImagen = new System.Windows.Forms.Panel();
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.pnlImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgCargaImagen
            // 
            this.dlgCargaImagen.FileName = "openFileDialog1";
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(12, 12);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(140, 55);
            this.btnCarga.TabIndex = 1;
            this.btnCarga.Text = "Carga imagen";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnGrises
            // 
            this.btnGrises.Enabled = false;
            this.btnGrises.Location = new System.Drawing.Point(12, 120);
            this.btnGrises.Name = "btnGrises";
            this.btnGrises.Size = new System.Drawing.Size(140, 55);
            this.btnGrises.TabIndex = 2;
            this.btnGrises.Text = "Escala de grises (lento)";
            this.btnGrises.UseVisualStyleBackColor = true;
            this.btnGrises.Click += new System.EventHandler(this.btnGrises_Click);
            // 
            // btnGris2
            // 
            this.btnGris2.Enabled = false;
            this.btnGris2.Location = new System.Drawing.Point(12, 222);
            this.btnGris2.Name = "btnGris2";
            this.btnGris2.Size = new System.Drawing.Size(139, 53);
            this.btnGris2.TabIndex = 3;
            this.btnGris2.Text = "Escala de grises (rápido)";
            this.btnGris2.UseVisualStyleBackColor = true;
            this.btnGris2.Click += new System.EventHandler(this.btnGris2_Click);
            // 
            // btnRotar
            // 
            this.btnRotar.Enabled = false;
            this.btnRotar.Location = new System.Drawing.Point(12, 325);
            this.btnRotar.Name = "btnRotar";
            this.btnRotar.Size = new System.Drawing.Size(136, 46);
            this.btnRotar.TabIndex = 4;
            this.btnRotar.Text = "Rotar Imagen";
            this.btnRotar.UseVisualStyleBackColor = true;
            this.btnRotar.Click += new System.EventHandler(this.btnRotar_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Enabled = false;
            this.btnZoom.Location = new System.Drawing.Point(12, 417);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(136, 46);
            this.btnZoom.TabIndex = 5;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // pnlImagen
            // 
            this.pnlImagen.AutoScroll = true;
            this.pnlImagen.BackColor = System.Drawing.Color.White;
            this.pnlImagen.Controls.Add(this.picImagen);
            this.pnlImagen.Location = new System.Drawing.Point(167, 12);
            this.pnlImagen.Name = "pnlImagen";
            this.pnlImagen.Size = new System.Drawing.Size(713, 511);
            this.pnlImagen.TabIndex = 6;
            // 
            // picImagen
            // 
            this.picImagen.BackColor = System.Drawing.Color.White;
            this.picImagen.Location = new System.Drawing.Point(0, 0);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(275, 208);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImagen.TabIndex = 2;
            this.picImagen.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 545);
            this.Controls.Add(this.pnlImagen);
            this.Controls.Add(this.btnZoom);
            this.Controls.Add(this.btnRotar);
            this.Controls.Add(this.btnGris2);
            this.Controls.Add(this.btnGrises);
            this.Controls.Add(this.btnCarga);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesamiento de imágenes";
            this.pnlImagen.ResumeLayout(false);
            this.pnlImagen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog dlgCargaImagen;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Button btnGrises;
        private System.Windows.Forms.Button btnGris2;
        private System.Windows.Forms.Button btnRotar;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Panel pnlImagen;
        private System.Windows.Forms.PictureBox picImagen;
    }
}

