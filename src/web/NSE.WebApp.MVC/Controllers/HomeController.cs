using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : MainController
    {
        [Route("sistema-indisponivel")]
        public IActionResult SistemaIndiponivel()
        {
            var modelErro = new ErrorViewModel
            {
                Titulo = "Sistema indisponível!",
                Mensagem = "O sistema está temporariamente fora do ar!",
                ErroCode = 500
            };

            return View("Error", modelErro);
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde, ou contate o suporte!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Titulo = "Ops! Página não encontrada!";
                modelErro.Mensagem = "A página procurada não existe. <br/> Em caso de dúvida contate o suporte!";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Titulo = "Acesso negado!";
                modelErro.Mensagem = "Você não tem permissão para acessar esta página!";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}

