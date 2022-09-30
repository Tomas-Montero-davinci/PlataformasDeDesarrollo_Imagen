using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ControladorProductos
    {

        public static List<Producto> Productos {get ; set;}
        public static int lastId = 0;

        public static void IniciarRepositorio()
        {
            Productos = new List<Producto>();

            if(!File.Exists("productos.txt"))
            {
                StreamWriter archivo = new StreamWriter("productos.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("productos.txt");
                while (!archivo.EndOfStream)
                {
                    string producto = archivo.ReadLine();
                    string[] datos = producto.Split(',');
                    Producto prod = new Producto()
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1],
                        Precio = int.Parse(datos[2]),
                        Stock = int.Parse(datos[3]),
                        Categoria = ControladorCategorias.GetCategoriaById(int.Parse(datos[4])),
                        Consola = ControladorConsola.GetConsolaById(int.Parse(datos[5])),
                        Conexion = datos[6],
                        ModoJuego = datos[7],
                        Imagen = datos[8],
                    };
                    lastId = int.Parse(datos[0]);
                    Productos.Add(prod);
                }
                archivo.Close();
            }

        }

        public static void AñandirProducto (Producto prod)
        {
            Productos.Add (prod);
            lastId++;
            GuardarEnMemoria(prod);
        }

        public static void EliminarProducto(int id)
        {
            Productos.RemoveAll(e => e.Id.Equals(id));
            GuardarEnMemoriaLista();
        }

        public static void ActualizarProductos(int id, Producto prod)
        {
            int index = Productos.FindIndex(e => e.Id.Equals(id));
            if(index != -1)
            {
                Productos[index] = prod;
            }
            GuardarEnMemoriaLista();
        }

        private static void GuardarEnMemoria(Producto prod)
        {
            StreamWriter archivo = new StreamWriter("productos.txt", true);
            archivo.WriteLine(prod.Id + "," + prod.Nombre + "," + prod.Precio + "," + prod.Stock + "," + prod.Categoria.Id + "," + prod.Consola.Id + "," + prod.Conexion + "," + prod.ModoJuego + "," + prod.Imagen);
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("productos.txt");
            foreach (Producto prod in Productos)
            {
                archivo.WriteLine(prod.Id + "," + prod.Nombre + "," + prod.Precio + "," + prod.Stock + "," + prod.Categoria.Id + "," + prod.Consola.Id + "," + prod.Conexion + "," + prod.ModoJuego + "," + prod.Imagen);
            }
            archivo.Close();
        }



        public static ListaProducto ListaProducto
        {
            get
            {
                if (_lista == null)
                {
                    _lista = new ListaProducto();

                    if (!File.Exists("productos.txt"))
                    {
                        StreamWriter archivoNuevo = new StreamWriter("productos.txt");
                        archivoNuevo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("productos.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombre = archivo.ReadLine();
                            string precio = archivo.ReadLine();
                            string stock = archivo.ReadLine();
                            string categoria = archivo.ReadLine();
                            string consola = archivo.ReadLine();
                            string conexion = archivo.ReadLine();
                            string modojuego = archivo.ReadLine();
                            string imagen = archivo.ReadLine();

                            Producto prod = new Producto()
                            {
                                Id = int.Parse(id),
                                Nombre = nombre,
                                Precio = int.Parse(precio),
                                Stock = int.Parse(stock),
                                Categoria = ControladorCategorias.GetCategoriaByName(categoria),
                                Consola = ControladorConsola.GetConsolaByName(consola),
                                Conexion = conexion,
                                ModoJuego = modojuego,
                                Imagen = imagen,
                            };

                            _lista.GuardarEnInstancia(prod);
                        }
                        archivo.Close();
                    }

                }
                return _lista;
            }
        }

        private static ListaProducto _lista;

    }
}
