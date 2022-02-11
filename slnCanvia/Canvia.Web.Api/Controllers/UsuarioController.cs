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
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioLogic _usuarioLogic;
        public UsuarioController(IUsuarioLogic usuarioLogic)
        {
            _usuarioLogic = usuarioLogic;
        }

        [HttpGet]
        [Route("getUser/{codigo}")]
        public HttpResponseMessage GetUser(int codigo)
        {
            var result = _usuarioLogic.ObtenerUsuario(codigo);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("insertUser")]
        public HttpResponseMessage InsertPerson(UsuarioBE usuario)
        {
            var result = _usuarioLogic.InsertarUsuario(usuario);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("updateUser")]
        public HttpResponseMessage UpdateUser(UsuarioBE usuario)
        {
            var result = _usuarioLogic.ActualizarUsuario(usuario);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("deleteUser/{codigo}")]
        public HttpResponseMessage DeleteUser(int codigo)
        {
            var result = _usuarioLogic.EliminarUsuario(codigo);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        [HttpGet]
        [Route("listUser/{pagina}/{filas}")]
        public HttpResponseMessage ListUser(int pagina, int filas)
        {
            int totalFilas = 0;
            var result = _usuarioLogic.ListarUsuario(new PaginadoBE() { NumeroFilas = filas, NumeroPagina = pagina }, ref totalFilas);
            ResponsePaginado<List<UsuarioBE>> responsePag = new ResponsePaginado<List<UsuarioBE>>() { totalFilas = totalFilas, data = result };
            return Request.CreateResponse(HttpStatusCode.OK, responsePag);
        }
    }
}
