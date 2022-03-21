//Activar o desactivar celdas
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Constantes para calificar cada celda del tablero
        private const int INACTIVA = 0;
        private const int ACTIVA = 1;

        int[,] Tablero; //Dónde ocurre realmente la acción

        //Tamaño de cada celda
        int tamanoX, tamanoY, desplaza;

        public Form1() {
            InitializeComponent();
            IniciarParametros();
        }

        private void mnuReiniciar_Click(object sender, EventArgs e) {
            IniciarParametros();
        }

        public void IniciarParametros() {
            Tablero = new int[30, 30]; //Inicializa el tablero.

            //Tamaño de cada celda
            tamanoX = 500 / Tablero.GetLength(0);
            tamanoY = 500 / Tablero.GetLength(1);
            desplaza = 50;

            TimerAnimar.Start();
        }


        private void TimerAnimar_Tick(object sender, System.EventArgs e) {
            Refresh(); //Visual de la animación
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //Dibuja el arreglo bidimensional
            for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
                for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++) {
                    int UbicaX = Fila * tamanoX + desplaza;
                    int UbicaY = Columna * tamanoY + desplaza;
                    switch (Tablero[Fila, Columna]) {
                        case INACTIVA: e.Graphics.DrawRectangle(Pens.Blue, UbicaX, UbicaY, tamanoX, tamanoY); break;
                        case ACTIVA: e.Graphics.FillRectangle(Brushes.Black, UbicaX, UbicaY, tamanoX, tamanoY); break;
                    }
                }
            }
        }

        //Cuando da clic sobre una celda, la activa o la desactiva
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            int Fila = (e.X - desplaza) / tamanoX;
            int Columna = (e.Y - desplaza) / tamanoY;

            if (Fila >= 0 && Columna >= 0 && Fila < Tablero.GetLength(0) && Columna < Tablero.GetLength(1)) {
                switch (Tablero[Fila, Columna]) {
                    case INACTIVA: Tablero[Fila, Columna] = ACTIVA; break;
                    case ACTIVA: Tablero[Fila, Columna] = INACTIVA; break;
                }
            }
        }
    }
}