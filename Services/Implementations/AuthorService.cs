using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MK.Data;
using MK.DTO;
using MK.Models;
using MK.Services.Interfaces;
using MK.Exceptions;


namespace MK.Services.Implementations;

public class AuthorService : IAuthorService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AuthorService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AuthorDto>> GetAllAsync()
    {
        var authors = await _context.Authors.ToListAsync();
        return _mapper.Map<List<AuthorDto>>(authors);
    }

    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            throw new ApiException("Author not found.", 404);
        }
        return _mapper.Map<AuthorDto>(author);
    }

    public async Task<AuthorDto> CreateAsync(AuthorCreateDto dto)
    {
        var author = _mapper.Map<Author>(dto);
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return _mapper.Map<AuthorDto>(author);
    }

    public async Task<AuthorDto> UpdateAsync(int id, AuthorUpdateDto dto)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            throw new ApiException("Author not found.", 404);
        }
        _mapper.Map(dto, author);
        await _context.SaveChangesAsync();
        return _mapper.Map<AuthorDto>(author);
    }

    public async Task DeleteAsync(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author == null)
        {
            throw new ApiException("Author not found.", 404);
        }
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }
}