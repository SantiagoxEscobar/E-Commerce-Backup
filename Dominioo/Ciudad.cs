using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Usuarios
{
    public class Ciudad
    {
        public Ciudad()
        {
            id = -1;
            nombre = "";
            provincia = new Provincia();
            estado = true;
        }
        public int id { get; set; }
        public string nombre { get; set; }
        public Provincia provincia { get; set; }
        public bool estado { get; set; }
    }
}
