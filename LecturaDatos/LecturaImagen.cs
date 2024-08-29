using Dominio.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaImagen
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Imagen");
                datos.EjecutarLectura();

                while(datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.id = (int)datos.Lector["ID"];
                    aux.imagenUrl = (string)datos.Lector["UrlImagen"];
                    aux.idProducto = (int)datos.Lector["ID_Producto"];
                    aux.tipo = (int)datos.Lector["Tipo_Imagen"];

                    lista.Add(aux);
                }

                return  lista; 
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
        public List<Imagen> listar(int id)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Imagen where ID_Producto = " + id.ToString() );
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.id = (int)datos.Lector["ID"];
                    aux.imagenUrl = (string)datos.Lector["UrlImagen"];
                    aux.idProducto = (int)datos.Lector["ID_Producto"];
                    aux.tipo = (int)datos.Lector["Tipo_Imagen"];

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

        public void agregarLista(List<Imagen> lista)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (Imagen imagen in lista) 
                {
                    LecturaImagen lecturaImagen = new LecturaImagen();
                    lecturaImagen.agregar(imagen);
                }
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
        public void agregar(Imagen nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into Imagen (UrlImagen, ID_Producto, Tipo_Imagen) values (@urlimagen, @idproducto, @tipoimagen)");
                datos.SetearParametro("@urlimagen", nuevo.imagenUrl);
                datos.SetearParametro("@idproducto", nuevo.idProducto);
                datos.SetearParametro("@tipoimagen", nuevo.tipo);
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
        } //agrega una imagen a db pasandole el objeto por parametro
        public void modificar(Imagen nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Imagen set UrlImagen = @urlimagen, ID_Producto = @idproducto, Tipo_Imagen = @tipoimagen where ID = @id");
                datos.SetearParametro("@urlimagen",nuevo.imagenUrl);
                datos.SetearParametro("@idproducto", nuevo.idProducto);
                datos.SetearParametro("@tipoimagen", nuevo.tipo);
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
        } // modifica una imagen
        public void eliminarFisica(Imagen nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete from Imagen where ID = @ID");
                datos.SetearParametro("@ID", nuevo.id);
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
        } // elimina la imagen


        public List<Imagen> listarPublicidad()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select * from Imagen where Tipo_Imagen = 3 and Estado = 1");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.id = (int)datos.Lector["ID"];
                    aux.imagenUrl = (string)datos.Lector["UrlImagen"];
                    aux.tipo = (int)datos.Lector["Tipo_Imagen"];

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

        public void AgregarPublicidad(string imagenUrl)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into Imagen(UrlImagen, Tipo_Imagen, Estado) values (@urlimagen, 3, 1)");
                datos.SetearParametro("@urlimagen", imagenUrl);
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

        public void ActualizarPublicidad(int id, string imagenUrl)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Imagen set UrlImagen = @urlimagen where ID = @id");
                datos.SetearParametro("@urlimagen", imagenUrl);
                datos.SetearParametro("@id", id);
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
        public void eliminarPublicidad(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Imagen set Estado = 0 where ID = @id");
                datos.SetearParametro("@ID", id);
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
