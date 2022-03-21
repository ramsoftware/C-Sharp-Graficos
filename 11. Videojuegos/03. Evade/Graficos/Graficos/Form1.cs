//Videojuego: El jugador debe evitar que le caigan las piedras encima
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Constantes para calificar cada celda del tablero
        private const int VACIO = 0;
        private const int PIEDRA = 1;
        private const int JUGADOR = 2;

        int[,] Tablero; //Dónde ocurre realmente la acción
        int PosJugador, MovimientoJugador; //Columna donde está del jugador
        Random azar; //Único generador de números aleatorios.

        public Form1() {
            InitializeComponent();
            azar = new Random();
            IniciarParametros();
        }

        private void mnuReiniciar_Click(object sender, EventArgs e) {
            IniciarParametros();
            Refresh();
        }

        public void IniciarParametros() {
            //Inicializa el tablero Fila,Columna
            Tablero = new int[50, 30];
            MovimientoJugador = 0;
        }

        private void timerAnimar_Tick(object sender, EventArgs e) {
            MuevePiedras();
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            //Dependiendo de que tecla de flecha presiona el jugador
            if (e.KeyCode == Keys.Left) MovimientoJugador = -1; //Jugador se mueve a la izquierda
            if (e.KeyCode == Keys.Right) MovimientoJugador = 1; //Jugador se mueve a la derecha
            MueveJugador();
            Refresh();
        }

        public void MueveJugador() {
            //Movimiento del jugador
            if (PosJugador + MovimientoJugador < 0 || PosJugador + MovimientoJugador >= Tablero.GetLength(1)) return;

            Tablero[Tablero.GetLength(0) - 1, PosJugador] = VACIO;
            PosJugador += MovimientoJugador;
            Tablero[Tablero.GetLength(0) - 1, PosJugador] = JUGADOR;
        }

        public void MuevePiedras() {

            //Movimiento de las piedras
            for (int fila = Tablero.GetLength(0)-1; fila > 0; fila--) {
                for (int columna = 0; columna < Tablero.GetLength(1); columna++) {
                    Tablero[fila, columna] = Tablero[fila - 1, columna];
                }
            }

            //Verifica si una piedra golpeó al jugador
            if (Tablero[Tablero.GetLength(0) - 1, PosJugador] == PIEDRA) {
                timerAnimar.Stop();
                MessageBox.Show("Ha sido alcanzado por una piedra", "Fin del juego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarParametros();
                timerAnimar.Start();
                return;
            }
            else
                Tablero[Tablero.GetLength(0) - 1, PosJugador] = JUGADOR;

            //Pone piedras al azar en la primera fila
            int colPiedra, TotalPiedras = 3;
            for (colPiedra = 0; colPiedra < Tablero.GetLength(1); colPiedra++)  Tablero[0, colPiedra] = VACIO;
            for (int piedra = 1; piedra <= TotalPiedras; piedra++) {
                do {
                    colPiedra = azar.Next(0, Tablero.GetLength(1));
                } while (Tablero[0, colPiedra] == PIEDRA);
                Tablero[0, colPiedra] = PIEDRA;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //Tamaño de cada celda
            int tamFila = 500 / Tablero.GetLength(0);
            int tamColumna = 500 / Tablero.GetLength(1);
            int desplaza = 50;

            //Dibuja el arreglo bidimensional
            for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
                for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++) {
                    int UbicaFila = Fila * tamFila + desplaza;
                    int UbicaColumna = Columna * tamColumna + desplaza;
                    switch (Tablero[Fila, Columna]) {
                        case VACIO: e.Graphics.DrawRectangle(Pens.Blue, UbicaColumna, UbicaFila, tamColumna, tamFila); break;
                        case PIEDRA: e.Graphics.FillRectangle(Brushes.Black, UbicaColumna, UbicaFila, tamColumna, tamFila); break;
                        case JUGADOR: e.Graphics.FillRectangle(Brushes.Red, UbicaColumna, UbicaFila, tamColumna, tamFila); break;
                    }
                }
            }
        }
    }
}