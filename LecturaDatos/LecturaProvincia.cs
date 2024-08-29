using Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaProvincia
    {
        public List<Provincia> listar()
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Provincias");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia aux = new Provincia();
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Nombre"];

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
        public int listarlistarporidciudad(int idciudad)
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select P.ID from Provincias P inner join Ciudades C on C.IDProvincia=P.ID where C.ID = @idciudad");
                datos.SetearParametro("@idciudad", idciudad);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    idciudad = (int)datos.Lector["ID"];
                    

                    
                }

                return idciudad;
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
        public Provincia listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Provincias where ID = @id");
                datos.SetearParametro("@id",id);
                datos.EjecutarLectura();

                Provincia aux = new Provincia();
                while (datos.Lector.Read())
                {
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Nombre"];

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
        public void agregar(Provincia nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into Provincias (Nombre) values (@nombre)");
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
        public void modificar(Provincia nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Provincias set Nombre = @nombre where ID = @id");
                datos.SetearParametro("@nombre", nuevo.nombre);
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
        public void eliminar(Provincia nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete Provincias where ID = @id");
                datos.SetearParametro("id", nuevo.id);
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
