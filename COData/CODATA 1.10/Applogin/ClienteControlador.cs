using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Applogin
{
    internal class ClienteControlador
    {
        public ClienteControlador() { }
        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conexion.strConexion); 
                if(conn.State==0)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Ins_cliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cli_Id", cliente.Cli_id);
                cmd.Parameters.AddWithValue("@Cli_Nommbre", cliente.Cli_nombre);
                cmd.Parameters.AddWithValue("@Cli_Edad", cliente.Cli_edad);
                cmd.Parameters.AddWithValue("@Cli_Email", cliente.Cli_email);
                cmd.Parameters.AddWithValue("@contraCliente", cliente.Pass);

                cmd.ExecuteNonQuery();
                return true;


            }
            catch { return false; }

        }
        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conexion.strConexion);
                if (conn.State == 0)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Act_cliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cli_Id", cliente.Cli_id);
                cmd.Parameters.AddWithValue("@Cli_Nommbre", cliente.Cli_nombre);
                cmd.Parameters.AddWithValue("@Cli_Edad", cliente.Cli_edad);
                cmd.Parameters.AddWithValue("@Cli_Email", cliente.Cli_email);
                cmd.Parameters.AddWithValue("@contraCliente", cliente.Pass);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch { return false; }


        }
        public Cliente OptenerCliente(int id)
        {
            Cliente cli= null;
            try
            {
                SqlConnection conn = new SqlConnection(Conexion.strConexion);
                SqlDataAdapter adatador = new SqlDataAdapter();
                DataTable datos = new DataTable();
                if (conn.State == 0)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Bus_cliente",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cli_Id",id);
                adatador.SelectCommand = cmd;
                adatador.Fill(datos);
                if(datos.Rows.Count > 0)
                {
                    cli = new Cliente
                    {
                        Cli_id = Convert.ToInt32(datos.Rows[0].ItemArray[0]),
                        Cli_nombre=datos.Rows[0].ItemArray[1].ToString(),
                        Cli_edad= Convert.ToInt32(datos.Rows[0].ItemArray[2]),
                        Cli_email= datos.Rows[0].ItemArray[3].ToString()
                    };
                
                }
                return cli;
            }
            catch 
            {
                return cli;    
            }


        }
        public bool BorarCliente(int id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conexion.strConexion);
                if (conn.State == 0)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Bor_cliente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cli_Id", id);
                cmd.Parameters.AddWithValue("@contraCliente",conn);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch { return false; }
        }
        public List<Cliente> ListatCliente()
        {
            SqlConnection conn= new SqlConnection(Conexion.strConexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable datos = new DataTable();
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                if (conn.State == 0)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("Lst_cliente",conn);
                cmd.CommandType = CommandType.StoredProcedure;
                adaptador.SelectCommand = cmd;
                adaptador.Fill(datos);
                if(datos.Rows.Count > 0)
                {
                    for(int i=0;i<datos.Rows.Count;i++)
                    {
                        clientes.Add(new Cliente
                        {
                            Cli_id =Convert.ToInt32( datos.Rows[i].ItemArray[0]),
                            Cli_nombre=datos.Rows[i].ItemArray[1].ToString(),
                            Cli_edad = Convert.ToInt32(datos.Rows[i].ItemArray[2]),
                            Cli_email= datos.Rows[i].ItemArray[3].ToString()


                        }
                        );
                    }
                }
                return clientes;
            }
            catch
            {
                return clientes;
            }
        }
    }
    
}
