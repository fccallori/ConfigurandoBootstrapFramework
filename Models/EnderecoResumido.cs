﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurandoBootstrapFramework.Models
{
    //[Bind(nameof(Cidade))]
    public class EnderecoResumido
    {
        public string Cidade { get; set; }

      //  [BindNever]
        public string Pais { get; set; }
    }
}
