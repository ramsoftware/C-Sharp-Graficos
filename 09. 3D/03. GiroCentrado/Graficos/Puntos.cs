using System;

namespace Graficos {
    internal class Puntos {
        //Coordenada espacial original
        public double posX, posY, posZ;

        //Coordenada espacial después de girar
        public double posXg, posYg, posZg;

        //Coordenada proyectada
        public double planoX, planoY;

        //Coordenada del plano enviada a la pantalla física
        public int pantallaX, pantallaY;

        //Constructor
        public Puntos(double posX, double posY, double posZ) {
            this.posX = posX;
            this.posY = posY;
            this.posZ = posZ;
        }

        //Convierte de 3D a 2D
        public void Convierte3Da2D(int ZPersona) {
            planoX = (ZPersona * posXg) / (ZPersona - posZg);
            planoY = (ZPersona * posYg) / (ZPersona - posZg);
        }

        //Gira en X
        public void GiroX(double angulo) {
            double ang = angulo * Math.PI / 180;

            double[,] Matriz = new double[3, 3] {
                {1, 0, 0},
                {0, Math.Cos(ang), Math.Sin(ang)},
                {0, -Math.Sin(ang), Math.Cos(ang) }
            };

            posXg = posX * Matriz[0,0] + posY * Matriz[1,0] + posZ * Matriz[2,0];
            posYg = posX * Matriz[0,1] + posY * Matriz[1,1] + posZ * Matriz[2,1];
            posZg = posX * Matriz[0,2] + posY * Matriz[1,2] + posZ * Matriz[2,2];
        }

        //Gira en Y
        public void GiroY(double angulo) {
            double ang = angulo * Math.PI / 180;

            double[,] Matriz = new double[3, 3] {
                {Math.Cos(ang), 0, -Math.Sin(ang)},
                {0, 1, 0},
                {Math.Sin(ang), 0, Math.Cos(ang) }
            };

            posXg = posX * Matriz[0, 0] + posY * Matriz[1, 0] + posZ * Matriz[2, 0];
            posYg = posX * Matriz[0, 1] + posY * Matriz[1, 1] + posZ * Matriz[2, 1];
            posZg = posX * Matriz[0, 2] + posY * Matriz[1, 2] + posZ * Matriz[2, 2];

        }

        //Gira en Z
        public void GiroZ(double angulo) {
            double ang = angulo * Math.PI / 180;

            double[,] Matriz = new double[3, 3] {
                {Math.Cos(ang), Math.Sin(ang), 0},
                {-Math.Sin(ang), Math.Cos(ang), 0},
                {0, 0, 1 }
            };

            posXg = posX * Matriz[0, 0] + posY * Matriz[1, 0] + posZ * Matriz[2, 0];
            posYg = posX * Matriz[0, 1] + posY * Matriz[1, 1] + posZ * Matriz[2, 1];
            posZg = posX * Matriz[0, 2] + posY * Matriz[1, 2] + posZ * Matriz[2, 2];
        }

        //Cuadra los puntos en pantalla
        public void CuadraPantalla(double ConstanteX, double ConstanteY, double XplanoMin, double YplanoMin, int pXmin, int pYmin) {
            pantallaX = Convert.ToInt32(ConstanteX * (planoX - XplanoMin) + pXmin);
            pantallaY = Convert.ToInt32(ConstanteY * (planoY - YplanoMin) + pYmin);
        }

    }
}
