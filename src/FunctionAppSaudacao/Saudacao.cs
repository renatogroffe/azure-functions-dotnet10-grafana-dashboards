using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppSaudacao;

public class FunctionsSaudacao
{
    private readonly ILogger<FunctionsSaudacao> _logger;

    public FunctionsSaudacao(ILogger<FunctionsSaudacao> logger)
    {
        _logger = logger;
    }

    [Function("Saudacao")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("Testando a Function *Saudacao*.");
        return new OkObjectResult(new { Mensagem = "Bem-vindo ao mundo Serverless!" });
    }


    [Function("ErroSaudacao")]
    public IActionResult RunWithError([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("Testando a Function *ErroSaudacao*.");
        return new BadRequestResult();
    }

    [Function("ExceptionSaudacao")]
    public IActionResult RunWithException([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("Testando a Function *ExceptionSaudacao*.");
        throw new InvalidOperationException("Teste com Exception...");
    }
}