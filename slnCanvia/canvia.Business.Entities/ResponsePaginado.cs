using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvia.Business.Entities
{
    public class ResponsePaginado<T>
    {
        public int totalFilas { get; set; }
        public T data { get; set; }
    }
}
