using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Productos;
using Dominio.Usuarios;

namespace Dominio.Pedidos
{
    public class Pedido
    {
        public Pedido() 
        {
            id = -1;
            usuario = new Usuario();
            fecha = new DateTime();
            estadoPedido = new EstadoPedido();
            metodoPago = new MetodoPago();
            estado = true;
        }
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public DateTime fecha { get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public MetodoPago metodoPago { get; set; }
        public bool estado { get; set; }
    }
}
