//Sólidos de revolución animados
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
        double minXreal, maxXreal;
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
            minXreal = -2;
            maxXreal = 2;
            numLineas = 30;

            //Inicia el tiempo
            Tminimo = 0.1;
            Tmaximo = 1;
            Tincrementa = 0.01;
            Tiempo = Tminimo;

            //Coordenadas de pantalla
            pXmin = 0;
            pYmin = 0;
            pXmax = 600;
            pYmax = 600;

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
            double incrAngulo = 360 / numLineas;
            double incrXreal = (maxXreal - minXreal) / numLineas;

            //Mínimos y máximos para normalizar
            double minimoX = double.MaxValue;
            double minimoY = double.MaxValue;
            double minimoZ = double.MaxValue;
            double maximoX = double.MinValue;
            double maximoY = double.MinValue;
            double maximoZ = double.MinValue;

            for (double angulo = 0; angulo < 360; angulo += incrAngulo)
                for (double valXreal = minXreal; valXreal <= maxXreal; valXreal += incrXreal) {

                    //Primer punto
                    double X1 = valXreal;
                    double Y1 = Ecuacion(X1, Tiempo);
                    if (double.IsNaN(Y1) || double.IsInfinity(Y1)) Y1 = 0;

                    //Aplica giro en el eje X
                    double X1g = X1;
                    double Y1g = Y1 * Math.Cos(angulo * Math.PI / 180);
                    double Z1g = Y1 * -Math.Sin(angulo * Math.PI / 180);

                    //Segundo punto
                    double X2 = valXreal + incrXreal;
                    double Y2 = Ecuacion(X2, Tiempo);
                    if (double.IsNaN(Y2) || double.IsInfinity(Y2)) Y2 = 0;

                    //Aplica giro en el eje X
                    double X2g = X2;
                    double Y2g = Y2 * Math.Cos(angulo * Math.PI / 180);
                    double Z2g = Y2 * -Math.Sin(angulo * Math.PI / 180);

                    //Tercer punto
                    double X3g = X2;
                    double Y3g = Y2 * Math.Cos((angulo + incrAngulo) * Math.PI / 180);
                    double Z3g = Y2 * -Math.Sin((angulo + incrAngulo) * Math.PI / 180);

                    //Cuarto punto
                    double X4g = X1;
                    double Y4g = Y1 * Math.Cos((angulo + incrAngulo) * Math.PI / 180);
                    double Z4g = Y1 * -Math.Sin((angulo + incrAngulo) * Math.PI / 180);

                    //Cálculo de los extremos para normalizar
                    if (X1g < minimoX) minimoX = X1g;
                    if (X2g < minimoX) minimoX = X2g;
                    if (X3g < minimoX) minimoX = X3g;
                    if (X4g < minimoX) minimoX = X4g;

                    if (Y1g < minimoY) minimoY = Y1g;
                    if (Y2g < minimoY) minimoY = Y2g;
                    if (Y3g < minimoY) minimoY = Y3g;
                    if (Y4g < minimoY) minimoY = Y4g;

                    if (Z1g < minimoZ) minimoZ = Z1g;
                    if (Z2g < minimoZ) minimoZ = Z2g;
                    if (Z3g < minimoZ) minimoZ = Z3g;
                    if (Z4g < minimoZ) minimoZ = Z4g;

                    if (X1g > maximoX) maximoX = X1g;
                    if (X2g > maximoX) maximoX = X2g;
                    if (X3g > maximoX) maximoX = X3g;
                    if (X4g > maximoX) maximoX = X4g;

                    if (Y1g > maximoY) maximoY = Y1g;
                    if (Y2g > maximoY) maximoY = Y2g;
                    if (Y3g > maximoY) maximoY = Y3g;
                    if (Y4g > maximoY) maximoY = Y4g;

                    if (Z1g > maximoZ) maximoZ = Z1g;
                    if (Z2g > maximoZ) maximoZ = Z2g;
                    if (Z3g > maximoZ) maximoZ = Z3g;
                    if (Z4g > maximoZ) maximoZ = Z4g;

                    poligonos.Add(new Poligono(X1g, Y1g, Z1g, X2g, Y2g, Z2g, X3g, Y3g, Z3g, X4g, Y4g, Z4g));
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

        public double Ecuacion(double x, double t) {
            return -2 * x * x * t - 3 * x * t + 5;
        }


        //Pinta el gráfico generado por la ecuación
        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics lienzo = e.Graphics;
            Pen lapiz = new Pen(Color.Black, 1);
            Brush relleno = new SolidBrush(Color.White);
            for (int cont = 0; cont < poligonos.Count; cont++) poligonos[cont].Dibuja(lienzo, lapiz, relleno);
        }
    }
}