//Proyección 3D a 2D y giros en los tres ejes simultáneamente. Líneas ocultas.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {

        //Donde almacena los poligonos
        List<Poligono> poligonos;

        //Ángulos de giro
        double AnguloX, AnguloY, AnguloZ;
        double ZPersona;

        //Datos para la pantalla
        int pXmin, pYmin, pXmax, pYmax;

        public Form1() {
            InitializeComponent();
            poligonos = new List<Poligono>();

            //Polígonos que forman el cubo
            poligonos.Add(new Poligono(-0.5, 0.5, -0.5, 0.5, 0.5, -0.5, 0.5, -0.5, -0.5, -0.5, -0.5, -0.5));
            poligonos.Add(new Poligono(-0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, -0.5, 0.5, -0.5, -0.5, 0.5));

            poligonos.Add(new Poligono(-0.5, 0.5, -0.5, -0.5, 0.5, 0.5, -0.5, -0.5, 0.5, -0.5, -0.5, -0.5));
            poligonos.Add(new Poligono(0.5, 0.5, -0.5, 0.5, 0.5, 0.5, 0.5, -0.5, 0.5, 0.5, -0.5, -0.5));

            poligonos.Add(new Poligono(-0.5, 0.5, -0.5, 0.5, 0.5, -0.5, 0.5, 0.5, 0.5, -0.5, 0.5, 0.5));
            poligonos.Add(new Poligono(-0.5, -0.5, -0.5, 0.5, -0.5, -0.5, 0.5, -0.5, 0.5, -0.5, -0.5, 0.5));

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

        private void numDistancia_ValueChanged(object sender, EventArgs e) {
        }

        public void Logica() {
            //Gira y convierte los puntos espaciales en puntos proyectados al plano
            for (int cont = 0; cont < poligonos.Count; cont++) {
                poligonos[cont].GiroXYZ(AnguloX, AnguloY, AnguloZ);
                poligonos[cont].Convierte3Da2D(ZPersona);
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

            for (int cont = 0; cont < poligonos.Count; cont++)
                poligonos[cont].CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);

            //Ordena del polígono más alejado al más cercano, de esa manera los polígonos de adelante 
            //son visibles y los de atrás son borrados.
            poligonos.Sort();
        }


        //Pinta la proyección del cubo
        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.Black, 1);
            Brush relleno = new SolidBrush(Color.White);
            for (int cont = 0; cont < poligonos.Count; cont++) 
                poligonos[cont].Dibuja(lienzo, lapiz, relleno);
        }
    }
}