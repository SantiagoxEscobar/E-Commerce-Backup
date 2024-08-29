using Dominio.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaEstadoPedido
    {
        public List<EstadoPedido> listar()
        {
            List<EstadoPedido> lista = new List<EstadoPedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Estados_Pedido");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoPedido aux = new EstadoPedido();
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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
        public EstadoPedido listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select * from Estados_Pedido where ID = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarLectura();
                EstadoPedido aux = new EstadoPedido();
                while(datos.Lector.Read())
                {
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Descripcion"];
                        
                }
                return aux;
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
        public void agregar(EstadoPedido nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into Estados_Pedido (Descripcion) values (@descripcion)");
                datos.SetearParametro("@descripcion", nuevo.nombre);
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
        public void modificar(EstadoPedido nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Estados_Pedido set Descripcion = @descripcion where ID = @id");
                datos.SetearParametro("@descripcion", nuevo.nombre);
                datos.SetearParametro("@id", nuevo.id);
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
        public void eliminarFisica(EstadoPedido nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete Estados_Pedido where ID = @id");
                datos.SetearParametro("@id", nuevo.id);
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
    }
}
