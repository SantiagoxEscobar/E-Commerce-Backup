using Dominio.Pedidos;
using Dominio.Productos;
using Dominio.Usuarios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaPedido
    {
        public List<Pedido> listar()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            AccesoDatos datosPedidos = new AccesoDatos();
            try
            {
                datosPedidos.SetearConsulta("select P.ID as PedidoID, MP.ID as MetodoPagoID, MP.Metodo_de_pago as MetodoPagoNombre, EP.ID as EstadoPedidoID, EP.Descripcion as EstadoPedidoNombre, U.ID as UsuarioID, U.Usuario as UsuarioNombre, Fecha from Pedidos P INNER JOIN Metodos_de_pago MP on MP.ID = P.ID_MetodoDePago INNER JOIN Estados_Pedido EP on EP.ID = P.ID_EstadosPedido INNER JOIN Usuarios U on u.ID = P.ID_Usuario");
                datosPedidos.EjecutarLectura();
                while (datosPedidos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    aux.metodoPago = new MetodoPago();
                    aux.estadoPedido = new EstadoPedido();
                    aux.usuario = new Usuario();

                    aux.id = (int)datosPedidos.Lector["PedidoID"];
                    aux.fecha = (DateTime)datosPedidos.Lector["Fecha"];

                    if (!Convert.IsDBNull(datosPedidos.Lector["MetodoPagoID"]))
                        aux.metodoPago.id = (int)datosPedidos.Lector["MetodoPagoID"];
                    if (!Convert.IsDBNull(datosPedidos.Lector["MetodoPagoNombre"]))
                        aux.metodoPago.nombre = (string)datosPedidos.Lector["MetodoPagoNombre"];

                    if (!Convert.IsDBNull(datosPedidos.Lector["EstadoPedidoID"]))
                        aux.estadoPedido.id = (int)datosPedidos.Lector["EstadoPedidoID"];
                    if (!Convert.IsDBNull(datosPedidos.Lector["EstadoPedidoNombre"]))
                        aux.estadoPedido.nombre = (string)datosPedidos.Lector["EstadoPedidoNombre"];

                    if (!Convert.IsDBNull(datosPedidos.Lector["UsuarioID"]))
                        aux.usuario.id = (int)datosPedidos.Lector["UsuarioID"];
                    if (!Convert.IsDBNull(datosPedidos.Lector["UsuarioNombre"]))
                        aux.usuario.usuario = (string)datosPedidos.Lector["UsuarioNombre"];

                    listaPedidos.Add(aux);
                }
                return listaPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPedidos.CerrarConexion();
            }
        }
        public Pedido listar(int id)
        {
            AccesoDatos datosPedidos = new AccesoDatos();
            try
            {
                datosPedidos.SetearConsulta("select * from Pedidos where ID = @id");
                datosPedidos.SetearParametro("@id", id);
                datosPedidos.EjecutarLectura();
                Pedido aux = new Pedido();
                while (datosPedidos.Lector.Read())
                {
                    LecturaMetodoPago lecturaMetodoPago = new LecturaMetodoPago();
                    LecturaEstadoPedido lecturaEstadoPedido = new LecturaEstadoPedido();
                    LecturaUsuario lecturaUsuario = new LecturaUsuario();

                    aux.id = (int)datosPedidos.Lector["ID"];
                    aux.fecha = (DateTime)datosPedidos.Lector["Fecha"];

                    aux.metodoPago = lecturaMetodoPago.listar((int)datosPedidos.Lector["ID_MetodoDePago"]);
                    aux.estadoPedido = lecturaEstadoPedido.listar((int)datosPedidos.Lector["ID_EstadosPedido"]);
                    aux.usuario = lecturaUsuario.listar((int)datosPedidos.Lector["ID_Usuario"]);
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPedidos.CerrarConexion();
            }
        }
        public void agregar(Pedido nuevo)
        {
            AccesoDatos datosPedidos = new AccesoDatos();
            try
            {
                datosPedidos.SetearConsulta("INSERT INTO Pedidos (ID_MetodoDePago, ID_EstadosPedido, ID_Usuario, Fecha) VALUES (@IDMetodoDePago, 1, @IDUsuario, GETDATE())");
                datosPedidos.SetearParametro("@IDMetodoDePago", nuevo.metodoPago.id);
                datosPedidos.SetearParametro("@IDUsuario", nuevo.usuario.id);
                datosPedidos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPedidos.CerrarConexion();
            }
        }
        public void modificarEstado(int id, int estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Pedidos SET ID_EstadosPedido = @IDEstadoPedido WHERE ID = @ID");
                datos.SetearParametro("@ID", id);
                datos.SetearParametro("@IDEstadoPedido", estado + 1);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void bajaLogica(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE Pedidos SET ID_EstadosPedido = @IDEstadoPedido WHERE ID = @ID");
                datos.SetearParametro("@ID", id);
                datos.SetearParametro("@IDEstadoPedido", 4);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public List<Pedido> listarxUsuario(int idUsuario)
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            AccesoDatos datosPedidos = new AccesoDatos();
            try
            {
                datosPedidos.SetearConsulta("SELECT * FROM Pedidos P WHERE P.ID_Usuario = @idUsuario");
                datosPedidos.SetearParametro("@idUsuario", idUsuario);
                datosPedidos.EjecutarLectura();
                while (datosPedidos.Lector.Read())
                {
                    Pedido aux = new Pedido();
                    LecturaMetodoPago lecturaMetodoPago = new LecturaMetodoPago();
                    LecturaEstadoPedido lecturaEstadoPedido = new LecturaEstadoPedido();
                    LecturaUsuario lecturaUsuario = new LecturaUsuario();

                    aux.id = (int)datosPedidos.Lector["ID"];
                    aux.fecha = (DateTime)datosPedidos.Lector["Fecha"];

                    aux.metodoPago = lecturaMetodoPago.listar((int)datosPedidos.Lector["ID_MetodoDePago"]);
                    aux.estadoPedido = lecturaEstadoPedido.listar((int)datosPedidos.Lector["ID_EstadosPedido"]);
                    aux.usuario = lecturaUsuario.listar((int)datosPedidos.Lector["ID_Usuario"]);

                    listaPedidos.Add(aux);
                }
                return listaPedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datosPedidos.CerrarConexion();
            }
        }
    }
}
