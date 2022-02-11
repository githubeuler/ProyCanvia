using Canvia.Business.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Canvia.WebApi.Controllers
{
    [Route("api/persona")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaLogic _personaLogic;

        public PersonaController(IPersonaLogic personaLogic) 
        {
            _personaLogic = personaLogic;
        }
        public PersonaController()
        {
          
        }

        [HttpGet]
        [Route("obtenerPersona/{codigo}")]
        public HttpResponseMessage GetPersona(int codigo)
        {
            var result = _personaLogic.ObtenerPersona(codigo);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
