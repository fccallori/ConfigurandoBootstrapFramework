﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurandoBootstrapFramework.Models
{
    public class Resultado
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public IDictionary<string, object> Data { get; } = new Dictionary<string, object>();
    }
}
