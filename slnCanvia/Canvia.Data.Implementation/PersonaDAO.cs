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
    public class PersonaDAO : IPersonaDAO
    {
        private static string cn = ConfigurationManager.ConnectionStrings["Apps"].ConnectionString;
        public ResultBE ActualizarPersona(PersonaBE persona)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_ACTUALIZAR_PERSONA", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = persona.Codigo;
                command.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = persona.Nombre;
                command.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 100).Value = persona.ApellidoPaterno;
                command.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 100).Value = persona.ApellidoMaterno;
                command.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = persona.TipoDocumento.Codigo;
                command.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 100).Value = persona.NumeroDocumento;
                command.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = Convert.ToDateTime(persona.sFechaNacimiento);
                command.Parameters.Add("@Estado", SqlDbType.Int).Value = persona.Estado.Codigo;

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

        public ResultBE EliminarPersona(int codigo)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_ELIMINAR_PERSONA", connection);
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

        public ResultBE InsertarPersona(PersonaBE persona)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_INSERTAR_PERSONA", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = persona.Nombre;
                command.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 100).Value = persona.ApellidoPaterno;
                command.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 100).Value = persona.ApellidoMaterno;
                command.Parameters.Add("@TipoDocumento", SqlDbType.Int).Value = persona.TipoDocumento.Codigo;
                command.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 100).Value = persona.NumeroDocumento;
                command.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = Convert.ToDateTime(persona.sFechaNacimiento);
                command.Parameters.Add("@CodigoPersona", SqlDbType.Int);
                command.Parameters["@CodigoPersona"].Direction = ParameterDirection.Output; 

                try
                {
                    connection.Open();
                    result.CodeResult = command.ExecuteNonQuery();
                    persona.Codigo = Convert.ToInt32(command.Parameters["@CodigoPersona"].Value);
                    if (persona.Codigo == -1)
                    {
                        result.CodeResult = -1;
                        result.MessageResult = "La persona con numero de documento " + persona.NumeroDocumento +" ya existe!";
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

        public List<PersonaBE> ListarPersona(PaginadoBE paginado, ref int totalFilas)
        {
            List<PersonaBE> lstPersona = new List<PersonaBE>();
            PersonaBE objPersona;
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_LISTAR_PERSONA", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Page", SqlDbType.Int).Value = paginado.NumeroPagina;
                command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = paginado.NumeroFilas;
                //command.Parameters.Add("@RowsCount", SqlDbType.Int);
                //command.Parameters["@RowsCount"].Direction = ParameterDirection.Output;
                //SqlParameter outParam = command.Parameters.Add("@RowsCount", SqlDbType.Int);
                //outParam.Direction = ParameterDirection.Output;


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
         

                        
                            while (reader.Read())
                            {
                            
                                objPersona = new PersonaBE();
                                objPersona.Codigo = Convert.ToInt32(reader[0]);
                                objPersona.Nombre = Convert.ToString(reader[1]);
                                objPersona.ApellidoPaterno = Convert.ToString(reader[2]);
                                objPersona.ApellidoMaterno = Convert.ToString(reader[3]);
                                objPersona.TipoDocumento = new TipoDocumentoBE();
                                objPersona.TipoDocumento.Codigo = Convert.ToInt32(reader[4]);
                                objPersona.NumeroDocumento = Convert.ToString(reader[5]);
                                objPersona.FechaNacimiento = Convert.ToDateTime(reader[6]);

                                objPersona.Estado = new EstadoBE();
                                objPersona.Estado.Codigo = Convert.ToInt32(reader[7]);
                                lstPersona.Add(objPersona);
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

            return lstPersona;
        }

        public PersonaBE ObtenerPersona(int codigo)
        {
            PersonaBE objPersona = new PersonaBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_OBTENER_PERSONA", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;
               
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        objPersona = new PersonaBE();
                        objPersona.Codigo = Convert.ToInt32(reader[0]);
                        objPersona.Nombre = Convert.ToString(reader[1]);
                        objPersona.ApellidoPaterno = Convert.ToString(reader[2]);
                        objPersona.ApellidoMaterno = Convert.ToString(reader[3]);
                        objPersona.TipoDocumento = new TipoDocumentoBE();
                        objPersona.TipoDocumento.Codigo = Convert.ToInt32(reader[4]);
                        objPersona.TipoDocumento.Descripcion = Convert.ToString(reader[5]);
                        objPersona.TipoDocumento.Estado = new EstadoBE();
                        objPersona.TipoDocumento.Estado.Codigo = Convert.ToInt32(reader[6]);
                        objPersona.TipoDocumento.Estado.Descripcion = Convert.ToString(reader[7]);

                       
                        objPersona.NumeroDocumento = Convert.ToString(reader[8]);
                        objPersona.FechaNacimiento = Convert.ToDateTime(reader[9]);
                       
                        objPersona.Estado = new EstadoBE();
                        objPersona.Estado.Codigo = Convert.ToInt32(reader[10]);
                        objPersona.Estado.Descripcion = Convert.ToString(reader[11]);

                    }
                }
                catch (Exception ex)
                {

                }
                connection.Close();
            }

            return objPersona;
        }
    }
}
