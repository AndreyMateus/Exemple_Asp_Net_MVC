using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WebApplication1.Controllers;

[Route("form/panel")]
public class FormController : Controller
{
    [HttpGet("form")]
    public IActionResult Form()
    {
        return View(); 
    }

    [HttpPost("dados")]
    public IActionResult dados()
    {
        // OBS: É importante dizer que esta forma que estamos usando para capturar os valores do formulário que foram digitados pelo usuário, é a FORMA mais CRU que tem, é a mais MANUAL.
        
        // StringValues é um TIPO que recebe as informações digitadas pelo usuário dentro do formulário.
        StringValues nome;
        StringValues email;
        
        // Pegando o FORMULÁRIO através do REQUEST, e do nome do CAMPO do FORMULÁRIO.
        // a propriedade FORM é uam própriedade da CLASSE REQUEST, onde podemos pegar todo o corpo do formulário.
        // o primeiro parâmetro é o NOME do campo do INPUT do formulário
        // o segundo parâmetro é a VARIÁVEL que irá RECEBER o valor que o TRYGETVALUE trouxe desse campo.
        Request.Form.TryGetValue("nome", out nome);
        // o OUT serve para dizer qual a variável criada dentro da ACTION que receberá o valor do INPUT, ele também serve para forçar com que a variável não possa ter sido inicializada.
        Request.Form.TryGetValue("email", out email);
        
        return Content($"Dados Enviados ! Nome: {nome}, Email: {email}");
    }

}