//Videojuego: El jugador debe evitar chocar con la pared que va dejando atrás
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Constantes para calificar cada celda del tablero
        private const int VACIO = 0;
        private const int PARED = 1;

        int[,] Tablero; //Dónde ocurre realmente la acción
        
        //Jugador: dónde está, cómo se mueve
        int PosFila, PosColumna, MueveFila, MueveColumna;

        public Form1() {
            InitializeComponent();
            IniciarParametros();
        }

        private void mnuReiniciar_Click(object sender, EventArgs e) {
            IniciarParametros();
            Refresh();
        }

        public void IniciarParametros() {
            //Inicializa el tablero: Fila,Columna
            Tablero = new int[50, 50];

            //Pone como pared el perímetro del tablero
            for (int fila = 0; fila < Tablero.GetLength(0); fila++) {
                Tablero[fila, 0] = PARED;
                Tablero[fila, Tablero.GetLength(1) - 1] = PARED;
            }

            for (int columna = 0; columna < Tablero.GetLength(1); columna++) {
                Tablero[0, columna] = PARED;
                Tablero[Tablero.GetLength(0) - 1, columna] = PARED;
            }

            //Ubica al jugador
            PosFila = 20;
            PosColumna = 20;
            MueveFila = 0;
            MueveColumna = 1;
        }

        private void timerAnimar_Tick(object sender, EventArgs e) {
            Logica();
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            //Dependiendo de que tecla de flecha presiona el jugador
            if (e.KeyCode == Keys.Left && MueveColumna == 0) {
                MueveColumna = -1;
                MueveFila = 0;
            }

            if (e.KeyCode == Keys.Right && MueveColumna == 0) {
                MueveColumna = 1;
                MueveFila = 0;
            }

            if (e.KeyCode == Keys.Up && MueveFila == 0) {
                MueveFila = -1;
                MueveColumna = 0;
            }
            
            if (e.KeyCode == Keys.Down && MueveFila == 0) {
                MueveFila = 1;
                MueveColumna = 0;
            }
        }

        public void Logica() {
            PosFila += MueveFila;
            PosColumna += MueveColumna;

            //Verifica si colisionó con una pared
            if (Tablero[PosFila, PosColumna] == PARED) {
                timerAnimar.Stop();
                MessageBox.Show("Ha colisionado con la pared", "Fin del juego", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarParametros();
                timerAnimar.Start();
                return;
            }

            Tablero[PosFila, PosColumna] = PARED;
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
                        case PARED: e.Graphics.FillRectangle(Brushes.Black, UbicaColumna, UbicaFila, tamColumna, tamFila); break;
                    }
                }
            }
        }
    }
}