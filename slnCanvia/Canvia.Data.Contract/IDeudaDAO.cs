using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Data.Contract
{
    public interface IDeudaDAO
    {
        List<DeudaBE> ListarDeuda(PaginadoBE paginado, ref int totalFilas);
    }
}
