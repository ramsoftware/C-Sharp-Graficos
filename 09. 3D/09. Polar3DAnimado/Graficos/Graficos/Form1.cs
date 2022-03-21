//Graficar ecuaciones polares de dos ángulos theta y phi, añadiendo la variable tiempo
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        //Para la variable temporal
        private double Tminimo, Tmaximo, Tincrementa, Tiempo;

        //Donde almacena los poligonos
        List<Poligono> poligonos;

        //Ángulos de giro
        double AnguloX, AnguloY, AnguloZ;
        int ZPersona;

        //Datos para la ecuación
        double minTheta, minPhi, maxTheta, maxPhi;
        int numLineas;

        //Datos para la pantalla
        int pXmin, pYmin, pXmax, pYmax;

        public Form1() {
            InitializeComponent();
            poligonos = new List<Poligono>();

            //Valores por defecto a los ángulos
            AnguloX = (double)numGiroX.Value;
            AnguloY = (double)numGiroY.Value;
            AnguloZ = (double)numGiroZ.Value;
            ZPersona = 5;

            //Valores para la ecuación
            minTheta = 0;
            maxTheta = 180;
            minPhi = 0;
            maxPhi = 360;
            numLineas = 40;

            //Inicia el tiempo
            Tminimo = 0.1;
            Tmaximo = 1;
            Tincrementa = 0.01;
            Tiempo = Tminimo;

            //Coordenadas de pantalla
            pXmin = 0;
            pYmin = 0;
            pXmax = 900;
            pYmax = 630;

            Logica();
        }

        private void timerAnimar_Tick(object sender, EventArgs e) {
            Tiempo += Tincrementa;
            if (Tiempo <= Tminimo || Tiempo >= Tmaximo) Tincrementa = -Tincrementa;
            Logica();
            Refresh();
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
            //Calcula los puntos de la ecuación y así formar los polígonos
            poligonos.Clear();
            double incTheta = (maxTheta - minTheta) / numLineas;
            double incPhi = (maxPhi - minPhi) / numLineas;
            
            //Mínimos y máximos para normalizar
            double minimoX = double.MaxValue;
            double minimoY = double.MaxValue;
            double minimoZ = double.MaxValue;
            double maximoX = double.MinValue;
            double maximoY = double.MinValue;
            double maximoZ = double.MinValue;            
            
            for (double valTheta = minTheta; valTheta <= maxTheta; valTheta += incTheta)
                for (double valPhi = minPhi; valPhi <= maxPhi; valPhi += incPhi) {

                    //Primer punto del polígono
                    double theta1 = valTheta * Math.PI / 180;
                    double phi1 = valPhi * Math.PI / 180;
                    double r1 = Ecuacion(theta1, phi1, Tiempo);
                    if (double.IsNaN(r1) || double.IsInfinity(r1)) r1 = 0;

                    double x1 = r1 * Math.Cos(phi1) * Math.Sin(theta1);
                    double y1 = r1 * Math.Sin(phi1) * Math.Sin(theta1);
                    double z1 = r1 * Math.Cos(theta1);

                    //Segundo punto del polígono
                    double theta2 = (valTheta + incTheta) * Math.PI / 180;
                    double phi2 = valPhi * Math.PI / 180;
                    double r2 = Ecuacion(theta2, phi2, Tiempo);
                    if (double.IsNaN(r2) || double.IsInfinity(r2)) r2 = 0;

                    double x2 = r2 * Math.Cos(phi2) * Math.Sin(theta2);
                    double y2 = r2 * Math.Sin(phi2) * Math.Sin(theta2);
                    double z2 = r2 * Math.Cos(theta2);

                    //Tercer punto del polígono
                    double theta3 = (valTheta + incTheta) * Math.PI / 180;
                    double phi3 = (valPhi + incPhi) * Math.PI / 180;
                    double r3 = Ecuacion(theta3, phi3, Tiempo);
                    if (double.IsNaN(r3) || double.IsInfinity(r3)) r3 = 0;

                    double x3 = r3 * Math.Cos(phi3) * Math.Sin(theta3);
                    double y3 = r3 * Math.Sin(phi3) * Math.Sin(theta3);
                    double z3 = r3 * Math.Cos(theta3);

                    //Cuarto punto del polígono
                    double theta4 = valTheta * Math.PI / 180;
                    double phi4 = (valPhi + incPhi) * Math.PI / 180;
                    double r4 = Ecuacion(theta4, phi4, Tiempo);
                    if (double.IsNaN(r4) || double.IsInfinity(r4)) r4 = 0;

                    double x4 = r4 * Math.Cos(phi4) * Math.Sin(theta4);
                    double y4 = r4 * Math.Sin(phi4) * Math.Sin(theta4);
                    double z4 = r4 * Math.Cos(theta4);
                    if (x1 < minimoX) minimoX = x1;
                    if (x2 < minimoX) minimoX = x2;
                    if (x3 < minimoX) minimoX = x3;
                    if (x4 < minimoX) minimoX = x4;

                    if (y1 < minimoY) minimoY = y1;
                    if (y2 < minimoY) minimoY = y2;
                    if (y3 < minimoY) minimoY = y3;
                    if (y4 < minimoY) minimoY = y4;

                    if (z1 < minimoZ) minimoZ = z1;
                    if (z2 < minimoZ) minimoZ = z2;
                    if (z3 < minimoZ) minimoZ = z3;
                    if (z4 < minimoZ) minimoZ = z4;

                    if (x1 > maximoX) maximoX = x1;
                    if (x2 > maximoX) maximoX = x2;
                    if (x3 > maximoX) maximoX = x3;
                    if (x4 > maximoX) maximoX = x4;

                    if (y1 > maximoY) maximoY = y1;
                    if (y2 > maximoY) maximoY = y2;
                    if (y3 > maximoY) maximoY = y3;
                    if (y4 > maximoY) maximoY = y4;

                    if (z1 > maximoZ) maximoZ = z1;
                    if (z2 > maximoZ) maximoZ = z2;
                    if (z3 > maximoZ) maximoZ = z3;
                    if (z4 > maximoZ) maximoZ = z4;

                    poligonos.Add(new Poligono(x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4));
                }
                
            //Luego normaliza los puntos X,Y,Z para que queden entre -0.5 y 0.5
            for (int cont = 0; cont < poligonos.Count; cont++) {
                poligonos[cont].coordenadas1.posX = (poligonos[cont].coordenadas1.posX - minimoX) / (maximoX - minimoX) - 0.5;
                poligonos[cont].coordenadas1.posY = (poligonos[cont].coordenadas1.posY - minimoY) / (maximoY - minimoY) - 0.5;
                poligonos[cont].coordenadas1.posZ = (poligonos[cont].coordenadas1.posZ - minimoZ) / (maximoZ - minimoZ) - 0.5;

                poligonos[cont].coordenadas2.posX = (poligonos[cont].coordenadas2.posX - minimoX) / (maximoX - minimoX) - 0.5;
                poligonos[cont].coordenadas2.posY = (poligonos[cont].coordenadas2.posY - minimoY) / (maximoY - minimoY) - 0.5;
                poligonos[cont].coordenadas2.posZ = (poligonos[cont].coordenadas2.posZ - minimoZ) / (maximoZ - minimoZ) - 0.5;

                poligonos[cont].coordenadas3.posX = (poligonos[cont].coordenadas3.posX - minimoX) / (maximoX - minimoX) - 0.5;
                poligonos[cont].coordenadas3.posY = (poligonos[cont].coordenadas3.posY - minimoY) / (maximoY - minimoY) - 0.5;
                poligonos[cont].coordenadas3.posZ = (poligonos[cont].coordenadas3.posZ - minimoZ) / (maximoZ - minimoZ) - 0.5;

                poligonos[cont].coordenadas4.posX = (poligonos[cont].coordenadas4.posX - minimoX) / (maximoX - minimoX) - 0.5;
                poligonos[cont].coordenadas4.posY = (poligonos[cont].coordenadas4.posY - minimoY) / (maximoY - minimoY) - 0.5;
                poligonos[cont].coordenadas4.posZ = (poligonos[cont].coordenadas4.posZ - minimoZ) / (maximoZ - minimoZ) - 0.5;
            }                

            //Gira y convierte los puntos espaciales en puntos proyectados al plano
            for (int cont = 0; cont < poligonos.Count; cont++) {
                poligonos[cont].GiroXYZ(AnguloX, AnguloY, AnguloZ);
                poligonos[cont].Convierte3Da2D(ZPersona);
            }

            //Constantes para cuadrar el gráfico en pantalla
            //Se obtuvieron probando los ángulos de giro X,Y,Z de 0 a 360 y ZPersona
            double XplanoMax = 0.87931543769177811;
            double XplanoMin = -0.87931543769177811;
            double YplanoMax = 0.87931539875237918;
            double YplanoMin = -0.87931539875237918;

            //Constantes de transformación
            double ConstanteX = (pXmax - pXmin) / (XplanoMax - XplanoMin);
            double ConstanteY = (pYmax - pYmin) / (YplanoMax - YplanoMin);

            //Cuadra los polígonos en pantalla
            for (int cont = 0; cont < poligonos.Count; cont++)
                poligonos[cont].CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);

            //Ordena del polígono más alejado al más cercano, de esa manera los polígonos de adelante 
            //son visibles y los de atrás son borrados.
            poligonos.Sort();
        }

        //Aquí está la ecuación polar 3D que se desee graficar con variable Theta, PHI y Tiempo
        public double Ecuacion(double Theta, double Phi, double t) {
            return Math.Cos(Phi * t) + Math.Sin(Theta * t);
        }

        //Pinta el gráfico generado por la ecuación
        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.Black, 1);
            Brush relleno = new SolidBrush(Color.White);
            for (int cont = 0; cont < poligonos.Count; cont++) 
                poligonos[cont].Dibuja(lienzo, lapiz, relleno);
        }
    }
}