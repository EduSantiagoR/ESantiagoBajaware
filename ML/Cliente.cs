using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
        public Credito Credito { get; set; }
        public List<object> Clientes { get; set; }
        public Cliente()
        {
            EstadoCivil = new EstadoCivil();
            Nacionalidad = new Nacionalidad();
            Credito = new Credito();
        }
    }
}
