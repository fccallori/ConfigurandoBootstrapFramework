using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurandoBootstrapFramework.Models
{
    public class Compromisso
    {
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public bool AceitaTermos { get; set; }
    }
}
