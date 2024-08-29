using Dominio.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaMetodoPago
    {
        public List<MetodoPago> listar()
        {
            List<MetodoPago> lista = new List<MetodoPago>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Metodos_de_pago");
                datos.EjecutarLectura();

                while(datos.Lector.Read())
                {
                    MetodoPago aux = new MetodoPago();
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Metodo_de_pago"];

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
        public MetodoPago listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Metodos_de_pago where ID = "+ id.ToString());
                datos.EjecutarLectura();

                MetodoPago aux = new MetodoPago();
                while (datos.Lector.Read())
                {
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Metodo_de_pago"];
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
        public void agregar(MetodoPago nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into Metodos_de_pago (Metodo_de_pago) values (@metodopago)");
                datos.SetearParametro("@metodopago", nuevo.nombre);
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
        public void modificar(MetodoPago nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Metodos_de_pago set Metodo_de_pago = @metodopago where ID = @id");
                datos.SetearParametro("@metodopago", nuevo.nombre);
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
        public void eliminarFisica(MetodoPago nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete Metodos_de_pago where ID = @id");
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
