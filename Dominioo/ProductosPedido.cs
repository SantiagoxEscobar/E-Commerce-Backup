using Dominio.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Pedidos
{
    public class ProductosPedido
    {
        public ProductosPedido()
        {
            id = -1;
            cantidad = -1;
            pedido = new Pedido();
            producto = new Producto();
        }
        public int id { get; set; }
        public Pedido pedido { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }
}
