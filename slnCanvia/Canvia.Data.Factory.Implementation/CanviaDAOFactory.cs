using Canvia.Data.Contract;
using Canvia.Data.Factory.Contract;
using Canvia.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Data.Factory.Implementation
{
    public class CanviaDAOFactory : ICanviaDAOFactory
    {
        public IPersonaDAO GetPersonaDAO()
        {
            return new PersonaDAO();
        }

        public IUsuarioDAO GetUsuarioDAO()
        {
            return new UsuarioDAO();
        }
    }
}
