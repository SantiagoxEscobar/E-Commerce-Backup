using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Productos
{
    public class Producto
    {
        public Producto()
        {
            id = -1;
            nombre = "NULL";
            codigo = "NULL";
            descripcion = "NULL";
            stock = -1;
            precio = -1;
            categoria = new Categoria();
            marca = new Marca();
            imagenes = new List<Imagen>();
        }
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
        public Categoria categoria { get; set; }
        public Marca marca { get; set; }
        public List<Imagen> imagenes { get; set; }

    }
}
