using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Data.Contract
{
    public interface IUsuarioDAO
    {
        ResultBE InsertarUsuario(UsuarioBE persona);
        ResultBE ActualizarUsuario(UsuarioBE persona);
        ResultBE EliminarUsuario(int codigo);
        List<UsuarioBE> ListarUsuario(PaginadoBE paginado, ref int totalFilas);
        UsuarioBE ObtenerUsuario(int codigo);
    }
}
