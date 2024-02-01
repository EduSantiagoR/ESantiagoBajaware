using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Credito
    {
        public int CodCredito { get; set; }
        public bool Activo { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<object> Creditos { get; set; }
    }
}
