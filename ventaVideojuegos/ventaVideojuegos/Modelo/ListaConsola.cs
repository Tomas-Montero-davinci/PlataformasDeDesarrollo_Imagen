using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventaVideojuegos.Modelo
{
    public class ListaConsola
    {

        List<Consola> listaCon = new List<Consola>();

        public void GuardarEnInstancia(Consola con)
        {
            listaCon.Add(con);
        }

        public void GuardarEnMemoria(Consola con)
        {
            StreamWriter archivo = new StreamWriter("consolas.txt");
            archivo.WriteLine(con.Id);
            archivo.WriteLine(con.Nombre);
            archivo.Close();
        }

        public List<Consola> Consultar()
        {
            return listaCon;
        }


    }
}
