using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Contract
{
    public interface IDeudaDetalleLogic
    {
        List<DeudaDetalleBE> ListarDeudaDetalle(int codigo,PaginadoBE paginado, ref string totalFilas);
        ResultBE InsertarPagoDeuda(DeudaDetalleBE deuda);
    }
}
