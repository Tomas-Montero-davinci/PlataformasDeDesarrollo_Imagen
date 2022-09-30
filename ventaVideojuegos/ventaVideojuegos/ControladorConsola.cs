using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventaVideojuegos.Modelo;

namespace ventaVideojuegos
{
    public class ControladorConsola
    {
        public static List<Consola> Consolas { get; set; }
        public static int lastId = 0;


        public static void IniciarRepositorio()
        {
            Consolas = new List<Consola>();

            if (!File.Exists("consolas.txt"))
            {
                StreamWriter archivo = new StreamWriter("consolas.txt");
            }
            else
            {
                StreamReader archivo = new StreamReader("consolas.txt");
                while (!archivo.EndOfStream)
                {
                    string consola = archivo.ReadLine();
                    string[] datos = consola.Split(',');
                    Consola cat = new Consola()
                    {
                        Id = int.Parse(datos[0]),
                        Nombre = datos[1]
                    };

                    Consolas.Add(cat);
                    lastId = int.Parse(datos[0]);
                }
                archivo.Close();
            }

        }

        public static void AñadirConsola(Consola con)
        {
            Consolas.Add(con);
            lastId++;
            GuardarEnMemoria(con);
        }

        public static Consola GetConsolaByName(string name)
        {
            foreach (var consola in Consolas)
            {
                if (consola.Nombre.Equals(name))
                {
                    return consola;
                }
            }
            return null;
        }

        public static Consola GetConsolaById(int id)
        {
            foreach (var consola in Consolas)
            {
                if (consola.Id.Equals(id))
                {
                    return consola;
                }
            }
            return null;
        }

        public static void EliminarConsola(int id)
        {
            Consolas.RemoveAll(e => e.Id.Equals(id));
            GuardarEnMemoriaLista();
        }

        public static void ActualizarConsola(int id, Consola con)
        {
            int index = Consolas.FindIndex(e => e.Id.Equals(id));
            if (index != -1)
            {
                Consolas[index] = con;
            }
            GuardarEnMemoriaLista();
        }

        private static void GuardarEnMemoria(Consola con)
        {
            StreamWriter archivo = new StreamWriter("consolas.txt", true);
            archivo.WriteLine(con.Id + "," + con.Nombre);
            archivo.Close();
        }

        private static void GuardarEnMemoriaLista()
        {
            StreamWriter archivo = new StreamWriter("consolas.txt");
            foreach (Consola con in Consolas)
            {
                archivo.WriteLine(con.Id + "," + con.Nombre);
            }
            archivo.Close();
        }

        public static ListaConsola ListaConsola
        {
            get
            {
                if (_listaCon == null)
                {
                    _listaCon = new ListaConsola();

                    if (!File.Exists("consolas.txt"))
                    {
                        StreamWriter archivoNuevo = new StreamWriter("consolas.txt");
                        archivoNuevo.Close();
                    }
                    else
                    {
                        StreamReader archivo = new StreamReader("consolas.txt");
                        while (!archivo.EndOfStream)
                        {
                            string id = archivo.ReadLine();
                            string nombre = archivo.ReadLine();


                            Consola con = new Consola()
                            {
                                Id = int.Parse(id),
                                Nombre = nombre
                            };

                            _listaCon.GuardarEnInstancia(con);
                        }
                        archivo.Close();
                    }

                }
                return _listaCon;
            }
        }

        private static ListaConsola _listaCon;

    }
}
