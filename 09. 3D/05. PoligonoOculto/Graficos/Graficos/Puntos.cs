using System;

namespace Graficos {
    internal class Puntos {
        //Coordenada espacial original
        public double posX, posY, posZ;

        //Coordenada espacial después de girar
        public double posXg, posYg, posZg;

        //Coordenada proyectada
        public double planoX, planoY;

        //Coordenada en la pantalla
        public int pantallaX, pantallaY;

        //Constructor
        public Puntos(double posX, double posY, double posZ) {
            this.posX = posX;
            this.posY = posY;
            this.posZ = posZ;
        }

        //Gira en XYZ
        public void GiroXYZ(double angX, double angY, double angZ) {
            double angXr = angX * Math.PI / 180;
            double angYr = angY * Math.PI / 180;
            double angZr = angZ * Math.PI / 180;

            double CosX = Math.Cos(angXr);
            double SinX = Math.Sin(angXr);
            double CosY = Math.Cos(angYr);
            double SinY = Math.Sin(angYr);
            double CosZ = Math.Cos(angZr);
            double SinZ = Math.Sin(angZr);

            //Matriz de Rotación
            //https://en.wikipedia.org/wiki/Rotation_formalisms_in_three_dimensions
            double[,] Matriz = new double[3, 3] {
                { CosY * CosZ, -CosX * SinZ + SinX * SinY * CosZ, SinX * SinZ + CosX * SinY * CosZ},
                { CosY * SinZ, CosX * CosZ + SinX * SinY * SinZ, -SinX * CosZ + CosX * SinY * SinZ},
                {-SinY, SinX * CosY, CosX * CosY }
            };

            posXg = posX * Matriz[0, 0] + posY * Matriz[1, 0] + posZ * Matriz[2, 0];
            posYg = posX * Matriz[0, 1] + posY * Matriz[1, 1] + posZ * Matriz[2, 1];
            posZg = posX * Matriz[0, 2] + posY * Matriz[1, 2] + posZ * Matriz[2, 2];
        }

        //Convierte de 3D a 2D
        public void Convierte3Da2D(double ZPersona) {
            planoX = posXg * ZPersona / (ZPersona - posZg);
            planoY = posYg * ZPersona / (ZPersona - posZg);
        }

        //Cuadra los puntos en pantalla
        public void CuadraPantalla(double ConstanteX, double ConstanteY, double XplanoMin, double YplanoMin, int pXmin, int pYmin) {
            pantallaX = Convert.ToInt32(ConstanteX * (planoX - XplanoMin) + pXmin);
            pantallaY = Convert.ToInt32(ConstanteY * (planoY - YplanoMin) + pYmin);
        }
    }
}
