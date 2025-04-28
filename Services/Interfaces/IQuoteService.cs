using MK.DTO;

namespace MK.Services.Interfaces;

public interface IQuoteService
{
    Task<List<QuoteDto>> GetAllAsync();
    Task<QuoteDto> GetByIdAsync(int id);
    Task<QuoteDto> CreateAsync(QuoteCreateDto dto, int userId);
    Task<QuoteDto> UpdateAsync(int id, QuoteUpdateDto dto);
    Task DeleteAsync(int id);
    Task<QuoteDto> GetRandomAsync(string? tag);
}