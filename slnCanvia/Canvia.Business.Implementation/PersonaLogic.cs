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
    public class PersonaLogic : IPersonaLogic
    {
        private readonly ICanviaDAOFactory Factory;
        private readonly IPersonaDAO personaDAO;

        public PersonaLogic(ICanviaDAOFactory _factory) 
        {
            this.Factory = _factory;
            this.personaDAO = this.Factory.GetPersonaDAO();
        }
        public ResultBE ActualizarPersona(PersonaBE persona)
        {
            var result = this.personaDAO.ActualizarPersona(persona);
            return result;
        }

        public ResultBE EliminarPersona(int codigo)
        {
            var result = this.personaDAO.EliminarPersona(codigo);
            return result;
        }

        public ResultBE InsertarPersona(PersonaBE persona)
        {
            var result = this.personaDAO.InsertarPersona(persona);
            return result;
        }

        public List<PersonaBE> ListarPersona(PaginadoBE paginado, ref int totalFilas)
        {
            var result = this.personaDAO.ListarPersona(paginado, ref totalFilas);
            return result;
        }

        public PersonaBE ObtenerPersona(int codigo)
        {
            var result = this.personaDAO.ObtenerPersona(codigo);
            return result;
        }
    }
}
