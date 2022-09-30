using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class ListaProducto
    {

        List<Producto> lista = new List<Producto>();

        public void GuardarEnInstancia(Producto prod)
        {
            lista.Add(prod);
        }

        public void GuardarEnMemoria(Producto prod)
        {
            StreamWriter archivo = new StreamWriter("productos.txt");
            archivo.WriteLine(prod.Id);
            archivo.WriteLine(prod.Nombre);
            archivo.WriteLine(prod.Precio);
            archivo.WriteLine(prod.Stock);
            archivo.WriteLine(prod.Categoria);
            archivo.WriteLine(prod.Consola);
            archivo.WriteLine(prod.Conexion);
            archivo.WriteLine(prod.ModoJuego);
            archivo.WriteLine(prod.Imagen);
            archivo.Close();
        }

        public List<Producto> Consultar ()
        {
            return lista;   
        }

    }
}
