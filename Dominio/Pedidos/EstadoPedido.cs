using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Pedidos
{
    public class EstadoPedido
    {
        public EstadoPedido() 
        {
            id = -1;
            nombre = "";
        }
        public int id { get; set; }
        public string nombre { get; set;}
    }
}
