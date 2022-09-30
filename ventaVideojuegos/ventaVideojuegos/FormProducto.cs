
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public partial class FormProducto : Form
    {
        public Producto productoNuevo;
        public string filePath = string.Empty;
        public FormProducto()
        {
            InitializeComponent();
            txtId.Text = (ControladorProductos.lastId + 1).ToString();
            llenarBoxCategoria();
            llenarBoxConsola();
        }

        public FormProducto(Producto prod)
        {
            InitializeComponent();
            llenarBoxCategoria();
            llenarBoxConsola();

            txtId.Text = prod.Id.ToString();
            txtNombre.Text = prod.Nombre.ToString();
            txtPrecio.Text = prod.Precio.ToString();
            txtStock.Text = prod.Stock.ToString();
            boxCategoria.Text = prod.Categoria.Nombre.ToString();
            txtConexion.Text = prod.Conexion.ToString();
            boxConsola.SelectedItem = prod.Consola.Nombre.ToString();
            txtModoJuego.Text = prod.ModoJuego.ToString();

        }

        private void llenarBoxCategoria()
        {
            foreach (Categoria cat in ControladorCategorias.Categorias)
            {
                boxCategoria.Items.Add(cat.Nombre);
            }
        }

        private void llenarBoxConsola()
        {
            foreach (Consola con in ControladorConsola.Consolas)
            {
                boxConsola.Items.Add(con.Nombre);
            }
        }

        private void GuardarProducto()
        {
            Producto prod = new Producto()
            {
                Id= int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Precio = int.Parse(txtPrecio.Text),
                Stock = int.Parse(txtStock.Text),
                Categoria = ControladorCategorias.GetCategoriaByName(boxCategoria.SelectedItem.ToString()),
                Consola = ControladorConsola.GetConsolaByName(boxConsola.SelectedItem.ToString()),
                Conexion = txtConexion.Text,
                ModoJuego = txtModoJuego.Text
            };

            ListaProducto lista = ControladorProductos.ListaProducto;
            lista.GuardarEnInstancia(prod);
            lista.GuardarEnMemoria(prod);

        }

        private bool ValidarProducto(out string errorMsg)
        {
            errorMsg = String.Empty;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                errorMsg += "Debe indicar el Id del producto" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorMsg += "Debe indicar el Nombre del producto" + Environment.NewLine; 
            }
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                errorMsg += "Debe indicar el Precio del producto" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                errorMsg += "Debe indicar el Stock del producto" + Environment.NewLine;
            }
            if (boxCategoria.SelectedItem == null)
            {
                errorMsg += "Debe indicar la Categoria del producto" + Environment.NewLine;
            }
            if (boxConsola.SelectedItem == null)
            {
                errorMsg += "Debe indicar la Consola del producto" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtModoJuego.Text))
            {
                errorMsg += "Debe indicar el Modo de Juego del producto" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(txtConexion.Text))
            {
                errorMsg += "Debe indicar la Conexion del producto" + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtImagen.Text))
            {
                errorMsg += "Debe indicar la Imagen del producto" + Environment.NewLine;
            }
            else if (txtImagen.Text.Contains("jpg") == false)
            {
                errorMsg += "El formato es incorrecto, seleccione otro archivo" + Environment.NewLine;
            }


            return errorMsg == String.Empty;
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            bool productoValidado = ValidarProducto(out string errorMsg);

            if (productoValidado)
            {
                productoNuevo = new Producto()
                {
                    Id = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    Precio = int.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    Categoria = ControladorCategorias.GetCategoriaByName(boxCategoria.SelectedItem.ToString()),
                    Consola = ControladorConsola.GetConsolaByName(boxConsola.SelectedItem.ToString()),
                    Conexion = txtConexion.Text,
                    ModoJuego = txtModoJuego.Text,
                    Imagen = getRuta(),
                };

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            var fileContent = string.Empty;
            //var filePath = string.Empty;
            var fileName = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    fileName = openFileDialog.SafeFileName;
                    txtImagen.Text = fileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }


            //string source = filePath;

            //string test = @"Videos_Desktop\";

            //Console.WriteLine(filePath);
            //Console.WriteLine(fileName);

            // Replace one substring with another with String.Replace.
            // Only exact matches are supported.

            //var replacement = source.Replace(@"Videos_Desktop\", "Videos_Desktop&&");
            //Console.WriteLine(replacement);

            //String argumentos = $"/C cd {replacement} && ffmpeg -i {fileName} -r 1/1 ImagenPorFrame.bmp";
            //Console.WriteLine(argumento);
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = argumentos;
            //startInfo.Arguments = "/C notepad";
            //process.StartInfo = startInfo;
            //process.Start();

        }

        public string getRuta()
        {
            return filePath;
        }
    }
}
