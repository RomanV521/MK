using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MK.DTO;
using MK.Services.Interfaces;
using System.Security.Claims;

namespace MK.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IQuoteService _quoteService;

    public QuotesController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _quoteService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _quoteService.GetByIdAsync(id));

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(QuoteCreateDto dto)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized();
        }
        var userId = int.Parse(userIdClaim);

        return Ok(await _quoteService.CreateAsync(dto, userId));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, QuoteUpdateDto dto) => Ok(await _quoteService.UpdateAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _quoteService.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandom([FromQuery] string? tag = null)
    {
        return Ok(await _quoteService.GetRandomAsync(tag));
    }
}