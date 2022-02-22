using Canvia.Business.Contract;
using Canvia.Business.Entities;
using Canvia.Data.Contract;
using Canvia.Data.Factory.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Implementation
{
    public class DeudaDetalleLogic : IDeudaDetalleLogic
    {
        private readonly ICanviaDAOFactory Factory;
        private readonly IDeudaDetalleDAO deudadetalleDAO;

        public DeudaDetalleLogic(ICanviaDAOFactory _factory)
        {
            this.Factory = _factory;
            this.deudadetalleDAO = this.Factory.GetDeudaDetalleDAO();
        }

        public ResultBE InsertarPagoDeuda(DeudaDetalleBE deuda)
        {
            var result = this.deudadetalleDAO.InsertarPagoDeuda(deuda);
            return result;
        }

        public List<DeudaDetalleBE> ListarDeudaDetalle(int codigo,PaginadoBE paginado, ref string totalFilas)
        {
            var result = this.deudadetalleDAO.ListarDeudaDetalle(codigo,paginado, ref totalFilas);
            return result;
        }
    }
}
