//Graficar ecuaciones de doble variable independiente y una variable temporal
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
        double minX, minY, maxX, maxY;
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
            minX = -9;
            minY = -9;
            maxX = 9;
            maxY = 9;
            numLineas = 30;

            //Inicia el tiempo
            Tminimo = 0.1;
            Tmaximo = 1;
            Tincrementa = 0.01;
            Tiempo = Tminimo;

            //Valores de la pantalla (región donde se dibuja)
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
            //Calcula cada coordenada del gráfico de la ecuación.
            poligonos.Clear();
            double incrementoX = (maxX - minX) / numLineas;
            double incrementoY = (maxY - minY) / numLineas;

            //Mínimos y máximos para normalizar
            double minimoX = double.MaxValue;
            double minimoY = double.MaxValue;
            double minimoZ = double.MaxValue;
            double maximoX = double.MinValue;
            double maximoY = double.MinValue;
            double maximoZ = double.MinValue;

            //Hace el cálculo de las 4 coordenadas de cada polígono
            for (double valX = minX; valX <= maxX; valX += incrementoX)
                for (double valY = minY; valY <= maxY; valY += incrementoY) {

                    //Primera coordenada
                    double X1 = valX;
                    double Y1 = valY;
                    double Z1 = Ecuacion(X1, Y1, Tiempo);
                    if (double.IsNaN(Z1) || double.IsInfinity(Z1)) Z1 = 0;

                    //Segunda coordenada
                    double X2 = valX + incrementoX;
                    double Y2 = valY;
                    double Z2 = Ecuacion(X2, Y2, Tiempo);
                    if (double.IsNaN(Z2) || double.IsInfinity(Z2)) Z2 = 0;

                    //Tercera coordenada
                    double X3 = valX + incrementoX;
                    double Y3 = valY + incrementoY;
                    double Z3 = Ecuacion(X3, Y3, Tiempo);
                    if (double.IsNaN(Z3) || double.IsInfinity(Z3)) Z3 = 0;

                    //Cuarta coordenada
                    double X4 = valX;
                    double Y4 = valY + incrementoY;
                    double Z4 = Ecuacion(X4, Y4, Tiempo);
                    if (double.IsNaN(Z4) || double.IsInfinity(Z4)) Z4 = 0;

                    //Para más adelante hace la normalización
                    if (X1 < minimoX) minimoX = X1;
                    if (X2 < minimoX) minimoX = X2;
                    if (X3 < minimoX) minimoX = X3;
                    if (X4 < minimoX) minimoX = X4;

                    if (Y1 < minimoY) minimoY = Y1;
                    if (Y2 < minimoY) minimoY = Y2;
                    if (Y3 < minimoY) minimoY = Y3;
                    if (Y4 < minimoY) minimoY = Y4;

                    if (Z1 < minimoZ) minimoZ = Z1;
                    if (Z2 < minimoZ) minimoZ = Z2;
                    if (Z3 < minimoZ) minimoZ = Z3;
                    if (Z4 < minimoZ) minimoZ = Z4;

                    if (X1 > maximoX) maximoX = X1;
                    if (X2 > maximoX) maximoX = X2;
                    if (X3 > maximoX) maximoX = X3;
                    if (X4 > maximoX) maximoX = X4;

                    if (Y1 > maximoY) maximoY = Y1;
                    if (Y2 > maximoY) maximoY = Y2;
                    if (Y3 > maximoY) maximoY = Y3;
                    if (Y4 > maximoY) maximoY = Y4;

                    if (Z1 > maximoZ) maximoZ = Z1;
                    if (Z2 > maximoZ) maximoZ = Z2;
                    if (Z3 > maximoZ) maximoZ = Z3;
                    if (Z4 > maximoZ) maximoZ = Z4;

                    //Crea el polígono
                    poligonos.Add(new Poligono(X1, Y1, Z1, X2, Y2, Z2, X3, Y3, Z3, X4, Y4, Z4));
                }

            //Luego normaliza los puntos X,Y,Z de cada polígono para que queden entre -0.5 y 0.5
            //Es decir, el gráfico queda confinado en un cubo de lado = 1
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

            double ConstanteX = (pXmax - pXmin) / (XplanoMax - XplanoMin);
            double ConstanteY = (pYmax - pYmin) / (YplanoMax - YplanoMin);

            //Cuadra los polígonos para aparecer en pantalla
            for (int cont = 0; cont < poligonos.Count; cont++)
                poligonos[cont].CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);

            //Ordena del polígono más alejado al más cercano, de esa manera los polígonos de adelante 
            //son visibles y los de atrás son borrados.
            poligonos.Sort();
        }

        //Ecuación con las tres variables independientes, una de ellas es el tiempo t
        public double Ecuacion(double x, double y, double t) {
            return Math.Sqrt(t * x * x + t * y * y) + 3 * Math.Cos(Math.Sqrt(t * x * x + t * y * y)) + 5;
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