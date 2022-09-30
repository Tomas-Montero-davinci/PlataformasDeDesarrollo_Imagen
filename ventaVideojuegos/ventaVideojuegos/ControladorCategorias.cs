using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ControladorCategorias
    {
        public static List<Categoria> Categorias { get; set; }
        public static int lastId = 0;


        public static void IniciarRepositorio()
        {
            Categorias = new List<Categoria>();

            if (!File.Exists("categorias.txt"))
            {
                StreamWriter archivo = new StreamWriter("categorias.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("categorias.txt");
                while(!archivo.EndOfStream)
                {
                    string categoria = archivo.ReadLine();
                    string[] datos = categoria.Split(',');
                    Categoria cat = new Categoria()
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1]
                    };
                    Categorias.Add(cat);
                    lastId = int.Parse(datos[0]);
                   
                    
                }
                archivo.Close();
            }

        }

        public static void AñadirCategoria(Categoria cat)
        {
            Categorias.Add(cat);
            lastId++;
            GuardarEnMemoria(cat);
        }

        public static Categoria GetCategoriaByName(string name)
        {
            foreach (var categoria in Categorias)
            {
                if(categoria.Nombre.Equals(name))
                {
                    return categoria;
                }    
            }
            return null;
        }

        public static Categoria GetCategoriaById(int id)
        {
            foreach (var categoria in Categorias)
            {
                if (categoria.Id.Equals(id))
                {
                    return categoria;
                }
            }
            return null;
        }

        public static void EliminarCategoria(int id)
        {
            Categorias.RemoveAll(e => e.Id.Equals(id));
            GuardarEnMemoriaLista();
        }

        public static void ActualizarCategoria(int id, Categoria cat)
        {
            int index = Categorias.FindIndex(e => e.Id.Equals(id));
            if (index != -1)
            {
                Categorias[index] = cat;
            }
            GuardarEnMemoriaLista();
        }

        private static void GuardarEnMemoria(Categoria cat)
        {
            StreamWriter archivo = new StreamWriter("categorias.txt", true);
            archivo.WriteLine(cat.Id + "," + cat.Nombre);
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("categorias.txt");
            foreach (Categoria cat in Categorias)
            {
                archivo.WriteLine(cat.Id + "," + cat.Nombre);
            }
            archivo.Close();
        }

        public static ListaCategoria ListaCategoria
        {
            get
            {
                if (_listaCat == null)
                {
                    _listaCat = new ListaCategoria();

                    if (!File.Exists("categorias.txt"))
                    {
                        StreamWriter archivoNuevo = new StreamWriter("categorias.txt");
                        archivoNuevo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("categorias.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombre = archivo.ReadLine();


                            Categoria cat = new Categoria()
                            {
                                Id = int.Parse(id),
                                Nombre = nombre
                            };

                            _listaCat.GuardarEnInstancia(cat);
                        }
                        archivo.Close();
                    }

                }
                return _listaCat;
            }
        }

        private static ListaCategoria _listaCat;
    }
}
