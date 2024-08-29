using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Productos
{
    public class Imagen
    {
        public Imagen()
        {
            id = -1;
            idProducto = -1;
            imagenUrl = "";
            estado = true;
        }
        public int id { get; set; }
        public int idProducto { get; set; }
        public string imagenUrl { get; set; }
        public int tipo { get; set; }
        public bool estado { get; set; }
    }
}
