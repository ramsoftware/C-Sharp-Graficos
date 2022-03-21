using System;

namespace Graficos {
    internal class Puntos {
        //Coordenada espacial original
        public double posX, posY, posZ;

        //Coordenada espacial después de girar
        public double posXg, posYg, posZg;

        //Coordenada proyectada
        public int planoX, planoY;

        //Constructor
        public Puntos(int posX, int posY, int posZ) {
            this.posX = posX;
            this.posY = posY;
            this.posZ = posZ;
        }

        //Convierte de 3D a 2D
        public void Convierte3Da2D(int ZPersona) {
            planoX = Convert.ToInt32((ZPersona * posXg) / (ZPersona - posZg));
            planoY = Convert.ToInt32((ZPersona * posYg) / (ZPersona - posZg));
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

    }
}
