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
    public class DeudaDetalleDAO : IDeudaDetalleDAO
    {
        private static string cn = ConfigurationManager.ConnectionStrings["Apps"].ConnectionString;

        public ResultBE InsertarPagoDeuda(DeudaDetalleBE deuda)
        {
            ResultBE result = new ResultBE();
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_INSERTAR_PAGO_DEUDA", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@IdDeuda", SqlDbType.Int).Value = deuda.Deuda.Codigo;
                command.Parameters.Add("@Monto", SqlDbType.Decimal).Value = deuda.Monto;
                command.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                command.Parameters.Add("@CodigoDetalleDeuda", SqlDbType.Int);
                command.Parameters["@CodigoDetalleDeuda"].Direction = ParameterDirection.Output;

                try
                {
                    connection.Open();
                    result.CodeResult = command.ExecuteNonQuery();
                    deuda.Codigo = Convert.ToInt32(command.Parameters["@CodigoDetalleDeuda"].Value);
                    result.MessageResult = deuda.Codigo.ToString();
                    if (deuda.Codigo == -1)
                    {
                        result.CodeResult = -1;
                        result.MessageResult = "";
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

        public List<DeudaDetalleBE> ListarDeudaDetalle(int codigo,PaginadoBE paginado, ref string totalFilas)
        {
            List<DeudaDetalleBE> lstDeudaDetalle = new List<DeudaDetalleBE>();
            DeudaDetalleBE objDeudaDetalle;
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_LISTAR_DEUDA_DETALLE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;
                command.Parameters.Add("@Page", SqlDbType.Int).Value = paginado.NumeroPagina;
                command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = paginado.NumeroFilas;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {

                        objDeudaDetalle = new DeudaDetalleBE();
                        objDeudaDetalle.Codigo = Convert.ToInt32(reader[0]);
                        objDeudaDetalle.Monto = Convert.ToDecimal(reader[1]);
                        objDeudaDetalle.Fecha = Convert.ToDateTime(reader[2]);
                        lstDeudaDetalle.Add(objDeudaDetalle);
                    }


                    reader.NextResult();

                    while (reader.Read())
                    {

                        totalFilas = Convert.ToString(reader[0]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                }

                command.Dispose();
                connection.Close();
            }

            return lstDeudaDetalle;
        }
    }
}
