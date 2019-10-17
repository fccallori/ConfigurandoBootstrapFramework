using ConfigurandoBootstrapFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurandoBootstrapFramework.Repository
{
    public interface IRepository
    {
        IEnumerable<Pessoa> Pessoa { get; }
        Pessoa this[int id] { get; set; }
    }
}
