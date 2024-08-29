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
        }
        public int id { get; set; }
        public int idProducto { get; set; }
        public string imagenUrl { get; set; }
    }
}
