using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            Limpiar();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text;
            string num2 = txtNumero2.Text;
            string operador;
            if (!(cmbOperador.SelectedItem is null))
            {
                operador = cmbOperador.SelectedItem.ToString();
            }
            else
            {
                operador = cmbOperador.Text;
            }
            lblResultado.Text = Operar(num1, num2, operador).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.Text = "";
            cmbOperador.SelectedItem = null;

        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
    }
}
