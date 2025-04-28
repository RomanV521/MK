using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MK.Data;
using MK.DTO;
using MK.Models;
using MK.Services.Interfaces;
using MK.Exceptions;

namespace MK.Services.Implementations;

public class QuoteService : IQuoteService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public QuoteService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<QuoteDto>> GetAllAsync()
    {
        var quotes = await _context.Quotes
            .Include(q => q.Author)
            .Include(q => q.Tags)
            .ToListAsync();
        return _mapper.Map<List<QuoteDto>>(quotes);
    }

    public async Task<QuoteDto> GetByIdAsync(int id)
    {
        var quote = await _context.Quotes
            .Include(q => q.Author)
            .Include(q => q.Tags)
            .FirstOrDefaultAsync(q => q.Id == id);
        if (quote == null)
        {
            throw new ApiException("Quote not found.", 404);
        }
        return _mapper.Map<QuoteDto>(quote);
    }

    public async Task<QuoteDto> CreateAsync(QuoteCreateDto dto, int userId)
    {
        var quote = _mapper.Map<Quote>(dto);
        quote.CreatedById = userId;

        // Обробка тегів
        quote.Tags = new List<Tag>();
        foreach (var tagName in dto.TagNames)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
            if (tag == null)
            {
                tag = new Tag { Name = tagName };
                _context.Tags.Add(tag);
            }
            quote.Tags.Add(tag);
        }

        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();
        return _mapper.Map<QuoteDto>(quote);
    }

    public async Task<QuoteDto> UpdateAsync(int id, QuoteUpdateDto dto)
    {
        var quote = await _context.Quotes
            .Include(q => q.Tags)
            .FirstOrDefaultAsync(q => q.Id == id);
        if (quote == null)
        {
            throw new ApiException("Quote not found.", 404);
        }

        _mapper.Map(dto, quote);
        if (dto.TagNames != null)
        {
            quote.Tags.Clear();
            foreach (var tagName in dto.TagNames)
            {
                var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    _context.Tags.Add(tag);
                }
                quote.Tags.Add(tag);
            }
        }

        await _context.SaveChangesAsync();
        return _mapper.Map<QuoteDto>(quote);
    }

    public async Task DeleteAsync(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null)
        {
            throw new ApiException("Quote not found.", 404);
        }
        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();
    }

    public async Task<QuoteDto> GetRandomAsync(string? tag)
    {
        IQueryable<Quote> query = _context.Quotes
            .Include(q => q.Author)
            .Include(q => q.Tags);

        if (!string.IsNullOrEmpty(tag))
        {
            query = query.Where(q => q.Tags.Any(t => t.Name == tag));
        }

        var quotes = await query.ToListAsync();
        if (!quotes.Any())
        {
            throw new ApiException("No quotes found.", 404);
        }

        var random = new Random();
        var randomQuote = quotes[random.Next(quotes.Count)];
        return _mapper.Map<QuoteDto>(randomQuote);
    }
}