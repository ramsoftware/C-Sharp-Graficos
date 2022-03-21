/* Dar con la cadena que genera un gráfico dado. Para ello se recurre a una rama de la Inteligencia Artificial
 * conocida como algoritmos evolutivos, más precisamente los algoritmos genéticos.
 * */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AGDibujo {
    public partial class Form1 : Form {
        private int NUMFILAS = 10, NUMCOLUMNAS = 10;
        public Form1() {
            InitializeComponent();
            lblManual.Text = "Convenciones: " + Environment.NewLine +
                "S: Sur pinta" + Environment.NewLine +
                "N: Norte pinta" + Environment.NewLine +
                "O: Oeste pinta" + Environment.NewLine +
                "E: Este pinta" + Environment.NewLine +
                "s: Sur borra" + Environment.NewLine +
                "n: Norte borra" + Environment.NewLine +
                "o: Oeste borra" + Environment.NewLine +
                "e: Este borra";
        }

        //Llena las filas de los grid
        private void Form1_Load(object sender, EventArgs e) {
            //Llena de filas el GridView
            for (int filas = 0; filas < NUMFILAS; filas++) {
                dgDibujo.Rows.Add((DataGridViewRow)dgDibujo.Rows[0].Clone());
                dgMejor.Rows.Add((DataGridViewRow)dgMejor.Rows[0].Clone());
            }
        }

        //Cuando el usuario de clic en alguna celda, esta cambia de color
        private void dgDibujo_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dgDibujo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
                dgDibujo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
            else
                dgDibujo.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;

            dgDibujo.CurrentCell = null; //No mostrar el cursor de la celda actual 
        }

        //Activa el proceso de algoritmos genéticos
        private void btnGenetico_Click(object sender, EventArgs e) {
            ProcesoGenetico();
        }

        //Algoritmo genético
        private void ProcesoGenetico() {
            //1. Pasa a un arreglo bidimensional el contenido del grid
            int[,] Tablero = new int[NUMFILAS, NUMCOLUMNAS];
            for (int fila = 0; fila < NUMFILAS; fila++)
                for (int columna = 0; columna < NUMCOLUMNAS; columna++)
                    if (dgDibujo.Rows[fila].Cells[columna].Style.BackColor == Color.Red) Tablero[fila, columna] = 1;

            //2. Genera la población de individuos
            Random azar = new Random();
            int tamGenotipo = Convert.ToInt32(numTamGenotipo.Value);
            int tamPoblacion = Convert.ToInt32(numPoblacion.Value);
            string[] individuos = new string[tamPoblacion];
            for (int genera = 0; genera < tamPoblacion; genera++)
                individuos[genera] = GeneraIndividuo(azar, tamGenotipo);

            //3. Ciclo de algoritmo genético
            int ciclos = Convert.ToInt32(numCiclos.Value);
            for (int cont = 1; cont <= ciclos; cont++) {

                //4. Toma dos individuos al azar
                int indivA = azar.Next() % tamPoblacion;
                int indivB = azar.Next() % tamPoblacion;

                //5. Evalúa cual individuo es mejor
                int adaptaA = EvaluaIndividuo(individuos[indivA], Tablero);
                int adaptaB = EvaluaIndividuo(individuos[indivB], Tablero);
                string Mejor;
                if (adaptaA < adaptaB)
                    Mejor = individuos[indivA];
                else
                    Mejor = individuos[indivB];

                //6. Muta alguna parte al azar. Nota: La mutación puede dañar al individuo hijo
                string hijo;
                do {
                    char[] arreglo = Mejor.ToCharArray();
                    int posMuta = azar.Next() % tamGenotipo;
                    switch (azar.Next() % 8) {
                        case 0: arreglo[posMuta] = 'O'; break;
                        case 1: arreglo[posMuta] = 'E'; break;
                        case 2: arreglo[posMuta] = 'N'; break;
                        case 3: arreglo[posMuta] = 'S'; break;
                        case 4: arreglo[posMuta] = 'o'; break;
                        case 5: arreglo[posMuta] = 'e'; break;
                        case 6: arreglo[posMuta] = 'n'; break;
                        case 7: arreglo[posMuta] = 's'; break;
                    }
                    hijo = new string(arreglo);
                } while (EvaluaIndividuo(hijo, Tablero) == -1); //Hasta que sea una mutación viable

                //7. Sobreescribe el peor adaptado
                if (adaptaA < adaptaB)
                    individuos[indivB] = hijo;
                else
                    individuos[indivA] = hijo;
            }

            //8. Muestra el mejor individuo hallado
            int ElMejor = -1, MejorAproxima = int.MaxValue, acumula = 0;
            for (int cont = 0; cont < individuos.Length; cont++) {
                int evaluando = EvaluaIndividuo(individuos[cont], Tablero);
                acumula += evaluando;
                if (evaluando < MejorAproxima) {
                    MejorAproxima = evaluando;
                    ElMejor = cont;
                }
            }

            txtMejor.Text = individuos[ElMejor];
            LlenarGrid(txtMejor.Text, Tablero);
        }

        //Retorna una cadena de dibujo que sería el individuo
        private string GeneraIndividuo(Random azar, int tamGenotipo) {
            string individuo = "";
            int fila = 0, columna = 0, movimiento, varFila = 0, varColumna = 0;

            for (int cont = 1; cont <= tamGenotipo; cont++) { //Número de instrucciones que tendrá el individuo
                do { //Hasta que se encuentre un movimiento viable
                    movimiento = azar.Next() % 8;
                    switch (movimiento) {
                        case 0:
                        case 1: varFila = 0; varColumna = -1; break; //Arriba
                        case 2:
                        case 3: varFila = 0; varColumna = 1; break; //aBajo
                        case 4:
                        case 5: varFila = -1; varColumna = 0; break; //Izquierda
                        case 6:
                        case 7: varFila = 1; varColumna = 0; break; //Derecha
                    }
                } while (fila + varFila < 0 || fila + varFila > NUMFILAS - 1 || columna + varColumna < 0 || columna + varColumna > NUMCOLUMNAS - 1);

                switch (movimiento) {  //Se añade ese movimiento viable
                    case 0: individuo += "O"; break;
                    case 1: individuo += "o"; break;
                    case 2: individuo += "E"; break;
                    case 3: individuo += "e"; break;
                    case 4: individuo += "N"; break;
                    case 5: individuo += "n"; break;
                    case 6: individuo += "S"; break;
                    case 7: individuo += "s"; break;
                }

                //Se actualiza la posición del cursor
                fila += varFila;
                columna += varColumna;
            }
            return individuo;  //Retorna el individuo generado
        }

        //Evalúa la adaptación del individuo. Entre más cercano a cero es mejor.
        private int EvaluaIndividuo(string cadena, int[,] tablero) {

            //En un arreglo bidimensional se guarda el camino dibujado por el individuo
            int[,] pinta = new int[NUMFILAS, NUMCOLUMNAS];

            //El caminar del individuo
            int fila = 0, columna = 0, valor = 0;
            for (int letra = 0; letra < cadena.Length; letra++) {
                switch (cadena[letra]) {
                    case 'O':
                    case 'o': columna--; break;
                    case 'E':
                    case 'e': columna++; break;
                    case 'N':
                    case 'n': fila--; break;
                    case 'S':
                    case 's': fila++; break;
                }
                switch (cadena[letra]) {
                    case 'O':
                    case 'E':
                    case 'N':
                    case 'S': valor = 1; break;
                    case 'o':
                    case 'e':
                    case 'n':
                    case 's': valor = 0; break;

                }

                //Si una mutación hace inviable al individuo retorna -1
                if (fila < 0 || columna < 0 || fila > NUMFILAS-1 || columna > NUMCOLUMNAS - 1) return -1;

                //Actualiza el tablero como dibuja el individuo
                pinta[fila, columna] = valor;
            }

            //El valor absoluto de la resta entre lo que dibuja el individuo y el dibujo del usuario, será la adaptación
            int adapta = 0;
            for (fila = 0; fila < NUMFILAS; fila++)
                for (columna = 0; columna < NUMCOLUMNAS; columna++)
                    adapta += Math.Abs(pinta[fila, columna] - tablero[fila, columna]);

            return adapta;
        }

        //Muestra el tablero con lo pedido por el usuario y el individuo generado
        private void LlenarGrid(string cadena, int[,] tablero) {
            int fila, columna;
            for (fila = 0; fila < NUMFILAS; fila++)
                for (columna = 0; columna < NUMCOLUMNAS; columna++)
                    if (tablero[fila, columna] == 0)
                        dgDibujo.Rows[fila].Cells[columna].Style.BackColor = Color.White;
                    else
                        dgDibujo.Rows[fila].Cells[columna].Style.BackColor = Color.Red;

            //En un arreglo bidimensional se guarda el camino dibujado por el individuo
            int[,] pinta = new int[NUMFILAS, NUMCOLUMNAS];

            //El caminar del individuo
            fila = 0;
            columna = 0;
            int valor = 0;
            for (int letra = 0; letra < cadena.Length; letra++) {
                switch (cadena[letra]) {
                    case 'O':
                    case 'o': columna--; break;
                    case 'E':
                    case 'e': columna++; break;
                    case 'N':
                    case 'n': fila--; break;
                    case 'S':
                    case 's': fila++; break;
                }
                switch (cadena[letra]) {
                    case 'O':
                    case 'E':
                    case 'N':
                    case 'S': valor = 1; break;
                    case 'o':
                    case 'e':
                    case 'n':
                    case 's': valor = 0; break;

                }
                //Actualiza el tablero como dibuja el individuo
                pinta[fila, columna] = valor;
            }

            for (fila = 0; fila < NUMFILAS; fila++)
                for (columna = 0; columna < NUMCOLUMNAS; columna++)
                    if (pinta[fila, columna] == 0)
                        dgMejor.Rows[fila].Cells[columna].Style.BackColor = Color.White;
                    else
                        dgMejor.Rows[fila].Cells[columna].Style.BackColor = Color.Blue;

            dgDibujo.CurrentCell = null; //No mostrar el cursor de la celda actual
            dgMejor.CurrentCell = null; //No mostrar el cursor de la celda actual
        }
    }
}
