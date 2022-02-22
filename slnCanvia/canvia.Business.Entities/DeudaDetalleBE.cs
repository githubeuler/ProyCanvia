using Canvia.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Entities
{
    public class DeudaDetalleBE
    {
        //iIdDeudaDetalle INT IDENTITY(1,1),
        //iIdDeuda INT NOT NULL,
        //dMonto DECIMAL(15,2) NOT NULL,
        //dFecha DATETIME NOT NULL DEFAULT GETDATE()
        public int Codigo { get; set; }
        public DeudaBE Deuda { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

    }
}
