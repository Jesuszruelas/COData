CREATE PROCEDURE BorrarCliente
@clienteId int
as
Delete from Clientes where clienteId=@clienteId