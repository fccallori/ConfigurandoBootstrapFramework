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

        public IActionResult Index()
        {
            return View("Agenda");
        }

        [HttpPost]
        public ViewResult Agenda(Compromisso compromisso)
        {
            if ((compromisso.Assunto.Split(" ")).Length <5)
            {
                ModelState.AddModelError(nameof(compromisso.Assunto),
               "O campo Assunto deve ter mais de 5 palavras!");
            }

            if (compromisso.qtdePessoa <= 0)
            {
                ModelState.AddModelError(nameof(compromisso.qtdePessoa),
               "A quantidade de pessoas deve ser maior do que zero!");
            }

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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {

            if (string.IsNullOrEmpty(login.Nome))
            {
                ModelState.AddModelError(nameof(login.Nome),
                "Informe seu email");
            }

            if (string.IsNullOrEmpty(login.Senha))
            {
                ModelState.AddModelError(nameof(login.Senha),
                "Informe sua senha!!");
            }

            if (!login.Nome.Equals("alice@gmail.com") || !login.Senha.Equals("123"))
            {
                if (!login.Nome.Equals("alice@gmail.com"))
                {
                    ModelState.AddModelError(nameof(login.Senha),"Email Incorreto!!");
                }

                if (!login.Senha.Equals("123"))
                {
                    ModelState.AddModelError(nameof(login.Senha), "Senha Incorreta!!");
                }
            }

            if (ModelState.IsValid)
            {
                return View("LoginConfirmado", login);
            }
            else
            {
                return View(login);
            }
        }
    }
}
