using Microsoft.AspNetCore.Mvc;
using MK.DTO;
using MK.Services.Interfaces;

namespace MK.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagsController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _tagService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _tagService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(TagDto dto) => Ok(await _tagService.CreateAsync(dto));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TagDto dto) => Ok(await _tagService.UpdateAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _tagService.DeleteAsync(id);
        return NoContent();
    }
}