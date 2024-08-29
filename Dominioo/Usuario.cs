﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Pedidos;

namespace Dominio.Usuarios
{
    public class Usuario
    {
        public Usuario()
        {
            id = -1;
            usuario = "";
            password = "";
            dato = new DatosUsuario();
            admin = false;
            pedidos = new List<Pedido>();
            estado = true;
        }
        public int id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public DatosUsuario dato { get; set; }
        public bool admin { get; set; }
        public List<Pedido> pedidos { get; set; }
        public bool estado { get; set; }
    }
}
