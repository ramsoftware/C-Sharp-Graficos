using System;
using System.Drawing;

namespace Graficos {
    internal class Poligono : IComparable {
        //Un polígono son cuatro(4) coordenadas espaciales
        public Puntos coordenadas1, coordenadas2, coordenadas3, coordenadas4;
        private double centro;

        public Poligono(double X1, double Y1, double Z1, double X2, double Y2, double Z2, double X3, double Y3, double Z3, double X4, double Y4, double Z4) {
            coordenadas1 = new Puntos(X1, Y1, Z1);
            coordenadas2 = new Puntos(X2, Y2, Z2);
            coordenadas3 = new Puntos(X3, Y3, Z3);
            coordenadas4 = new Puntos(X4, Y4, Z4);
        }

        //Gira en XYZ
        public void GiroXYZ(double angX, double angY, double angZ) {
            centro = double.MinValue;
            coordenadas1.GiroXYZ(angX, angY, angZ);
            coordenadas2.GiroXYZ(angX, angY, angZ);
            coordenadas3.GiroXYZ(angX, angY, angZ);
            coordenadas4.GiroXYZ(angX, angY, angZ);
            if (coordenadas1.posZg > centro) centro = coordenadas1.posZg;
            if (coordenadas2.posZg > centro) centro = coordenadas2.posZg;
            if (coordenadas3.posZg > centro) centro = coordenadas3.posZg;
            if (coordenadas4.posZg > centro) centro = coordenadas4.posZg;
        }

        //Convierte de 3D a 2D
        public void Convierte3Da2D(double ZPersona) {
            coordenadas1.Convierte3Da2D(ZPersona);
            coordenadas2.Convierte3Da2D(ZPersona);
            coordenadas3.Convierte3Da2D(ZPersona);
            coordenadas4.Convierte3Da2D(ZPersona);
        }

        //Cuadra en pantalla
        public void CuadraPantalla(double ConstanteX, double ConstanteY, double XplanoMin, double YplanoMin, int pXmin, int pYmin) {
            coordenadas1.CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);
            coordenadas2.CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);
            coordenadas3.CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);
            coordenadas4.CuadraPantalla(ConstanteX, ConstanteY, XplanoMin, YplanoMin, pXmin, pYmin);
        }


        //Hace el gráfico del polígono
        public void Dibuja(Graphics lienzo, Pen lapiz, Brush relleno) {
            //Pone un color de fondo al polígono para borrar lo que hay detrás
            Point punto1 = new Point(coordenadas1.pantallaX, coordenadas1.pantallaY);
            Point punto2 = new Point(coordenadas2.pantallaX, coordenadas2.pantallaY);
            Point punto3 = new Point(coordenadas3.pantallaX, coordenadas3.pantallaY);
            Point punto4 = new Point(coordenadas4.pantallaX, coordenadas4.pantallaY);
            Point[] poligono = { punto1, punto2, punto3, punto4 };
            lienzo.FillPolygon(relleno, poligono);

            //Pinta el perímetro del polígono
            lienzo.DrawLine(lapiz, coordenadas1.pantallaX, coordenadas1.pantallaY, coordenadas2.pantallaX, coordenadas2.pantallaY);
            lienzo.DrawLine(lapiz, coordenadas2.pantallaX, coordenadas2.pantallaY, coordenadas3.pantallaX, coordenadas3.pantallaY);
            lienzo.DrawLine(lapiz, coordenadas3.pantallaX, coordenadas3.pantallaY, coordenadas4.pantallaX, coordenadas4.pantallaY);
            lienzo.DrawLine(lapiz, coordenadas4.pantallaX, coordenadas4.pantallaY, coordenadas1.pantallaX, coordenadas1.pantallaY);
        }

        public int CompareTo(object obj) {
            Poligono orderToCompare = obj as Poligono;
            if (orderToCompare.centro < centro) {
                return 1;
            }
            if (orderToCompare.centro > centro) {
                return -1;
            }

            // The orders are equivalent.
            //https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
            return 0;
        }
    }
}
