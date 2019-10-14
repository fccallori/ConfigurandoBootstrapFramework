using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurandoBootstrapFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConfigurandoBootstrapFramework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Agenda");
        }

        [HttpPost]
        public ViewResult Agenda(Compromisso compromisso)
        {
            if (!compromisso.AceitaTermos)
            {
                ModelState.AddModelError(nameof(compromisso.AceitaTermos),
                "Você deve aceitar os termos");
            }

            if (ModelState.GetValidationState("Data") == ModelValidationState.Valid && DateTime.Now > compromisso.Data)
            {
                ModelState.AddModelError(nameof(compromisso.Data),
                "Informe uma data futura");
            }

            if (string.IsNullOrEmpty(compromisso.NomeCliente))
            {
                ModelState.AddModelError(nameof(compromisso.NomeCliente),
                "Informe seu nome");
            }

            if (ModelState.GetValidationState(nameof(compromisso.Data))
                    == ModelValidationState.Valid
                    && ModelState.GetValidationState(nameof(compromisso.NomeCliente))
                    == ModelValidationState.Valid
                    && compromisso.NomeCliente.Equals("Alice", StringComparison.OrdinalIgnoreCase)
                    && compromisso.Data.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                "Alice não pode ser agendada na segunda-feira");
            }

            if (ModelState.IsValid)
            {
                return View("Completo", compromisso);
            }
            else
            {
                return View();
            }     
        }
        [HttpGet]
        public IActionResult Compra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compra(Compra compra)
        {
            if (ModelState.IsValid)
            {
                return View("CompraConfirmado", compra);
            }
            else
            {
                return View(compra);
            }
        }
    }
}
