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
    public class DeudaLogic : IDeudaLogic
    {
        private readonly ICanviaDAOFactory Factory;
        private readonly IDeudaDAO deudaDAO;

        public DeudaLogic(ICanviaDAOFactory _factory)
        {
            this.Factory = _factory;
            this.deudaDAO = this.Factory.GetDeudaDAO();
        }
        public List<DeudaBE> ListarDeuda(PaginadoBE paginado, ref int totalFilas)
        {
            var result = this.deudaDAO.ListarDeuda(paginado, ref totalFilas);
            return result;
        }
    }
}
