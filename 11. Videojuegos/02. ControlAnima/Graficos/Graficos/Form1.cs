//Videojuego: El depredador (un cuadro rojo) controlado por el jugador con las teclas de flecha, busca la presa (un cuadro azul) evadiendo obstáculos (cuadros negros).
//Ell depredador es controlado por el control Timer (se mueve solo dependiendo de la dirección seleccionada por el jugador)
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Constantes para calificar cada celda del tablero
        private const int ESCAMINO = 0; //Celdas que representan caminos por donde puede transitar el depredador
        private const int ESOBSTACULO = 1; //Celdas que representan obstáculos por donde NO puede transitar el depredador
        private const int ESDEPREDADOR = 2; //Celda donde se dibuja la posición del depredador
        private const int ESPRESA = 3; //Celda donde se dibuja la posición de la presa
        private const int FINALIZA = 4; //Cuando el depredador cae sobre la presa

        int[,] Tablero; //Dónde ocurre realmente la acción, las coordenadas serán siempre [fila, columna]
        int DepredadorFila, DepredadorColumna; //Coordenadas del depredador
        int DepredaFila, DepredaColumna; //Desplazamiento del depredador
        int PresaFila, PresaColumna; //Coordenadas de la presa
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
            //Inicializa el tablero.
            Tablero = new int[30, 30];

            //Habrán obstáculos en el 20% del tablero
            int Obstaculos = Tablero.GetLength(0) * Tablero.GetLength(1) * 20 / 100;
            for (int cont = 1; cont <= Obstaculos; cont++) {
                int obstaculoFila, obstaculoColumna;
                do {
                    obstaculoFila = azar.Next(0, Tablero.GetLength(0));
                    obstaculoColumna = azar.Next(0, Tablero.GetLength(1));
                } while (Tablero[obstaculoFila, obstaculoColumna] != ESCAMINO);
                Tablero[obstaculoFila, obstaculoColumna] = ESOBSTACULO;
            }

            //Inicializa la posición del depredador que no sea encima de un obstáculo
            do {
                DepredadorFila = azar.Next(0, Tablero.GetLength(0));
                DepredadorColumna = azar.Next(0, Tablero.GetLength(1));
            } while (Tablero[DepredadorFila, DepredadorColumna] == ESOBSTACULO);
            Tablero[DepredadorFila, DepredadorColumna] = ESDEPREDADOR;

            //Inicializa la posición de la presa que no sea encima de un obstáculo o del depredador
            do {
                PresaFila = azar.Next(0, Tablero.GetLength(0));
                PresaColumna = azar.Next(0, Tablero.GetLength(1));
            } while (Tablero[PresaFila, PresaColumna] == ESOBSTACULO || Tablero[PresaFila, PresaColumna] == ESDEPREDADOR);
            Tablero[PresaFila, PresaColumna] = ESPRESA;
        }

        private void timerAnimar_Tick(object sender, EventArgs e) {
            Logica();
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            DepredaFila = 0;
            DepredaColumna = 0;

            //Dependiendo de que tecla de flecha presiona el jugador
            if (e.KeyCode == Keys.Up) DepredaColumna = -1;
            if (e.KeyCode == Keys.Down) DepredaColumna = 1;
            if (e.KeyCode == Keys.Left) DepredaFila = -1;
            if (e.KeyCode == Keys.Right) DepredaFila = 1;
        }

        public void Logica() {
            //Chequea que no se salga del tablero
            if (DepredadorFila + DepredaFila < 0 || DepredadorColumna + DepredaColumna < 0 || DepredadorFila + DepredaFila >= Tablero.GetLength(0) || DepredadorColumna + DepredaColumna >= Tablero.GetLength(1)) return;

            //Valida si puede desplazarse a esa nueva casilla
            if (Tablero[DepredadorFila + DepredaFila, DepredadorColumna + DepredaColumna] == ESCAMINO) {
                Tablero[DepredadorFila, DepredadorColumna] = ESCAMINO; //Borra la antigua posición
                DepredadorFila += DepredaFila; //Desplaza en Fila
                DepredadorColumna += DepredaColumna; //Desplaza en Columna
                Tablero[DepredadorFila, DepredadorColumna] = ESDEPREDADOR; //Dibuja la nueva posición
            }
            //Valida si terminó el juego cuando el depredador cae en la casilla de la presa
            else if (Tablero[DepredadorFila + DepredaFila, DepredadorColumna + DepredaColumna] == ESPRESA) {
                Tablero[DepredadorFila, DepredadorColumna] = ESCAMINO; //Borra la antigua posición
                Tablero[DepredadorFila + DepredaFila, DepredadorColumna + DepredaColumna] = FINALIZA; //Dibuja la captura
                Refresh();
                MessageBox.Show("El depredador alcanzó a la presa", "Depredador - Presa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IniciarParametros();
                Refresh();
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
                        case ESCAMINO: e.Graphics.DrawRectangle(Pens.Blue, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case ESOBSTACULO: e.Graphics.FillRectangle(Brushes.Black, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case ESDEPREDADOR: e.Graphics.FillRectangle(Brushes.Red, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case ESPRESA: e.Graphics.FillRectangle(Brushes.Blue, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case FINALIZA: e.Graphics.FillRectangle(Brushes.Brown, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                    }
                }
            }
        }
    }
}