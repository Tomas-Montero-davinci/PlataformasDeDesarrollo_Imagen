using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class Producto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public Categoria Categoria { get; set; }
        public Consola Consola { get; set; }
        public string Conexion { get; set; }
        public string ModoJuego { get; set; }
        public string Imagen { get; set; }

        


    }
}
