using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class TipoCredito
    {
        public int IdTipoCredito { get; set; }
        public string Nombre { get; set; }
        public List<object> Tipos { get; set; }
    }
}
