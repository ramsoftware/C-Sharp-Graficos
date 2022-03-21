//Videojuego: Detecta colisiones entre dos cuadrados
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Constantes para calificar cada celda del tablero
        private const int ESVACIO = 0;
        private const int ESOBSTACULO = 1;
        private const int ESJUGADOR = 2;

        int[,] Tablero; //Dónde ocurre realmente la acción
        int JugadorFila, JugadorColumna, JugadorTamano; //Coordenadas del jugador
        int MueveFila, MueveColumna; //Desplazamiento del jugador
        int ObstaculoFila, ObstaculoColumna, ObstaculoTamano; //Coordenadas del obstáculo

        public Form1() {
            InitializeComponent();
            IniciarParametros();
        }

        private void mnuReiniciar_Click(object sender, EventArgs e) {
            IniciarParametros();
            Refresh();
        }

        public void IniciarParametros() {
            //Inicializa el tablero.
            Tablero = new int[30, 30];

            //Inicializa la posición y tamaño del jugador
            JugadorFila = 0;
            JugadorColumna = 0;
            JugadorTamano = 5;

            //Desplazamiento del jugador
            MueveFila = 0;
            MueveColumna = 1;

            //Inicializa la posición y tamaño del obstáculo
            ObstaculoFila = 15;
            ObstaculoColumna = 15;
            ObstaculoTamano = 10;
        }

        private void timerAnimar_Tick(object sender, EventArgs e) {
            Logica();
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            MueveFila = 0;
            MueveColumna = 0;

            if (e.KeyCode == Keys.Right) MueveFila = 1;
            if (e.KeyCode == Keys.Left)  MueveFila = -1;
            if (e.KeyCode == Keys.Up) MueveColumna = -1;
            if (e.KeyCode == Keys.Down) MueveColumna = 1;
        }

        public void Logica() {
            if (JugadorFila + MueveFila < 0 || JugadorColumna + MueveColumna < 0 || JugadorFila + MueveFila + JugadorTamano > Tablero.GetLength(0) || JugadorColumna + MueveColumna + JugadorTamano > Tablero.GetLength(1)) return;

            //Borra la antigua posición del jugador
            for (int cont = 0; cont < JugadorTamano; cont++) {
                Tablero[JugadorFila + cont, JugadorColumna] = ESVACIO;
                Tablero[JugadorFila + cont, JugadorColumna + JugadorTamano - 1] = ESVACIO;
                Tablero[JugadorFila, JugadorColumna + cont] = ESVACIO;
                Tablero[JugadorFila + JugadorTamano - 1, JugadorColumna + cont] = ESVACIO;
            }

            //Desplaza al jugador
            JugadorFila += MueveFila;
            JugadorColumna += MueveColumna;

            //Grafica la nueva posición del jugador
            for (int cont = 0; cont < JugadorTamano; cont++) {
                Tablero[JugadorFila + cont, JugadorColumna] = ESJUGADOR;
                Tablero[JugadorFila + cont, JugadorColumna + JugadorTamano - 1] = ESJUGADOR;
                Tablero[JugadorFila, JugadorColumna + cont] = ESJUGADOR;
                Tablero[JugadorFila + JugadorTamano - 1, JugadorColumna + cont] = ESJUGADOR;
            }

            //Grafica la posición del obstáculo
            for (int cont = 0; cont < ObstaculoTamano; cont++) {
                Tablero[ObstaculoFila + cont, ObstaculoColumna] = ESOBSTACULO;
                Tablero[ObstaculoFila + cont, ObstaculoColumna + ObstaculoTamano - 1] = ESOBSTACULO;
                Tablero[ObstaculoFila, ObstaculoColumna + cont] = ESOBSTACULO;
                Tablero[ObstaculoFila + ObstaculoTamano - 1, ObstaculoColumna + cont] = ESOBSTACULO;
            }

            //Chequea si hay colisión
            bool HayColision = false;

            //Punto superior izquierdo
            if (JugadorFila >= ObstaculoFila && JugadorColumna >= ObstaculoColumna && JugadorFila < ObstaculoFila + ObstaculoTamano && JugadorColumna < ObstaculoColumna + ObstaculoTamano)
                HayColision = true;

            //Punto superior derecho
            else if (JugadorFila + JugadorTamano > ObstaculoFila && JugadorColumna >= ObstaculoColumna && JugadorFila + JugadorTamano < ObstaculoFila + ObstaculoTamano && JugadorColumna < ObstaculoColumna + ObstaculoTamano)
                HayColision = true;

            //Punto inferior izquierdo
            else if (JugadorFila >= ObstaculoFila && JugadorColumna + JugadorTamano > ObstaculoColumna && JugadorFila < ObstaculoFila + ObstaculoTamano && JugadorColumna + JugadorTamano < ObstaculoColumna + ObstaculoTamano)
                HayColision = true;

            //Punto inferior derecho
            else if (JugadorFila + JugadorTamano > ObstaculoFila && JugadorColumna + JugadorTamano > ObstaculoColumna && JugadorFila + JugadorTamano < ObstaculoFila + ObstaculoTamano && JugadorColumna + JugadorTamano < ObstaculoColumna + ObstaculoTamano)
                HayColision = true;

            if (HayColision) {
                lblColision.Text = "COLISIÓN";
                lblColision.BackColor = Color.Red;
            }
            else {
                lblColision.Text = "No hay colisión";
                lblColision.BackColor = Color.White;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //Tamaño de cada celda
            int tamanoFila = 500 / Tablero.GetLength(0);
            int tamanoColumna = 500 / Tablero.GetLength(1);
            int desplaza = 50;

            //Dibuja el arreglo bidimensional
            for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
                for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++) {
                    int UbicaFila = Fila * tamanoFila + desplaza;
                    int UbicaColumna = Columna * tamanoColumna + desplaza;
                    switch (Tablero[Fila, Columna]) {
                        case ESVACIO: e.Graphics.DrawRectangle(Pens.Blue, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case ESOBSTACULO: e.Graphics.FillRectangle(Brushes.Black, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case ESJUGADOR: e.Graphics.FillRectangle(Brushes.Red, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                    }
                }
            }
        }
    }
}