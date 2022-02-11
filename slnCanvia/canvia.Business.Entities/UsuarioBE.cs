using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Entities
{
    public class UsuarioBE
    {
        public int Codigo { get; set; }
        public PersonaBE Persona { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public EstadoBE Estado { get; set; }

    }
}
