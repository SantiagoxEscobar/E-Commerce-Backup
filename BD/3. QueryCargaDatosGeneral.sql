use TPC_EQUIPO_5

 insert into Marcas (nombre) values
 ('AMD'),
 ('Asrock'),
 ('Corsair'),
 ('XFX');

 insert into Categorias (nombre) values
 ('Procesadores'),
 ('Motherboards'),
 ('Memorias RAM'),
 ('Placa de Videos'),
 ('Almacenamiento'),
 ('Fuentes'),
 ('Gabinetes'),
 ('Monitores'),
 ('Perifericos(mouse/teclado/parlantes/mousepad)');

 insert into Tipos_Imagenes (Tipo) values
 ('Producto'),
 ('Marca'),
 ('Publicidad');

 insert into Productos (ID_Categoria,ID_Marca,Nombre,Descripcion,Precio,stock) values
 (1,1,'Procesador AMD RYZEN 5 3600 4.2GHz Turbo AM4 Wraith Stealth Cooler','lindo Procesador',1300,10),
 (2,2,'Mother Asrock B450M-HDV 4.0 AM4 HDMI M.2','lindo placa, anda bien ',78800,5),
 (3,3,'Memoria Corsair DDR4 8GB 3200Mhz Vengeance LPX Black CL16','Muy rapida',29150,2),
 (4,4,'Placa de Video XFX Radeon RX 580 8GB GDDR5 GTS 2048SP','Buena relacion calidad-precio',179240,1);

 insert into Imagen (UrlImagen,ID_Producto,Tipo_Imagen) values
 ('https://imagenes.compragamer.com/productos/compragamer_Imganen_general_16749_Procesador_AMD_RYZEN_5_3600_4.2GHz_Turbo_AM4_Wraith_Stealth_Cooler_f8ab4915-grn.jpg',1,1),
 ('https://imagenes.compragamer.com/productos/compragamer_Imganen_general_16755_Procesador_AMD_RYZEN_5_3600_4.2GHz_Turbo_AM4_Wraith_Stealth_Cooler_116595fc-grn.jpg',1,1),
 ('https://asrock.com/mb/photo/B450M-HDV(L1).png',2,1),
 ('https://fullh4rd.com.ar/img/productos/4/memoria-16gb-2x8gb-ddr4-3200-corsair-vengeance-lpx-black-0.jpg',3,1),
 ('https://m.media-amazon.com/images/I/61EvAMKJQ6L._AC_SX679_.jpg',4,1);

 INSERT INTO Imagen(UrlImagen, Tipo_Imagen, Estado) values
 ('https://i.imgur.com/PSPDiah.jpeg', 3, 1),
 ('https://i.imgur.com/dZQLSHU.jpeg', 3, 1),
 ('https://i.imgur.com/oYcqOx6.jpeg', 3, 1),
 ('https://i.imgur.com/wxnSZ3u.jpeg', 3, 1);

 INSERT INTO Metodos_de_pago(Metodo_de_pago) values
 ('Transferencia'),
 ('MercadoPago'),
 ('Otro');

 INSERT INTO Estados_Pedido(Descripcion) values
 ('Preparación'),
 ('Enviado'),
 ('Completado'),
 ('Cancelado');

 INSERT INTO Datos_Personales(Nombres, Apellidos, Email, Telefono, Direccion, IDCiudad) values
 ('Roberto', 'Carlos', 'gemasaxlrose@gmail.com', '123456789', 'Av Falsa 123', 46),
 ('Radamel', 'Falcao', 'rfalcao@mail.com', '987654321', 'Av Colombia 321', 48),
 ('Emiliano', 'Martinez', 'emartinez@mail.com', '1122334455', 'Av Argentina 333', 90);

 INSERT INTO Usuarios(Usuario, Clave, Administrar, IDDatos_Personales) values
 ('User001', '1234', 0, 1),
 ('User002', '1234', 0, 2),
 ('Admin001', 'Huevo123', 1, 3);