//Poner en pausa, poder cambiar las celdas y reanudar el juego
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

        //Pausa o continúa el juego
        bool JuegoPausado;

        Random azar; //Único generador de números aleatorios.

        public Form1() {
            InitializeComponent();
            azar = new Random();
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

            //¿Pausa o no el juego?
            JuegoPausado = false;

            //Habrán celdas activas en el 20%
            int Activos = Tablero.GetLength(0) * Tablero.GetLength(1) * 20 / 100;
            for (int cont = 1; cont <= Activos; cont++) {
                int posX, posY;
                do {
                    posX = azar.Next(0, Tablero.GetLength(0));
                    posY = azar.Next(0, Tablero.GetLength(1));
                } while (Tablero[posX, posY] != 0);
                Tablero[posX, posY] = ACTIVA;
            }

            TimerAnimar.Start();
        }


        private void TimerAnimar_Tick(object sender, System.EventArgs e) {
            if (JuegoPausado) return;
            Logica(); //Si el juego no está pausado entonces se ejecuta la lógica
            Refresh(); //Visual de la animación
        }

        public void Logica() {
            //Copia el tablero a uno temporal           
            int[,] TableroTmp = Tablero.Clone() as int[,];

            //Va de celda en celda
            for (int posX = 0; posX < Tablero.GetLength(0); posX++) {
                for (int posY = 0; posY < Tablero.GetLength(1); posY++) {

                    //Determina el número de vecinos activos
                    int BordeXizq = posX - 1 < 0 ? Tablero.GetLength(0) - 1 : posX - 1;
                    int BordeYarr = posY - 1 < 0 ? Tablero.GetLength(1) - 1 : posY - 1;

                    int BordeXder = posX + 1 >= Tablero.GetLength(0) ? 0 : posX + 1;
                    int BordeYaba = posY + 1 >= Tablero.GetLength(1) ? 0 : posY + 1;

                    int vecinosActivos = Tablero[BordeXizq, BordeYarr];
                    vecinosActivos += Tablero[posX, BordeYarr];
                    vecinosActivos += Tablero[BordeXder, BordeYarr];

                    vecinosActivos += Tablero[BordeXizq, posY];
                    vecinosActivos += Tablero[BordeXder, posY];

                    vecinosActivos += Tablero[BordeXizq, BordeYaba];
                    vecinosActivos += Tablero[posX, BordeYaba];
                    vecinosActivos += Tablero[BordeXder, BordeYaba];

                    //Los cambios se registran en el tablero temporal

                    //Si la celda está inactiva y tiene 3 celdas activas alrededor, entonces la celda se activa
                    if (Tablero[posX, posY] == INACTIVA && vecinosActivos == 3) TableroTmp[posX, posY] = ACTIVA;

                    //Si la celda está activa y tiene menos de 2 celdas o más de 3 celdas, entonces la celda se inactiva
                    if (Tablero[posX, posY] == ACTIVA && (vecinosActivos < 2 || vecinosActivos > 3)) TableroTmp[posX, posY] = INACTIVA;
                }
            }

            //El cambio en el tablero temporal se copia sobre el tablero
            Tablero = TableroTmp.Clone() as int[,];
        }

        private void mnuPausar_Click(object sender, EventArgs e) {
            if (!JuegoPausado) {
                JuegoPausado = true;
                mnuPausar.Text = "Continuar";
                this.Text = "Juego de la vida [PAUSADO]";
            }
            else {
                JuegoPausado = false;
                mnuPausar.Text = "Pausar";
                this.Text = "Juego de la vida [EN EJECUCIÓN]";
            }
        }

        private void mnuSalir_Click(object sender, EventArgs e) {
            Application.Exit();
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

        //Cuando da clic sobre una celda, la activa o la desactiva siempre y cuando esté pausado el juego
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            if (!JuegoPausado) return;

            int Fila = (e.X - desplaza) / tamanoX;
            int Columna = (e.Y - desplaza) / tamanoY;

            if (Fila >= 0 && Columna >= 0 && Fila < Tablero.GetLength(0) && Columna < Tablero.GetLength(1)) {
                switch (Tablero[Fila, Columna]) {
                    case INACTIVA: Tablero[Fila, Columna] = ACTIVA; break;
                    case ACTIVA: Tablero[Fila, Columna] = INACTIVA; break;
                }
            }
            Refresh();
        }
    }
}