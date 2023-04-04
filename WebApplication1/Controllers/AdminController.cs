using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

// Também posso mudar a ROTA da Classe/Controller, inclusive adicionar mais camada através da " / ".
[Route("admin/panel")]
// Um Controller deve herdar de Controller
public class AdminController : Controller
{
    // É OBRIGATÓRIO QUE VOCÊ ATRIBUA UMA ROTA A TODOS OS MÉTODOS, CASO VOCÊ MUDE A ROTA DA CLASSE, mas se você não mudar, o próprio asp.net fará isso para você, e você poderá acessar a ACTION/Método através do NOME PADRÃO do CONTROLLER.

    // a rota principal/index pode ser chamada com espaço vazio.
    [Route("")]
    // Você pode dar MAIS de UMA ROTA para uma ACTION/MÉTODO
    [Route("index")]
    // Também Podemos usar uma forma MAIS ESPECÍFICA E DIZERMOS QUAL O TIPO DE VERBO/AÇÃO HTTP QUE O MÉTODO EXECUTA PARA O USUÁRIO, isso muda apenas a legibilidade.
    [HttpGet("indexget")]
    public IActionResult Index()
    {
        // Um Content é um conteúodo, pode ser qualquer Coisa.
        return Content("Teste antigo");
    }

    // Você pode dar MAIS de UMA ROTA para uma ACTION/MÉTODO
    [Route("testandonovamente")]
    [Route("testando")]
    // Também Podemos usar uma forma MAIS ESPECÍFICA E DIZERMOS QUAL O TIPO DE VERBO/AÇÃO HTTP QUE O MÉTODO EXECUTA PARA O USUÁRIO, isso muda apenas a legibilidade.
    // IMPORTANTE, mas vale citar que para alterar a ROTA do CONTROLLER/CLASSE, só se usa o ROUTE, agora para suas ACTIONS/MÉTODOS fica a teu critério.
    [HttpGet("testando3")]
    public IActionResult Testando()
    {
        return Content("Esse é um novo teste");
    }
    
    // AGORA A APARTE LEGAL, PODEMOS PASSAR VALORES/PARÂMETROS VIA ROTA
    // Você colocará o NOME da variável temporária que irá segurar o valor digitado pelo usuário ENTRE {CHAVES}
    [HttpGet("qualseunome/{nome}")]
    // Agora basta apenas que o NOME do seu PARÃMETRO/VARIÁVEL TEMP da ROTA, seja o MESMO nome do PARÂMETRO RECEBIDO PELA ACTION/MÉTODO.
    // o próprio ASP.NET pegará o VALOR digitado pelo usuário e ATRIBUIRÁ a sua VARIÁVEL DA ACTION, para isso elas tem que OBRIGATORIAMENTE ter o MESMO NOME.
    // OBS: caso o nome do parâmetro na ROTA esteja DIFERTE do parâmetro da ACTION, ele acessará a ROTA, porém não conseguirá passar o valor digitado pelo usuário.
    public IActionResult DizendoNome(string nome)
    {
        return Content($"Olá {nome}, Seja Bem Vindo!");
    }

    // também PODEMOS VALIDAR/TIPAR os VALORES passodos pelo usuário via ROTA, assim fazemos com que o usuário passe um VALOR do TIPO ESPERADO.
    [HttpGet("qualsuaidade/{idade:int}")] 
    public IActionResult DizendoIdade(int idade)
    {
        return Content($"Sua idade é {idade}");
    }
    
    // Outra coisa que podemos fazer é TORNAR os PARÂMETROS "OPCIONAIS", basta apenas que adicionemos o SÍMBOLO de INTERROGAÇÃO, como se fossemos deixar a variável NULLABLE.
    [HttpGet("nomeeidade/{nome?}/{idade?}")]
    public IActionResult IdadeENome(string nome, int idade)
    {
        return Content($"O seu nome é: {nome}, sua idade é: {idade}");
    }
    
    // Usando Query Strings
    // Uma OUTRA maneira de RECEBER INFORMAÇÕES, MAS SEM USAR PARÂMETROS são com as "QUERY STRINGS", basicamente você passa a informação para a REQUISIÇÃO/NAVEGADOR dai você pegar a informação através dele, via "INDEXAÇÃO", imagine como se você usasse famoso string[] args para passar parâmetros via console.
    [HttpGet("qualseunome2")]
    public IActionResult QualseuNome2()
    {
        // Recebendo o valor digitado pelo usuário atrvés da requisição.
        string nome = Request.Query["nome"];
        return Content($"Olá {nome} como tem passado ?");
    }
    // A sintaxe da ROTA para acessar esse método fica assim:
    // qualseunome2?nome=andrey
    // "NOME DA ROTA" seguido pela "INTERROGAÇÃO" "NOME DA VARIÁVEL QUE RECEBERÁ O VALOR DIGITADO PELO USUÁRIO" e o "VALOR DIGITADO PELO USUÁRIO".
    // assim: nomeDaRota?nomeVar=ValorDigitado
    
    // RETORNANDO UMA PÁGINA HTML
    // uma VIEW é uma página HTML
    [HttpGet("visualizar")]
    // as VIEWS, arquivo HTML deve estar dentro de uma Pasta com o NOME do CONTROLLER que exibirá ela, ela também deve estar dentro da pasta "VIEW".
    // OBS: as VIEWS OBRIGATORIAMENTE DEVEM POSSUIR O MESMO NOME DO MÉTODO, aqui no caso o nome será Visualizar, também devem ter a EXTENSÃO de arquivo "CSHTML".
    public IActionResult Visualizar()
    {
        // Pegando o valor digitado pelo usuário e passando para a View, para assim poder chamar essa ViewData Criada dentro do meu Html.
        ViewData["nome"] = Request.Query["nome"];
        
        // Aqui também podemos retornar uma View diferente da que é chamada pelo padrão, porém ela tem que estar dentro da MESMA pasta da VIEW PADRÃO.
        //return View("OutraPagina");

        // OBS: View padrão é aquela que é chamada quando não passamos nada, é a que tem o mesmo NOME que a ACTION/MÉTODO.
        return View();
    }
    
    
}