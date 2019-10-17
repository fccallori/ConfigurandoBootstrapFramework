using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurandoBootstrapFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurandoBootstrapFramework.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            return View("Resultado", new Resultado { Controller = nameof(AdminController), Action = nameof(Index) });
        }
    }
}
