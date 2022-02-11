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
    public class UsuarioLogic : IUsuarioLogic
    {
        private readonly ICanviaDAOFactory Factory;
        private readonly IUsuarioDAO usuarioDAO;

        public UsuarioLogic(ICanviaDAOFactory _factory)
        {
            this.Factory = _factory;
            this.usuarioDAO = this.Factory.GetUsuarioDAO();
        }

        public ResultBE ActualizarUsuario(UsuarioBE persona)
        {
            var result = this.usuarioDAO.ActualizarUsuario(persona);
            return result;
        }

        public ResultBE EliminarUsuario(int codigo)
        {
            var result = this.usuarioDAO.EliminarUsuario(codigo);
            return result;
        }

        public ResultBE InsertarUsuario(UsuarioBE persona)
        {
            var result = this.usuarioDAO.InsertarUsuario(persona);
            return result;
        }

        public List<UsuarioBE> ListarUsuario(PaginadoBE paginado, ref int totalFilas)
        {
            var result = this.usuarioDAO.ListarUsuario(paginado,ref totalFilas);
            return result;
        }

        public UsuarioBE ObtenerUsuario(int codigo)
        {
            var result = this.usuarioDAO.ObtenerUsuario(codigo);
            return result;
        }
    }
}
