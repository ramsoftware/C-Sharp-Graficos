//Rebote de una pelota. El usuario puede agregar o quitar paredes
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Constantes para calificar cada celda del tablero
        private const int INACTIVA = 0;
        private const int ACTIVA = 1;
        private const int PELOTA = 2;

        //Posición y desplazamiento de la pelota
        private int PelotaFila, PelotaColumna, incFila, incColumna;

        int[,] Tablero; //Dónde ocurre realmente la acción

        //Tamaño de cada celda
        int tamanoFila, tamanoColumna, desplaza;

        public Form1() {
            InitializeComponent();
            IniciarParametros();
        }

        public void IniciarParametros() {
            Tablero = new int[30, 30]; //Inicializa el tablero.

            //Dibuja el perímetro
            for (int fila = 0; fila < Tablero.GetLength(0); fila++) {
                Tablero[fila, 0] = ACTIVA;
                Tablero[fila, Tablero.GetLength(1) - 1] = ACTIVA;
            }

            for (int columna = 0; columna < Tablero.GetLength(0); columna++) {
                Tablero[0, columna] = ACTIVA;
                Tablero[Tablero.GetLength(0) - 1, columna] = ACTIVA;
            }

            //Tamaño de cada celda
            tamanoFila = 500 / Tablero.GetLength(0);
            tamanoColumna = 500 / Tablero.GetLength(1);
            desplaza = 50;

            //Pelota
            PelotaFila = 12;
            PelotaColumna = 15;
            incFila = 1;
            incColumna = 1;

            TimerAnimar.Start();
        }


        private void TimerAnimar_Tick(object sender, System.EventArgs e) {
            Logica();
            Refresh(); //Visual de la animación
        }

        //Lógica del rebote
        private void Logica() {
            if (PelotaFila + incFila < 0 || PelotaFila + incFila >= Tablero.GetLength(0) || PelotaColumna + incColumna < 0 || PelotaColumna + incColumna >= Tablero.GetLength(1)) return;
            
            //Si golpea alguna pared
            bool cambio = false;
            if (Tablero[PelotaFila + 1, PelotaColumna] == ACTIVA) { incFila *= -1; cambio = true; }
            if (Tablero[PelotaFila - 1, PelotaColumna] == ACTIVA) { incFila *= -1; cambio = true; }
            if (Tablero[PelotaFila, PelotaColumna + 1] == ACTIVA) { incColumna *= -1; cambio = true; }
            if (Tablero[PelotaFila, PelotaColumna - 1] == ACTIVA) { incColumna *= -1; cambio = true; }

            //Si golpea una punta
            if (!cambio) {
                if (Tablero[PelotaFila + incFila, PelotaColumna + incColumna] == ACTIVA) {
                    incFila *= -1;
                    incColumna *= -1;
                }
            }

            //Dibuja la nueva posición siempre y cuando esté permitida
            if (Tablero[PelotaFila+incFila, PelotaColumna+incColumna] == INACTIVA) {
                Tablero[PelotaFila, PelotaColumna] = INACTIVA;
                PelotaFila += incFila;
                PelotaColumna += incColumna;
                Tablero[PelotaFila, PelotaColumna] = PELOTA;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            //Dibuja el arreglo bidimensional
            for (int Fila = 0; Fila < Tablero.GetLength(0); Fila++) {
                for (int Columna = 0; Columna < Tablero.GetLength(1); Columna++) {
                    int UbicaFila = Fila * tamanoFila + desplaza;
                    int UbicaColumna = Columna * tamanoColumna + desplaza;
                    switch (Tablero[Fila, Columna]) {
                        case INACTIVA: e.Graphics.DrawRectangle(Pens.Blue, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case ACTIVA: e.Graphics.FillRectangle(Brushes.Black, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                        case PELOTA: e.Graphics.FillRectangle(Brushes.Red, UbicaFila, UbicaColumna, tamanoFila, tamanoColumna); break;
                    }
                }
            }
        }

        //Cuando da clic sobre una celda, la activa o la desactiva
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            int Fila = (e.X - desplaza) / tamanoFila;
            int Columna = (e.Y - desplaza) / tamanoColumna;

            if (Fila >= 0 && Columna >= 0 && Fila < Tablero.GetLength(0) && Columna < Tablero.GetLength(1)) {
                switch (Tablero[Fila, Columna]) {
                    case INACTIVA: Tablero[Fila, Columna] = ACTIVA; break;
                    case ACTIVA: Tablero[Fila, Columna] = INACTIVA; break;
                }
            }
        }
    }
}