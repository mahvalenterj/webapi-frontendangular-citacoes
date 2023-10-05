using Microsoft.AspNetCore.Mvc;
using ProjetFinal.Api.Domain;
using ProjetFinal.Api.Models;
using ProjetFinal.Api.Services;
using System.Net.Mime;

namespace ProjetFinal.Api.Controllers;

/// <summary>
/// Nome do Controller
/// </summary>
[ApiController]
[Route("api/quotes")]
public class QuotesController : ControllerBase
{
    private readonly IQuoteService quoteService;

    /// <summary>
    /// Construtor
    /// </summary>
    public QuotesController(IQuoteService quoteService)
    {
        this.quoteService = quoteService;
    }

    /// <summary>
    /// Retorna todas as cita��es armazenadas na base de dados
    /// </summary>
    /// <response code="200">Retorna todas as cita��es</response>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<Quote>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var quotes = quoteService.GetAll();

        return Ok(quotes);
    }


    /// <summary>
    /// Retorna uma cita��o pelo seu Id
    /// </summary>
    /// <param name="id">Id da Cita��o</param>
    /// <response code="200">Retorna a cita��o cujo id corresponde ao id especificado</response>
    /// <response code="404">N�o foi encontrada uma cita��o correspondente ao id especificado</response>
    [HttpGet("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Xml)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Quote), StatusCodes.Status200OK)]
    public IActionResult GetById(int id)
    {
        var quote = quoteService.GetById(id);

        if (quote == null)
            return NotFound();

        return Ok(quote);
    }

    /// <summary>
    /// Adiciona uma cita��o no banco de dados
    /// </summary>
    /// <param name="model">Cita��o que deve ser adicionada</param>
    /// <response code="201">Cita��o criada com sucesso</response>
    [HttpPost]
    [ProducesResponseType(typeof(QuoteModel), StatusCodes.Status201Created)]
    public IActionResult Create(QuoteModel model)
    {
        var quote = quoteService.Create(model);

        // Usar o ID da cita��o criada como valor para o par�metro "id"
        return CreatedAtAction(nameof(GetById), new { id = quote.Id }, quote);
    }


    /// <summary>
    /// Atualiza uma cita��o do banco de dados
    /// </summary>
    /// <param name="model">Cita��o que deve ser atualizada</param>
    /// <response code="200">Cita��o atualizada com sucesso</response>
    /// <response code="404">N�o foi encontrada uma cita��o correspondente ao id especificado</response>
    [HttpPut]
    public IActionResult Update(QuoteUpdateModel model)
    {
        var quote = quoteService.Update(model);

        if (quote == null)
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Apaga uma cita��o do banco de dados
    /// </summary>
    /// <param name="id"></param>
    /// <response code="200">Cita��o removida com sucesso</response>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return Ok();
    }
}
