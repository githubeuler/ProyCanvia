using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Entities
{
    public class DeudaBE
    {
        public int Codigo { get; set; }
        public PersonaBE Persona { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public EstadoPagoBE EstadoPago { get; set; }
        public DateTime Fecha { get; set; }
    }
}
