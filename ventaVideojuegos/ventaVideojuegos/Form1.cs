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
using ventaVideojuegos.UsersControls;

namespace ventaVideojuegos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UC_Inicio uc = new UC_Inicio();
            addUserControl(uc);
            
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            UC_Inicio uc = new UC_Inicio();
            addUserControl(uc);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            UC_Ventas uc = new UC_Ventas();
            addUserControl(uc);

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            UC_Admin uc = new UC_Admin();
            addUserControl(uc);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            UC_Stats uc = new UC_Stats();
            addUserControl(uc);
        }
    }
}
