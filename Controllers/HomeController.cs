using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurandoBootstrapFramework.Models;
using ConfigurandoBootstrapFramework.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConfigurandoBootstrapFramework.Controllers
{



    public class HomeController : Controller
    {

        private IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int id)
        {
            return View("Index", repository[id]);
        }

        public ViewResult Index2(int id)
        {
            return View("Index", repository[id] ?? repository.Pessoa.First());
        }

        public IActionResult Index3(int? id)
        {
            Pessoa pessoa;
            if (id.HasValue && (pessoa = repository[id.Value]) != null)
            {
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Cadastro()
        {
            return View("Cadastro", new Pessoa());
        }

        [HttpPost]
        public ViewResult Cadastro(Pessoa pessoa)
        {
            return View("Index", pessoa);
        }

        public ViewResult EnderecoBasico(EnderecoResumido endereco)
        {
            return View("EnderecoBasico", endereco);
        }

        public ViewResult EnderecoBasico2([Bind(Prefix = nameof(Pessoa.EnderecoCasa))] EnderecoResumido endereco)
        {
            return View("EnderecoBasico", endereco);
        }

        public ViewResult EnderecoBasico3([Bind(nameof(EnderecoResumido.Cidade), Prefix = nameof(Pessoa.EnderecoCasa))] EnderecoResumido endereco)
        {
            return View("EnderecoBasico", endereco);
        }

        public ViewResult Nomes(string[] nomes)
        {
            return View("Nomes", nomes ?? new string[0]);
        }

        public ViewResult Nomes2(IList<string> nomes)
        {
            return View("Nomes2", nomes ?? new List<string>());
        }

        public ViewResult Enderecos(IList<EnderecoResumido> enderecos)
        {
            return View("Enderecos", enderecos ?? new List<EnderecoResumido>());
        }

        public IActionResult Index4([FromQuery] int? id)
        {
            Pessoa pessoa;
            if (id.HasValue && (pessoa = repository[id.Value]) != null)
            {
                return View(pessoa);
            }
            else
            {
                return NotFound();
            }
        }

        public string Header([FromHeader]string accept)
        {
            return $"Header: {accept}";
        }

        public string Header2([FromHeader(Name = "Accept-Language")] string accept)
        {
            return $"Header: {accept}";
        }

        public ViewResult Header3(HeaderModel model)
        {
            return View("Header", model);
        }

        [HttpGet]
        public ViewResult Body()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Body([FromBody]Pessoa pessoa)
        {
            return Json(pessoa.Nome);
        }
        /*#####################################ROTAS 
                public ViewResult Index()
                {
                    return View("Resultado", new Resultado { Controller = nameof(HomeController), Action = nameof(Index) });
                }

                public ViewResult Seguimento()
                {
                    Resultado resultado = new Resultado
                    {
                        Controller = nameof(HomeController),
                        Action = nameof(Seguimento),
                    };
                    resultado.Data["id"] = RouteData.Values["id"];
                    return View("Resultado", resultado);
                }

                public ViewResult Parametro(string id)
                {
                    Resultado resultado = new Resultado
                    {
                        Controller = nameof(HomeController),
                        Action = nameof(Seguimento),
                    };
                    resultado.Data["id"] = id;
                    return View("Resultado", resultado);
                }

        ########################################
                */

        /*  [HttpGet]
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

         // public IActionResult Index()
         // {
            //  return View("Agenda");
        //  }

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
          }*/
    }
}
