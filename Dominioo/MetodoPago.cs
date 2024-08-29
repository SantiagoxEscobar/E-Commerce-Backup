using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Pedidos
{
    public class MetodoPago
    {
        public MetodoPago() 
        {
            id = -1;
            nombre = "";
            estado = true;
        }
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}
