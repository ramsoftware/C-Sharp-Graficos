﻿namespace Graficos
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
            this.timerAnimar = new System.Windows.Forms.Timer(this.components);
            this.lblColision = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerAnimar
            // 
            this.timerAnimar.Enabled = true;
            this.timerAnimar.Tick += new System.EventHandler(this.timerAnimar_Tick);
            // 
            // lblColision
            // 
            this.lblColision.AutoSize = true;
            this.lblColision.BackColor = System.Drawing.Color.White;
            this.lblColision.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColision.Location = new System.Drawing.Point(146, 12);
            this.lblColision.Name = "lblColision";
            this.lblColision.Size = new System.Drawing.Size(172, 25);
            this.lblColision.TabIndex = 0;
            this.lblColision.Text = "No hay colisión";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 580);
            this.Controls.Add(this.lblColision);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detecta colisiones";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerAnimar;
        private System.Windows.Forms.Label lblColision;
    }
}

