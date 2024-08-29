using Dominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaDatosUsuario
    {
        public List<DatosUsuario> listar()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                List<DatosUsuario> lista = new List<DatosUsuario>();
                datos.SetearConsulta("select * from Datos_Personales");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    DatosUsuario aux = new DatosUsuario();
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Nombres"];
                    aux.apellido = (string)datos.Lector["Apellidos"];
                    if (!Convert.IsDBNull(datos.Lector["Email"]))
                        aux.email = (string)datos.Lector["Email"];

                    if (!Convert.IsDBNull(datos.Lector["Telefono"]))
                        aux.telefono = (string)datos.Lector["Telefono"];

                    if (!Convert.IsDBNull(datos.Lector["Direccion"]))
                        aux.direccion = (string)datos.Lector["Direccion"];

                    if (!Convert.IsDBNull(datos.Lector["IDCiudad"]))
                        aux.ciudad.id = (int)(datos.Lector["IDCiudad"]);

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
        public DatosUsuario listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                DatosUsuario aux = new DatosUsuario();
                datos.SetearConsulta("select * from Datos_Personales where ID = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {                   
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Nombres"];
                    aux.apellido = (string)datos.Lector["Apellidos"];
                    if (!Convert.IsDBNull(datos.Lector["Email"]))
                        aux.email = (string)datos.Lector["Email"];

                    if (!Convert.IsDBNull(datos.Lector["Telefono"]))
                        aux.telefono = (string)datos.Lector["Telefono"];

                    if (!Convert.IsDBNull(datos.Lector["Direccion"]))
                        aux.direccion = (string)datos.Lector["Direccion"];

                    if (!Convert.IsDBNull(datos.Lector["IDCiudad"]))
                        aux.ciudad.id = (int)(datos.Lector["IDCiudad"]);
                        LecturaCiudad lecturaCiudad = new LecturaCiudad();
                        aux.ciudad = lecturaCiudad.listar(aux.ciudad.id);
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
        public void agregar(DatosUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into Datos_Personales(Nombres,Apellidos,Email) values (@nombre, @apellido, @email)");
                datos.SetearParametro("@nombre", nuevo.nombre);
                datos.SetearParametro("@apellido", nuevo.apellido);
                datos.SetearParametro("@email", nuevo.email);
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
        public void modificar(DatosUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into Datos_Personales(Nombres,Apellidos,Email,Telefono,Direccion,IDCiudad) values (@nombre,@apellido,@email,@telefono,@direccion,@idciudad)");
                datos.SetearParametro("@nombre", nuevo.nombre);
                datos.SetearParametro("@apellido", nuevo.apellido);
                datos.SetearParametro("@email", nuevo.email);
                datos.SetearParametro("@telefono", nuevo.telefono);
                datos.SetearParametro("@direccion", nuevo.direccion);
                datos.SetearParametro("@idciudad", nuevo.ciudad.id);
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
        public void modificarDatos(DatosUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Datos_Personales set Nombres = @nombre, Apellidos = @apellido, Email = @email, Telefono = @telefono where ID = @id");
                datos.SetearParametro("@nombre", nuevo.nombre);
                datos.SetearParametro("@apellido", nuevo.apellido);
                datos.SetearParametro("@email", nuevo.email);
                datos.SetearParametro("@telefono", nuevo.telefono);
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
        public void modificarDireccion(DatosUsuario nuevo)
        {
                AccesoDatos datosciudad = new AccesoDatos();
                AccesoDatos datos = new AccesoDatos();
                int idciudad = new int();
            try
            {               
                datosciudad.SetearConsulta("select c.ID from Ciudades C where C.IDProvincia = @idprovincia and C.Nombre= @nombreciudad");
                datosciudad.SetearParametro("@idprovincia", nuevo.ciudad.provincia.id);
                datosciudad.SetearParametro("@nombreciudad", nuevo.ciudad.nombre);
                datosciudad.EjecutarLectura();
                while (datosciudad.Lector.Read())
                {

                    idciudad = (int)(datosciudad.Lector["ID"]);

                }
                
                datosciudad.CerrarConexion();


                

                datos.SetearConsulta("update Datos_Personales set Direccion = @Direccion, IDCiudad = @IDCiudad where ID = @id");
                datos.SetearParametro("@Direccion", nuevo.direccion);
                datos.SetearParametro("@IDCiudad", idciudad);
                datos.SetearParametro("@id", nuevo.id);
                datos.ejecutarAccion();
                nuevo.ciudad.id = idciudad;
                
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
        public void eliminarFisica(DatosUsuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("delete Datos_Personales where ID = @id");
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
