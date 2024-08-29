using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Usuarios
{
    public class DatosUsuario
    {
        public DatosUsuario()
        {
            id = -1;
            nombre = "";
            apellido = "";
            email = "";
            telefono = -1;
            direccion = "";
            ciudad = new Ciudad();
        }
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public Ciudad ciudad { get; set; }
    }
}
