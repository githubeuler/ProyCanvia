using Canvia.Business.Entities;
using Canvia.Data.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Data.Implementation
{
    public class UsuarioDAO : IUsuarioDAO
    {
        //public int Codigo { get; set; }
        //public PersonaBE Persona { get; set; }
        //public string Usuario { get; set; }
        //public string Password { get; set; }
        //public EstadoBE Estado { get; set; }

        private static string cn = ConfigurationManager.ConnectionStrings["Apps"].ConnectionString;
        public ResultBE ActualizarUsuario(UsuarioBE usuario)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_ACTUALIZAR_USUARIO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = usuario.Codigo;
                command.Parameters.Add("@Persona", SqlDbType.Int).Value = usuario.Persona.Codigo;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = usuario.Usuario;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = usuario.Password;
                command.Parameters.Add("@Estado", SqlDbType.Int).Value = usuario.Estado.Codigo;
                

                try
                {
                    connection.Open();
                    result.CodeResult = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    result.CodeResult = -1;
                    result.MessageResult = ex.Message.ToString();
                }
                connection.Close();
            }

            return result;
        }

        public ResultBE EliminarUsuario(int codigo)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_ELIMINAR_USUARIO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;

                try
                {
                    connection.Open();
                    result.CodeResult = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    result.CodeResult = -1;
                    result.MessageResult = ex.Message.ToString();
                }
                connection.Close();
            }

            return result;
        }

        public ResultBE InsertarUsuario(UsuarioBE usuario)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_INSERTAR_USUARIO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Persona", SqlDbType.Int).Value = usuario.Persona.Codigo;
                command.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = usuario.Usuario;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 100).Value = usuario.Password;
                command.Parameters.Add("@CodigoUsuario", SqlDbType.Int);
                command.Parameters["@CodigoUsuario"].Direction = ParameterDirection.Output; ;

                try
                {
                    connection.Open();
                    result.CodeResult = command.ExecuteNonQuery();
                    usuario.Codigo = Convert.ToInt32(command.Parameters["@CodigoUsuario"].Value);
                    result.MessageResult = usuario.Codigo.ToString();
                    if (usuario.Codigo == -1)
                    {
                        result.CodeResult = -1;
                        result.MessageResult = "El usuario con  " + usuario.Usuario + " ya existe!";
                    }
                }
                catch (Exception ex)
                {

                    result.CodeResult = -1;
                    result.MessageResult = ex.Message.ToString();
                }
                connection.Close();
            }

            return result;
        }

        public List<UsuarioBE> ListarUsuario(PaginadoBE paginado, ref int totalFilas)
        {
            List<UsuarioBE> lstUsuario = new List<UsuarioBE>();
            UsuarioBE objUsuario;
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_LISTAR_USUARIO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Page", SqlDbType.Int).Value = paginado.NumeroPagina;
                command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = paginado.NumeroFilas;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        objUsuario = new UsuarioBE();
                        objUsuario.Codigo = Convert.ToInt32(reader[0]);
                        objUsuario.Persona = new PersonaBE();
                        objUsuario.Persona.Codigo = Convert.ToInt32(reader[1]);
                        objUsuario.Usuario = Convert.ToString(reader[2]);
    
                        objUsuario.Estado = new EstadoBE();
                        objUsuario.Estado.Codigo = Convert.ToInt32(reader[3]);
                        lstUsuario.Add(objUsuario);
                    }


                    reader.NextResult();

                    while (reader.Read())
                    {
                        totalFilas = Convert.ToInt32(reader[0]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                }

                command.Dispose();
                connection.Close();
            }

            return lstUsuario;
        }

        public UsuarioBE ObtenerUsuario(int codigo)
        {
            UsuarioBE objUsuario = new UsuarioBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_OBTENER_USUARIO", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        objUsuario = new UsuarioBE();
                        objUsuario.Codigo = Convert.ToInt32(reader[0]);
                        objUsuario.Persona = new PersonaBE();
                        objUsuario.Persona.Codigo = Convert.ToInt32(reader[1]);
                        objUsuario.Usuario = Convert.ToString(reader[2]);
                        objUsuario.Password = Convert.ToString(reader[3]);

                        objUsuario.Estado = new EstadoBE();
                        objUsuario.Estado.Codigo = Convert.ToInt32(reader[4]);


                    }
                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }

            return objUsuario;
        }
    }
}
