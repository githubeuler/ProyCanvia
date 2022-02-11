using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Entities
{
    public class EstadoCivilBE
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public EstadoBE Estado { get; set; }
    }
}
