using Canvia.Data.Contract;
using Canvia.Data.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Data.Factory.Contract
{
    public interface ICanviaDAOFactory
    {
        IPersonaDAO GetPersonaDAO();
        IUsuarioDAO GetUsuarioDAO();

    }
}
