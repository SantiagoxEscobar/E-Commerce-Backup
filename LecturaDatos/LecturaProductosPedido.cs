using Dominio.Pedidos;
using Dominio.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDatos
{
    public class LecturaProductosPedido
    {
        public List<ProductosPedido> listar(int id)
        {
            List<ProductosPedido> lista = new List<ProductosPedido>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT PP.ID, P.Nombre, M.nombre as 'Marca', P.Precio, PP.Cantidad FROM Productos P INNER JOIN Marcas M ON M.ID = P.ID_Marca INNER JOIN Productos_x_pedido PP ON PP.ID_Producto = P.ID INNER JOIN Pedidos PE ON PE.ID = PP.ID_Pedido WHERE PP.ID_Pedido = @id ");
                datos.SetearParametro("@id", id);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    ProductosPedido aux = new ProductosPedido();
                    aux.pedido = new Pedido();
                    aux.producto = new Producto();

                    aux.id = (int)datos.Lector["ID"];
                    aux.cantidad = (int)datos.Lector["Cantidad"];

                    if(!Convert.IsDBNull(datos.Lector["Nombre"]))
                        aux.producto.nombre = (string)datos.Lector["Nombre"];

                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                        aux.producto.marca.nombre = (string)datos.Lector["Marca"];

                    if (!Convert.IsDBNull(datos.Lector["Precio"]))
                        aux.producto.precio = (decimal)datos.Lector["Precio"];

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
        public void agregar(ProductosPedido nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO Productos_x_pedido(ID_Pedido, ID_Producto, Cantidad) VALUES (@ID_Pedido, @ID_Producto, @Cantidad)");
                datos.SetearParametro("@ID_Pedido", nuevo.pedido.id);
                datos.SetearParametro("@ID_Producto", nuevo.producto.id);
                datos.SetearParametro("@Cantidad", nuevo.cantidad);
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
