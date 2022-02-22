using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Contract
{
    public interface IDeudaLogic
    {
        List<DeudaBE> ListarDeuda(PaginadoBE paginado, ref int totalFilas);
    }
}
