using Canvia.Business.Contract;
using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Canvia.Web.Api.Controllers
{
    [RoutePrefix("api/deuda")]
    public class DeudaController : ApiController
    {
        private readonly IDeudaLogic _deudaLogic;
        public DeudaController(IDeudaLogic deudaLogic)
        {
            _deudaLogic = deudaLogic;
        }

        [HttpGet]
        [Route("listDebt/{pagina}/{filas}")]
        public HttpResponseMessage ListDebt(int pagina, int filas)
        {
            int totalFilas = 0;
            var result = _deudaLogic.ListarDeuda(new PaginadoBE() { NumeroFilas = filas, NumeroPagina = pagina }, ref totalFilas);
            ResponsePaginado<List<DeudaBE>> responsePag = new ResponsePaginado<List<DeudaBE>>() { totalFilas = totalFilas, data = result };
            return Request.CreateResponse(HttpStatusCode.OK, responsePag);
        }
    }
}
