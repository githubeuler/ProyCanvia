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
    [RoutePrefix("api/persona")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaLogic _personaLogic;
        public PersonaController(IPersonaLogic personaLogic)
        {
            _personaLogic = personaLogic;
        }

        [HttpGet]
        [Route("getPerson/{codigo}")]
        public HttpResponseMessage GetPerson(int codigo)
        {
            var result = _personaLogic.ObtenerPersona(codigo);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("insertPerson")]
        public HttpResponseMessage InsertPerson(PersonaBE persona)
        {
            var result = _personaLogic.InsertarPersona(persona);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("updatePerson")]
        public HttpResponseMessage UpdatePerson(PersonaBE persona)
        {
            var result = _personaLogic.ActualizarPersona(persona);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("deletePerson/{codigo}")]
        public HttpResponseMessage DeletePerson(int codigo)
        {
            var result = _personaLogic.EliminarPersona(codigo);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpGet]
        [Route("listPerson/{pagina}/{filas}")]
        public HttpResponseMessage ListPerson(int pagina,int filas)
        {
            int totalFilas = 0;
            var result = _personaLogic.ListarPersona(new PaginadoBE() { NumeroFilas = filas,NumeroPagina = pagina},ref totalFilas);
            ResponsePaginado<List<PersonaBE>> responsePag = new ResponsePaginado<List<PersonaBE>>() {totalFilas = totalFilas ,data = result };
            return Request.CreateResponse(HttpStatusCode.OK, responsePag);
        }
    }
}
