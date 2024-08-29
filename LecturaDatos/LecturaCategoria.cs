using Dominio.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaCategoria
    {
        public List<Categoria> listar(bool SoloActivos = false)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(SoloActivos)
                {
                    datos.SetearConsulta("select * from Categorias WHERE Estado = 1");
                }
                else
                {
                    datos.SetearConsulta("select * from Categorias");
                }
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
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
        public Categoria listar(int id)
        {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Categorias where ID = " + id.ToString());
                datos.EjecutarLectura();
                Categoria aux = new Categoria();
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
        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into Categorias (nombre) values (@nombre)");
                datos.SetearParametro("@nombre", nuevo.nombre);
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
        public void modificar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update Categorias set Nombre = @nombre, Estado = @estado where ID = @id");
                datos.SetearParametro("@nombre", nuevo.nombre);
                datos.SetearParametro("@id", nuevo.id);
                datos.SetearParametro("@estado", nuevo.estado ? 1 : 0);
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
        public void eliminarFisica(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete Categorias where ID = @id");
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
