using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Imagenes {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            //Que tipo de archivos mostrará el cuadro de diálogo
            dlgCargaImagen.Filter = "Archivos de imagen (*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF";
        }

        //Carga la imagen
        private void btnCarga_Click(object sender, EventArgs e) {
            //Llama a la ventana de diálogo
            if (dlgCargaImagen.ShowDialog() == DialogResult.OK) {

                //Si el usuario ha seleccionado correctamente un archivo de imagen
                picImagen.Image = new Bitmap(dlgCargaImagen.FileName);

                //Activa los botones
                btnGrises.Enabled = true;
                btnGris2.Enabled = true;
                btnRotar.Enabled = true;
                btnZoom.Enabled = true;
            }
        }

        //Técnica clásica de manipulación de imágenes. Sin embargo es muy lenta.
        private void btnGrises_Click(object sender, EventArgs e) {
            Bitmap Original = new Bitmap(picImagen.Image);
            Bitmap Gris = new Bitmap(Original.Width, Original.Height);

            for (int posX = 0; posX < Original.Width; posX++) {
                for (int posY = 0; posY < Original.Height; posY++) {
                    Color antes = Original.GetPixel(posX, posY);
                    int EscalaGris = (int)((antes.R * 0.3) + (antes.G * 0.59) + (antes.B * 0.11));
                    Color despues = Color.FromArgb(antes.A, EscalaGris, EscalaGris, EscalaGris);
                    Gris.SetPixel(posX, posY, despues);
                }
            }

            picImagen.Image = Gris;
        }

        private void btnGris2_Click(object sender, EventArgs e) {
            picImagen.Image = MakeGrayscale3(new Bitmap(picImagen.Image));
        }

        //Técnica rápida de manipulación de imágenes
        //Tomado de: https://web.archive.org/web/20130111215043/http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
        public static Bitmap MakeGrayscale3(Bitmap original) {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap)) {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
                     new float[] {.3f, .3f, .3f, 0, 0},
                     new float[] {.59f, .59f, .59f, 0, 0},
                     new float[] {.11f, .11f, .11f, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes()) {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        //Girar una imagen
        private void btnRotar_Click(object sender, EventArgs e) {
            picImagen.Image = RotateImage(new Bitmap(picImagen.Image), 45);
        }

        //Tomado de: https://stackoverflow.com/questions/2163829/how-do-i-rotate-a-picture-in-winforms
        public static Image RotateImage(Image img, float rotationAngle) {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        //Disminuir el tamaño de una imagen
        private void btnZoom_Click(object sender, EventArgs e) {
            picImagen.Image = HaceZoom(new Bitmap(picImagen.Image), 0.5);
        }

        //Tomado de: https://stackoverflow.com/questions/10915958/how-to-zoom-an-image-inout-in-c
        public static Image HaceZoom(Image originalBitmap, double zoomFactor) {
            Size newSize = new Size((int)(originalBitmap.Width * zoomFactor), (int)(originalBitmap.Height * zoomFactor));
            Bitmap bmp = new Bitmap(originalBitmap, newSize);
            return bmp;
        }


        /* Lecturas:
         * https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f
         * http://csharpexamples.com/fast-image-processing-c/
         * https://www.codeproject.com/Tips/240428/Work-with-Bitmaps-Faster-in-Csharp-3
         * https://softwarebydefault.com/
         * https://www.instructables.com/c-Edge-Detection/ 
         * https://www.youtube.com/watch?v=EPKyazYi4MI&list=PLM-p96nOrGcabqC2GvLLIL_rxx3q89JI1&index=1
         * http://coding-experiments.blogspot.com/search/label/edge%20detection
         */
    }
}
