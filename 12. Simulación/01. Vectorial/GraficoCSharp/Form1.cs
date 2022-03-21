using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraficoCSharp {
    public partial class Form1 : Form {
        int tamano, iniX, iniY;
        string camino;

        public Form1() {
            InitializeComponent();
            camino = "";
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            if (camino.Length == 0) return;

            Graphics grafico = e.Graphics;
            Pen lapiz = new Pen(Color.Blue, 2);

            //Punto de Inicio y fin de los segmentos
            int finX = iniX, finY = iniY;

            //Hace el gráfico vectorial
            for (int cont = 0; cont < camino.Length; cont += 2) { //El camino guía como se dibuja
                int avance = camino[cont + 1] - '0';
                switch (camino[cont]) {
                    case 'N': finY = iniY - avance * tamano; break;
                    case 'S': finY = iniY + avance * tamano; break;
                    case 'E': finX = iniX + avance * tamano; break;
                    case 'O': finX = iniX - avance * tamano; break;
                }
                grafico.DrawLine(lapiz, iniX, iniY, finX, finY);
                iniX = finX;
                iniY = finY;
            }
        }

        /* Genera una cadena de texto al azar con la siguiente estructura:
         * letra+numero+letra+numero+.....+letra+numero
         * Donde letra puede ser A, B, D, I  (Arriba, aBajo, Derecha, Izquierda)
         * Y número desde 1 hasta 9
         * Esa cadena será interpretada en Paint para hacer el gráfico vectorial */
        private void btnGenerar_Click(object sender, System.EventArgs e) {
            Random azar = new Random();
            int avanzar;
            string cadena = "";
            for (int cont = 1; cont <= 50; cont++) { //50 pares de letra+numero se generarán
                switch (azar.Next() % 4) {
                    case 0: cadena += "N"; break;
                    case 1: cadena += "S"; break;
                    case 2: cadena += "E"; break;
                    case 3: cadena += "O"; break;
                }
                avanzar = azar.Next() % 9 + 1;
                cadena += avanzar.ToString();
            }
            txtCadena.Text = cadena;
        }

        //Hace que el evento Paint() se dispare
        private void btnGraficar_Click(object sender, EventArgs e) {
            tamano = Convert.ToInt32(numTamano.Value); //Tamaño segmento linea
            iniX = Convert.ToInt32(numIniX.Value); //Punto X inicial del gráfico de tortuga
            iniY = Convert.ToInt32(numIniY.Value); //Punto Y inicial del gráfico de tortuga
            camino = txtCadena.Text;

            Refresh();
        }
    }
}
