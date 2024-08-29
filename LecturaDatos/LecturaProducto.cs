using Dominio.Productos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaProducto
    {
        public List<Producto> listar(bool soloActivos = false) //return listaProductos
        {
            List<Producto> listaProductos = new List<Producto>();
            AccesoDatos datosProductos = new AccesoDatos();
            //AccesoDatos datosImagenes = new AccesoDatos();
            try
            {
                if(soloActivos)
                {
                    datosProductos.SetearConsulta("SELECT P.ID as ProductoID, P.Nombre as ProductoNombre, P.Descripcion as ProductoDescripcion, P.Stock as ProductoStock, P.Precio as ProductoPrecio, P.Estado as EstadoProducto , M.ID as MarcaID, M.nombre as MarcaNombre, C.ID as CategoriaID, C.nombre as CategoriaNombre FROM Productos P INNER JOIN Marcas M on P.ID_Marca = M.ID INNER JOIN Categorias C on P.ID_Categoria = C.ID WHERE P.Estado = 1");
                }
                else
                {
                    datosProductos.SetearConsulta("SELECT P.ID as ProductoID, P.Nombre as ProductoNombre, P.Descripcion as ProductoDescripcion, P.Stock as ProductoStock, P.Precio as ProductoPrecio, P.Estado as EstadoProducto , M.ID as MarcaID, M.nombre as MarcaNombre, C.ID as CategoriaID, C.nombre as CategoriaNombre FROM Productos P INNER JOIN Marcas M on P.ID_Marca = M.ID INNER JOIN Categorias C on P.ID_Categoria = C.ID");         
                }
                datosProductos.EjecutarLectura();
                while(datosProductos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.marca = new Marca();
                    aux.categoria = new Categoria();
                    aux.imagenes = new List<Imagen>();
                    LecturaImagen lecturaImagen = new LecturaImagen();

                    aux.id = (int)datosProductos.Lector["ProductoID"];
                    aux.nombre = (string)datosProductos.Lector["ProductoNombre"];
                    aux.descripcion = (string)datosProductos.Lector["ProductoDescripcion"];
                    aux.stock = (int)datosProductos.Lector["ProductoStock"];
                    aux.precio = (decimal)datosProductos.Lector["ProductoPrecio"];
                    aux.estado = (bool)datosProductos.Lector["EstadoProducto"];

                    //Carga de Marca y categoria
                    if (!Convert.IsDBNull(datosProductos.Lector["MarcaID"]))
                        aux.marca.id = (int)datosProductos.Lector["MarcaID"];
                    if (!Convert.IsDBNull(datosProductos.Lector["MarcaNombre"]))
                        aux.marca.nombre = (string)datosProductos.Lector["MarcaNombre"];

                    if (!Convert.IsDBNull(datosProductos.Lector["CategoriaID"]))
                        aux.categoria.id = (int)datosProductos.Lector["CategoriaID"];
                    if (!Convert.IsDBNull(datosProductos.Lector["CategoriaNombre"]))
                        aux.categoria.nombre = (string)datosProductos.Lector["CategoriaNombre"];

                    //Carga de Imagenes + imagenprincipal (la que sale en la tarjeta)
                    aux.imagenes = lecturaImagen.listar(aux.id);

                    if (aux.imagenes.Count != 0)
                    {
                        Random random = new Random();
                        int cantidadImagenes = aux.imagenes.Count;
                        int numeroAleatorio = random.Next(0, cantidadImagenes);

                        aux.imagenPrincipal = aux.imagenes[numeroAleatorio].imagenUrl;
                    }

                    listaProductos.Add(aux);
                }

                return listaProductos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datosProductos.CerrarConexion();
            }
        }
        public Producto listar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select * from Productos where ID = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarLectura();
                Producto aux = new Producto();
                while(datos.Lector.Read())
                {
                    LecturaImagen lecturaImagen = new LecturaImagen();
                    LecturaCategoria lecturaCategoria = new LecturaCategoria();
                    LecturaMarca lecturaMarca = new LecturaMarca();
                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.stock = (int)datos.Lector["Stock"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.estado = (bool)datos.Lector["Estado"];
                    aux.marca.id = (int)datos.Lector["ID_Marca"];
                    aux.categoria.id = (int)datos.Lector["ID_Categoria"];
                    aux.marca = lecturaMarca.listar(aux.marca.id);
                    aux.categoria = lecturaCategoria.listar(aux.categoria.id);
                    aux.imagenes = lecturaImagen.listar(id);
                    if(aux.imagenes.Count > 0)
                    {
                        aux.imagenPrincipal = aux.imagenes[0].imagenUrl;
                    }
                    else
                    {
                        aux.imagenPrincipal = "";
                    }


                }
                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }
        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into Productos (ID_Categoria, ID_Marca,Nombre, Descripcion, Precio,Stock)\r\nvalues (@IDCategoria,@IDMarca,@Nombre,@Descripcion, @Precio, @Stock)");
                datos.SetearParametro("@IDCategoria", nuevo.categoria.id);
                datos.SetearParametro("@IDMarca", nuevo.marca.id);
                datos.SetearParametro("@Nombre", nuevo.nombre);
                datos.SetearParametro("@Descripcion", nuevo.descripcion);
                datos.SetearParametro("@Precio", nuevo.precio);
                datos.SetearParametro("@Stock", nuevo.stock);
                datos.ejecutarAccion();
                //Para encontrar el ID del producto que recien creamos
                List<Producto> lista = new List<Producto>();
                LecturaProducto lecturaProducto = new LecturaProducto();
                Producto aux = new Producto();
                lista = lecturaProducto.listar();
                aux = lista.Last();
                //Para darle el IDProducto a las imagenes que contenga la lista
                foreach (Imagen img in nuevo.imagenes) 
                {
                    img.idProducto = aux.id;
                    img.tipo = 1;
                }
                //Cargar las imagenes
                LecturaImagen lecturaImagen = new LecturaImagen();
                lecturaImagen.agregarLista(nuevo.imagenes);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        } //agrega un nuevo producto a db pasandolo el objeto por parametro
        public void modificar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update Productos set ID_Categoria = @IDCategoria,  ID_Marca = @IDMarca , Nombre = @Nombre , Descripcion = @Descripcion, Precio = @Precio , Stock = @Stock, Estado = @Estado  where ID = @ID");
                datos.SetearParametro("@IDCategoria", nuevo.categoria.id);
                datos.SetearParametro("@IDMarca", nuevo.marca.id);
                datos.SetearParametro("@Nombre", nuevo.nombre);
                datos.SetearParametro("@Descripcion", nuevo.descripcion);
                datos.SetearParametro("@Precio", nuevo.precio);
                datos.SetearParametro("@Stock", nuevo.stock);
                datos.SetearParametro("@ID", nuevo.id);
                datos.SetearParametro("@Estado", nuevo.estado);
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
        } //modifica un producto en db pasandole el objeto por parametro
        public void eliminarFisica(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete from Productos where ID = @ID");
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
        }//elimina el producto en db pasandole el objeto por parametro
        //agregar baja logica
        public List<Producto> filtradoAvanzado(string campo, string criterio , string filtro , string estado )
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Productos.ID, Productos.Nombre, Productos.Descripcion, Productos.Precio, Productos.Stock, Marcas.nombre as marca, Categorias.nombre as categoria, Productos.Estado, Marcas.ID as marcaid, Categorias.ID as categoriasid from Productos inner join marcas on Marcas.ID = Productos.ID_Marca inner join Categorias on Categorias.ID = Productos.ID_Categoria where ";
                switch(campo)
                {
                    case "Producto":
                        switch(criterio)
                        {
                            case "Comienza por":
                                consulta += "Productos.Nombre like '"+filtro+"%'";
                                break;
                            case "Termina Con":
                                consulta += "Productos.Nombre like '%"+filtro+"'";
                                break;
                            case "Contiene":
                                consulta += "Productos.Nombre like '%"+filtro+"%'";
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza por":
                                consulta += "Productos.Descripcion like '"+ filtro +"%'";
                                break;
                            case "Termina Con":
                                consulta += "Productos.Descripcion like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Productos.Descripcion like  '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza por":
                                consulta += "Categorias.Nombre like '" + filtro + "%'";
                                break;
                            case "Termina Con":
                                consulta += "Categorias.Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Categorias.Nombre like  '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza por":
                                consulta += "Marcas.Nombre like '" + filtro + "%'";
                                break;
                            case "Termina Con":
                                consulta += "Marcas.Nombre like '%" + filtro + "'";
                                break;
                            case "Contiene":
                                consulta += "Marcas.Nombre like  '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Productos.Precio >" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Productos.Precio <" + filtro;
                                break;
                            case "Igual a":
                                consulta += "Productos.Precio =" + filtro;
                                break;
                        }
                        break;
                    case "Stock":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Productos.Stock >" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Productos.Stock <" + filtro;
                                break;
                            case "Igual a":
                                consulta += "Productos.Stock =" + filtro;
                                break;
                        }
                        break;
                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.marca = new Marca();
                    aux.categoria = new Categoria();
                    aux.imagenes = new List<Imagen>();
                    LecturaImagen lecturaImagen = new LecturaImagen();

                    aux.id = (int)datos.Lector["ID"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.stock = (int)datos.Lector["Stock"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.estado = (bool)datos.Lector["Estado"];

                    //Carga de Marca y categoria
                    if (!Convert.IsDBNull(datos.Lector["marcaid"]))
                        aux.marca.id = (int)datos.Lector["marcaid"];
                    if (!Convert.IsDBNull(datos.Lector["marca"]))
                        aux.marca.nombre = (string)datos.Lector["marca"];

                    if (!Convert.IsDBNull(datos.Lector["categoriasid"]))
                        aux.categoria.id = (int)datos.Lector["categoriasid"];
                    if (!Convert.IsDBNull(datos.Lector["categoria"]))
                        aux.categoria.nombre = (string)datos.Lector["categoria"];

                    //Carga de Imagenes + imagenprincipal (la que sale en la tarjeta)
                    aux.imagenes = lecturaImagen.listar(aux.id);

                    if (aux.imagenes.Count != 0)
                    {
                        Random random = new Random();
                        int cantidadImagenes = aux.imagenes.Count;
                        int numeroAleatorio = random.Next(0, cantidadImagenes);

                        aux.imagenPrincipal = aux.imagenes[numeroAleatorio].imagenUrl;
                    }

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
    }

}
