using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdivinaElNumero
{
    public partial class Form1 : Form
    {
        public int numeroSecreto;
        public int intentos = 7;

        Random rand = new Random();

        
        public Form1()
        {
            InitializeComponent();
           // numeroSecreto = rand.Next(1, 101);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Creamos un método auxiliar para no copiar y pegar lógica en el botón Limpiar
        private void ReiniciarJuego()
        {
            // CORRECCIÓN 1: Ponemos 101 para que el 100 sea posible
            numeroSecreto = rand.Next(1, 101);
            intentos = 7;
            txtNumero.Clear();
            lblVidas.Text = "Te quedan intentos: " + intentos;
            txtNumero.Focus();
            btnProbar.Enabled = true; // Reactivamos el botón si estaba bloqueado
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            int cantidadIngresada = 0;

            // Validación
            if (!int.TryParse(txtNumero.Text, out cantidadIngresada))
            {
                MessageBox.Show("Debe de ser numeros y no letras");
                return;
            }

            // CORRECCIÓN 3: Usamos 'cantidadIngresada' en lugar de Convert.ToInt32

            // CASO 1: GANO
            if (cantidadIngresada == numeroSecreto)
            {
                MessageBox.Show("Felicidades ese es el numero del que estoy pensando");
                btnProbar.Enabled = false; // Bloqueamos para que no siga jugando
            }
            // CASO 2: EL NÚMERO ES MENOR O MAYOR
            else
            {
                // Restamos vida
                intentos--;
                lblVidas.Text = "te quedan intentos" + intentos;


                if (cantidadIngresada > numeroSecreto)
                {
                    MessageBox.Show("el numero secreto es MENOR");
                }
                else
                {
                    MessageBox.Show("el numero secreto es MAYOR");
                }

                // CORRECCIÓN 2: Verificamos la derrota INMEDIATAMENTE
                if (intentos == 0)
                {
                    MessageBox.Show("Game Over. El número era: " + numeroSecreto);
                    btnProbar.Enabled = false; // Bloqueamos el botón
                }
            }
            // Limpiamos la caja y ponemos foco para escribir rápido el siguiente
            txtNumero.Clear();
            txtNumero.Focus();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ReiniciarJuego();
        }
    }
}
