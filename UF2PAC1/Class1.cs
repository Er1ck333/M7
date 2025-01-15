using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF2_PAC1F
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }

        public static List<Producto> ObtenerDatosSimulados()
        {
            return new List<Producto>
        {
            new Producto { Nombre = "Libro A", Categoria = "Educación", Precio = 12.5 },
            new Producto { Nombre = "Libro B", Categoria = "Literatura", Precio = 9.0 },
            new Producto { Nombre = "Libro C", Categoria = "Educación", Precio = 15.0 },
            new Producto { Nombre = "Libro D", Categoria = "Ficción", Precio = 8.5 }
        };
        }
    }

}
