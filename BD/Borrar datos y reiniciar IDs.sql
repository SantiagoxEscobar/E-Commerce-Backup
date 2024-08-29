-- borrar datos y reiniciar IDS
USE TPC_EQUIPO_5

 delete Productos_x_pedido
 delete Imagen
 delete Productos
 delete Marcas
 delete Categorias
 delete Pedidos
 delete Tipos_Imagenes
 delete Estados_Pedido
 delete Metodos_de_pago
 delete Usuarios
 delete Datos_Personales

 DBCC CHECKIDENT('Productos_x_pedido' , RESEED, 0)
 DBCC CHECKIDENT('Imagen' , RESEED, 0)
 DBCC CHECKIDENT('Productos' , RESEED, 0)
 DBCC CHECKIDENT('Marcas' , RESEED, 0)
 DBCC CHECKIDENT('Categorias' , RESEED, 0)
 DBCC CHECKIDENT('Pedidos' , RESEED, 0)
 DBCC CHECKIDENT('Tipos_Imagenes' , RESEED, 0)
 DBCC CHECKIDENT('Estados_Pedido' , RESEED, 0)
 DBCC CHECKIDENT('Metodos_de_pago' , RESEED, 0)
 DBCC CHECKIDENT('Usuarios' , RESEED, 0)
 DBCC CHECKIDENT('Datos_Personales' , RESEED, 0)