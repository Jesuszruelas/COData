Create Procedure ActualizarCliente
@ClienteId int,
@ClienteNombre varchar (100),
@ClienteEdad int,
@ClienteMail varchar(100)

as

update Clientes
set
ClienteNombre = @ClienteNombre,
ClienteEdad = @ClienteEdad,
ClienteMail = @ClienteMail

Where ClienteId = @ClienteId