using System.Drawing;
using System.Windows.Forms;

namespace Graficos {
    public partial class Form1 : Form {
        int PosX, PosY; //Coordenadas del cuadrado relleno

        public Form1() {
            InitializeComponent();

            //Inicializa las posiciones
            PosX = 10;
            PosY = 20;
        }

        private void TimerAnimar_Tick(object sender, System.EventArgs e) {
            //Por cada tick, incrementa en 10 el valor de la posición X del cuadrado relleno
            PosX += 10;
            Refresh(); //Refresca el formulario y llama a Paint()
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            Graphics lienzo = e.Graphics;
            SolidBrush Relleno = new SolidBrush(Color.Chocolate);

            //===============================
            //Rectángulo: Xpos, Ypos, ancho, alto
            //===============================
            lienzo.FillRectangle(Relleno, PosX, PosY, 40, 40);
        }
    }
}
