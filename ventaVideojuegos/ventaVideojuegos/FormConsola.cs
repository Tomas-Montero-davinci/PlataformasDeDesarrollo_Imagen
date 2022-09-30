using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public partial class FormConsola : Form
    {

        public Consola consolaNueva;
        public FormConsola()
        {
            InitializeComponent();
            txtID.Text = (ControladorConsola.lastId + 1).ToString();
        }

        public FormConsola(Consola con)
        {
            InitializeComponent();

            txtID.Text = con.Id.ToString();
            txtNombre.Text = con.Nombre.ToString();
        }

        private void GuardarConsola()
        {
            Consola con = new Consola()
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,

            };

            ListaConsola lista = ControladorConsola.ListaConsola;
            lista.GuardarEnInstancia(con);
            lista.GuardarEnMemoria(con);

        }

        private bool ValidarConsola(out string errorMsg)
        {
            errorMsg = String.Empty;
            if (string.IsNullOrEmpty(txtID.Text))
            {
                errorMsg += "Debe indicar el Id de la consola" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorMsg += "Debe indicar el Nombre de la consola" + Environment.NewLine;
            }
            return errorMsg == String.Empty;
        }


        private void Aceptar_Click_1(object sender, EventArgs e)
        {
            bool consolaValidada = ValidarConsola(out string errorMsg);

            if (consolaValidada)
            {
                consolaNueva = new Consola()
                {
                    Id = int.Parse(txtID.Text),
                    Nombre = txtNombre.Text
                };

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }

        }
    }
}
