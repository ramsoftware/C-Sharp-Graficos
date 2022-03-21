namespace Graficos {
    internal class Puntos {
        //Coordenada espacial
        public int posX, posY, posZ;

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
            planoX = (ZPersona * posX) / (ZPersona - posZ);
            planoY = (ZPersona * posY) / (ZPersona - posZ);
        }
    }
}
