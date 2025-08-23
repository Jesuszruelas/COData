Create Procedure InsertarCliente
@ClienteId int,
@ClienteNombre varchar (100),
@ClienteEdad int,
@ClienteMail varchar(100)

as

insert into Clientes values (@ClienteId, @ClienteNombre, @ClienteEdad, @ClienteMail) 