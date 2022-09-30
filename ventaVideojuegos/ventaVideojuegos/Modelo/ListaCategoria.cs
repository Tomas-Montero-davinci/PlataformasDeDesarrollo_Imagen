using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class ListaCategoria
    {
        List<Categoria> listaCat = new List<Categoria>();

        public void GuardarEnInstancia(Categoria cat)
        {
            listaCat.Add(cat);
        }

        public void GuardarEnMemoria(Categoria cat)
        {
            StreamWriter archivo = new StreamWriter("categorias.txt");
            archivo.WriteLine(cat.Id);
            archivo.WriteLine(cat.Nombre);
            archivo.Close();
        }

        public List<Categoria> Consultar()
        {
            return listaCat;
        }
    }
}
