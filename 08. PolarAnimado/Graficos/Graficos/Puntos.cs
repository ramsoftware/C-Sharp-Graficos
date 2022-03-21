namespace Graficos {
    internal class Puntos {
        //Valor X, Y reales de la ecuación
        public double valorX, valorY;

        //Puntos convertidos a coordenadas enteras de pantalla
        public int pantallaX, pantallaY;

        public Puntos(double valorX, double valorY) {
            this.valorX = valorX;
            this.valorY = valorY;
        }
    }
}
