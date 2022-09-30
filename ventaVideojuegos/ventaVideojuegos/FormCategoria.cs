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
    public partial class FormCategoria : Form
    {

        public Categoria categoriaNueva;
        public FormCategoria()
        {
            InitializeComponent();
            txtID.Text = (ControladorCategorias.lastId + 1).ToString();
        }

        public FormCategoria(Categoria cat)
        {
            InitializeComponent();

            txtID.Text = cat.Id.ToString();
            txtNombre.Text = cat.Nombre.ToString();
        }

        private void GuardarCategoria()
        {
            Categoria cat = new Categoria()
            {
                Id = int.Parse(txtID.Text),
                Nombre = txtNombre.Text,

            };

            ListaCategoria lista = ControladorCategorias.ListaCategoria;
            lista.GuardarEnInstancia(cat);
            lista.GuardarEnMemoria(cat);

        }


        private bool ValidarCategoria(out string errorMsg)
        {
            errorMsg = String.Empty;
            if (string.IsNullOrEmpty(txtID.Text))
            {
                errorMsg += "Debe indicar el Id de la categoria" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorMsg += "Debe indicar el Nombre de la categoria" + Environment.NewLine;
            }
            return errorMsg == String.Empty;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            bool categoriaValidada = ValidarCategoria(out string errorMsg);

            if (categoriaValidada)
            {
                categoriaNueva = new Categoria()
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
