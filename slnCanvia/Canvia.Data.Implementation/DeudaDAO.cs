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
    public class DeudaDAO : IDeudaDAO
    {
        private static string cn = ConfigurationManager.ConnectionStrings["Apps"].ConnectionString;
        public List<DeudaBE> ListarDeuda(PaginadoBE paginado, ref int totalFilas)
        {
            List<DeudaBE> lstDeuda = new List<DeudaBE>();
            DeudaBE objDeuda;
            using (SqlConnection connection = new SqlConnection(cn))
            {
                SqlCommand command = new SqlCommand("USP_LISTAR_DEUDA", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Page", SqlDbType.Int).Value = paginado.NumeroPagina;
                command.Parameters.Add("@RowsPerPage", SqlDbType.Int).Value = paginado.NumeroFilas;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {

                        objDeuda = new DeudaBE();
                        objDeuda.Codigo = Convert.ToInt32(reader[0]);
                        objDeuda.Persona = new PersonaBE() { 
                            Codigo = Convert.ToInt32(reader[1]),
                            Nombre = Convert.ToString(reader[2]),
                            ApellidoPaterno = Convert.ToString(reader[3]),
                            ApellidoMaterno = Convert.ToString(reader[4]),

                        };
                        objDeuda.Descripcion = Convert.ToString(reader[5]);
                        objDeuda.Monto = Convert.ToDecimal(reader[6]);
                        objDeuda.EstadoPago = new EstadoPagoBE() {
                            Codigo = Convert.ToInt32(reader[7]),
                            Descripcion = Convert.ToString(reader[8]),
                        };
                        objDeuda.Fecha = Convert.ToDateTime(reader[9]);
                        lstDeuda.Add(objDeuda);
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

            return lstDeuda;
        }
    }
}
