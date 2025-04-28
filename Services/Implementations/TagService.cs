using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MK.Data;
using MK.DTO;
using MK.Models;
using MK.Services.Interfaces;
using MK.Exceptions;


namespace MK.Services.Implementations;

public class TagService : ITagService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TagService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TagDto>> GetAllAsync()
    {
        var tags = await _context.Tags
            .Where(t => t.Quotes.Any())
            .ToListAsync();
        return _mapper.Map<List<TagDto>>(tags);
    }

    public async Task<TagDto> GetByIdAsync(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            throw new ApiException("Tag not found.", 404);
        }
        return _mapper.Map<TagDto>(tag);
    }

    public async Task<TagDto> CreateAsync(TagDto dto)
    {
        var tag = _mapper.Map<Tag>(dto);
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return _mapper.Map<TagDto>(tag);
    }

    public async Task<TagDto> UpdateAsync(int id, TagDto dto)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            throw new ApiException("Tag not found.", 404);
        }
        _mapper.Map(dto, tag);
        await _context.SaveChangesAsync();
        return _mapper.Map<TagDto>(tag);
    }

    public async Task DeleteAsync(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            throw new ApiException("Tag not found.", 404);
        }
        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
    }
}