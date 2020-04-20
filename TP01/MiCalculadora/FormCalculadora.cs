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
        string operador;
        double resultado;
        
        public FormCalculadora()
        {
            InitializeComponent();

            string[] operadores = { "+", "-", "*", "/" }; //array con mis operadores
            foreach (string operador in operadores) // por cada operador en operadores 
            {
                this.cmbOperadores.Items.Add(operador); // los agrego al combo
            }
            this.cmbOperadores.SelectedIndex = 0;

            this.lblResultado.Text = "0";
            resultado = 0;
            this.StartPosition = FormStartPosition.CenterScreen;//centro el form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;//no se puede ajustar el tamaño

            //deshabilito los botones 
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            btnConvertirBinario.Enabled = false; 
            btnConvertirDecimal.Enabled = false; 
        }

        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.txtNum2.Clear();
            this.txtNum1.Clear();
            btnConvertirBinario.Enabled = false; 
            btnConvertirDecimal.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1,n2,operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            operador = this.cmbOperadores.Text;
            resultado = Operar(this.txtNum1.Text, this.txtNum2.Text,operador);
            this.lblResultado.Text = resultado.ToString();

            btnConvertirBinario.Enabled = true; 
            btnConvertirDecimal.Enabled = true; 

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirBinario_Click(object sender, EventArgs e)
        {
            string strResultado;
            strResultado = Numero.DecimalBinario(resultado);
            this.lblResultado.Text = strResultado;
        }

        private void btnConvertirDecimal_Click(object sender, EventArgs e)
        {
            string strResultado;
            strResultado = Numero.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = strResultado;
        }
    }
}
