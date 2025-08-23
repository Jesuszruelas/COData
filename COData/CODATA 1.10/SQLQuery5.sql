CREATE PROCEDURE BuscarCliente
@clienteId int
as
Select * from Clientes where clienteId=@clienteId

