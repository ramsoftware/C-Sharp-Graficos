//Proyección 3D a 2D y giros
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {

        //Donde almacena los puntos
        List<Puntos> puntos;

        //Ángulos de giro
        double AnguloX, AnguloY, AnguloZ;
        int ZPersona;

        public Form1() {
            InitializeComponent();
            puntos = new List<Puntos>();

            //Coordenadas del cubo
            puntos.Add(new Puntos(50, 50, 50));
            puntos.Add(new Puntos(100, 50, 50));
            puntos.Add(new Puntos(100, 100, 50));
            puntos.Add(new Puntos(50, 100, 50));
            puntos.Add(new Puntos(50, 50, 100));
            puntos.Add(new Puntos(100, 50, 100));
            puntos.Add(new Puntos(100, 100, 100));
            puntos.Add(new Puntos(50, 100, 100));

            //Valores por defecto a los ángulos
            AnguloX = 0;
            AnguloY = 0;
            AnguloZ = 0;
            ZPersona = 180;

            Logica(0);
        }

        private void numGiroX_ValueChanged(object sender, System.EventArgs e) {
            AnguloX = Convert.ToDouble(numGiroX.Value);
            Logica(0);
            Refresh();
        }

        private void numGiroY_ValueChanged(object sender, EventArgs e) {
            AnguloY = Convert.ToDouble(numGiroY.Value);
            Logica(1);
            Refresh();
        }

        private void numGiroZ_ValueChanged(object sender, EventArgs e) {
            AnguloZ = Convert.ToDouble(numGiroZ.Value);
            Logica(2);
            Refresh();
        }

        private void numDistancia_ValueChanged(object sender, EventArgs e) {
            ZPersona = Convert.ToInt32(numDistancia.Value);
            Logica(0);
            Refresh();
        }

        public void Logica(int AnguloGira) {
            //Gira y convierte los puntos espaciales en puntos proyectados al plano
            for (int cont = 0; cont < puntos.Count; cont++) {
                switch (AnguloGira) {
                    case 0: puntos[cont].GiroX(AnguloX); break;
                    case 1: puntos[cont].GiroY(AnguloY); break;
                    case 2: puntos[cont].GiroZ(AnguloZ); break;
                }
                puntos[cont].Convierte3Da2D(ZPersona);
            }
        }


        //Pinta la proyección
        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.Blue, 3);

            lienzo.DrawLine(lapiz, puntos[0].planoX, puntos[0].planoY, puntos[1].planoX, puntos[1].planoY);
            lienzo.DrawLine(lapiz, puntos[1].planoX, puntos[1].planoY, puntos[2].planoX, puntos[2].planoY);
            lienzo.DrawLine(lapiz, puntos[2].planoX, puntos[2].planoY, puntos[3].planoX, puntos[3].planoY);
            lienzo.DrawLine(lapiz, puntos[3].planoX, puntos[3].planoY, puntos[0].planoX, puntos[0].planoY);

            lienzo.DrawLine(lapiz, puntos[4].planoX, puntos[4].planoY, puntos[5].planoX, puntos[5].planoY);
            lienzo.DrawLine(lapiz, puntos[5].planoX, puntos[5].planoY, puntos[6].planoX, puntos[6].planoY);
            lienzo.DrawLine(lapiz, puntos[6].planoX, puntos[6].planoY, puntos[7].planoX, puntos[7].planoY);
            lienzo.DrawLine(lapiz, puntos[7].planoX, puntos[7].planoY, puntos[4].planoX, puntos[4].planoY);

            lienzo.DrawLine(lapiz, puntos[0].planoX, puntos[0].planoY, puntos[4].planoX, puntos[4].planoY);
            lienzo.DrawLine(lapiz, puntos[1].planoX, puntos[1].planoY, puntos[5].planoX, puntos[5].planoY);
            lienzo.DrawLine(lapiz, puntos[2].planoX, puntos[2].planoY, puntos[6].planoX, puntos[6].planoY);
            lienzo.DrawLine(lapiz, puntos[3].planoX, puntos[3].planoY, puntos[7].planoX, puntos[7].planoY);
        }
    }
}