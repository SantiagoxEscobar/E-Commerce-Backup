using Dominio.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaMarca
    {
        public List<Marca> listar(bool SoloActivos = false) 
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if( SoloActivos )
                {
                    datos.SetearConsulta("select * from Marcas WHERE Estado = 1");
                }
                else
                {
                    datos.SetearConsulta("select * from Marcas");
                }
                datos.EjecutarLectura();
                while(datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.estado = (bool)datos.Lector["estado"];

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
        public Marca listar(int id)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Marcas where ID = "+ id.ToString());
                datos.EjecutarLectura();
                Marca aux = new Marca();
                while (datos.Lector.Read())
                {
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.estado = (bool)datos.Lector["estado"];
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
        public void agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into Marcas (nombre) values (@nombre)");
                datos.SetearParametro("@nombre",nuevo.nombre);
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
        public void modificar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update Marcas set nombre = @nombre, estado = @estado where ID = @id");
                datos.SetearParametro("@nombre", nuevo.nombre);
                datos.SetearParametro("@estado", nuevo.estado ? 1 : 0);
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
        public void eliminarFisica(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete Marcas where ID = @id");
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
