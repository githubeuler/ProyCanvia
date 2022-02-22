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
    [RoutePrefix("api/deudadetalle")]
    public class DeudaDetalleController : ApiController
    {
        private readonly IDeudaDetalleLogic _deudaDetalleLogic;
        public DeudaDetalleController(IDeudaDetalleLogic deudaDetalleLogic)
        {
            _deudaDetalleLogic = deudaDetalleLogic;
        }

        [HttpGet]
        [Route("listDebtDet/{codigo}/{pagina}/{filas}")]
        public HttpResponseMessage ListDebtDet(int codigo,int pagina, int filas)
        {
            string totalFilas = "";
            var result = _deudaDetalleLogic.ListarDeudaDetalle(codigo,new PaginadoBE() { NumeroFilas = filas, NumeroPagina = pagina }, ref totalFilas);
            ResponsePaginado<List<DeudaDetalleBE>> responsePag = new ResponsePaginado<List<DeudaDetalleBE>>() { totalFilas = Convert.ToInt32(totalFilas.Split(',')[0]),montoTotal = Convert.ToInt32(totalFilas.Split(',')[1]), data = result };
            return Request.CreateResponse(HttpStatusCode.OK, responsePag);
        }

        [HttpPost]
        [Route("insertPayDebt")]
        public HttpResponseMessage InsertPagoDeuda(DeudaDetalleBE deuda)
        {
            var result = _deudaDetalleLogic.InsertarPagoDeuda(deuda);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


    }
}
