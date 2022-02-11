using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Contract
{
    public interface IPersonaLogic
    {
        ResultBE InsertarPersona(PersonaBE persona);
        ResultBE ActualizarPersona(PersonaBE persona);
        ResultBE EliminarPersona(int codigo);
        List<PersonaBE> ListarPersona(PaginadoBE paginado, ref int totalFilas);
        PersonaBE ObtenerPersona(int codigo);
    }
}
