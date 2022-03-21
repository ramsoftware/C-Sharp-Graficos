//Proyección 3D a 2D y giros en los tres ejes simultáneamente
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
        double ZPersona;

        //Datos para la pantalla
        int pXmin, pYmin, pXmax, pYmax;

        public Form1() {
            InitializeComponent();
            puntos = new List<Puntos>();

            //Coordenadas del cubo
            puntos.Add(new Puntos(-0.5, -0.5, -0.5));
            puntos.Add(new Puntos(0.5, -0.5, -0.5));
            puntos.Add(new Puntos(0.5, 0.5, -0.5));
            puntos.Add(new Puntos(-0.5, 0.5, -0.5));
            puntos.Add(new Puntos(-0.5, -0.5, 0.5));
            puntos.Add(new Puntos(0.5, -0.5, 0.5));
            puntos.Add(new Puntos(0.5, 0.5, 0.5));
            puntos.Add(new Puntos(-0.5, 0.5, 0.5));

            //Valores por defecto a los ángulos
            AnguloX = (double)numGiroX.Value;
            AnguloY = (double)numGiroY.Value;
            AnguloZ = (double)numGiroZ.Value;
            ZPersona = 5;

            //Coordenadas de pantalla
            pXmin = 20;
            pYmin = 20;
            pXmax = 500;
            pYmax = 500;

            Logica();
        }

        private void numGiroX_ValueChanged(object sender, System.EventArgs e) {
            AnguloX = Convert.ToDouble(numGiroX.Value);
            Logica();
            Refresh();
        }

        private void numGiroY_ValueChanged(object sender, EventArgs e) {
            AnguloY = Convert.ToDouble(numGiroY.Value);
            Logica();
            Refresh();
        }

        private void numGiroZ_ValueChanged(object sender, EventArgs e) {
            AnguloZ = Convert.ToDouble(numGiroZ.Value);
            Logica();
            Refresh();
        }

        public void Logica() {
            //Gira y convierte los puntos espaciales en puntos proyectados al plano
            for (int cont = 0; cont < puntos.Count; cont++) {
                puntos[cont].GiroXYZ(AnguloX, AnguloY, AnguloZ);
                puntos[cont].Convierte3Da2D(ZPersona);
            }
			
            //Constantes para cuadrar el cubo en pantalla
            //Se obtuvieron probando los ángulos de giro X,Y,Z de 0 a 360 y ZPersona
            double XplanoMax = 0.87931543769177811;
            double XplanoMin = -0.87931543769177811;
            double YplanoMax = 0.87931539875237918;
            double YplanoMin = -0.87931539875237918;

            //Cuadra los puntos en pantalla
            double ConstanteX = (pXmax - pXmin) / (XplanoMax - XplanoMin);
            double ConstanteY = (pYmax - pYmin) / (YplanoMax - YplanoMin);

            for (int cont = 0; cont < puntos.Count; cont++)
                puntos[cont].CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);
        }


        //Pinta la proyección
        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.Black, 1);

            lienzo.DrawLine(lapiz, puntos[0].pantallaX, puntos[0].pantallaY, puntos[4].pantallaX, puntos[4].pantallaY);
            lienzo.DrawLine(lapiz, puntos[1].pantallaX, puntos[1].pantallaY, puntos[5].pantallaX, puntos[5].pantallaY);
            lienzo.DrawLine(lapiz, puntos[2].pantallaX, puntos[2].pantallaY, puntos[6].pantallaX, puntos[6].pantallaY);
            lienzo.DrawLine(lapiz, puntos[3].pantallaX, puntos[3].pantallaY, puntos[7].pantallaX, puntos[7].pantallaY);

            lienzo.DrawLine(lapiz, puntos[0].pantallaX, puntos[0].pantallaY, puntos[1].pantallaX, puntos[1].pantallaY);
            lienzo.DrawLine(lapiz, puntos[1].pantallaX, puntos[1].pantallaY, puntos[2].pantallaX, puntos[2].pantallaY);
            lienzo.DrawLine(lapiz, puntos[2].pantallaX, puntos[2].pantallaY, puntos[3].pantallaX, puntos[3].pantallaY);
            lienzo.DrawLine(lapiz, puntos[3].pantallaX, puntos[3].pantallaY, puntos[0].pantallaX, puntos[0].pantallaY);

            lienzo.DrawLine(lapiz, puntos[4].pantallaX, puntos[4].pantallaY, puntos[5].pantallaX, puntos[5].pantallaY);
            lienzo.DrawLine(lapiz, puntos[5].pantallaX, puntos[5].pantallaY, puntos[6].pantallaX, puntos[6].pantallaY);
            lienzo.DrawLine(lapiz, puntos[6].pantallaX, puntos[6].pantallaY, puntos[7].pantallaX, puntos[7].pantallaY);
            lienzo.DrawLine(lapiz, puntos[7].pantallaX, puntos[7].pantallaY, puntos[4].pantallaX, puntos[4].pantallaY);
        }
    }
}