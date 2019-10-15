using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurandoBootstrapFramework.Models
{
    public class Compromisso
    {
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public bool AceitaTermos { get; set; }

        [Required]
        [Display(Name = "Assunto")]
        public string Assunto { get; set; }

        [Required]
        [Display(Name = "qtdePessoa")]
        public int qtdePessoa { get; set; }
    }
}
