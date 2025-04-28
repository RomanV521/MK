using MK.DTO;

namespace MK.Services.Interfaces;

public interface IAuthorService
{
    Task<List<AuthorDto>> GetAllAsync();
    Task<AuthorDto> GetByIdAsync(int id);
    Task<AuthorDto> CreateAsync(AuthorCreateDto dto);
    Task<AuthorDto> UpdateAsync(int id, AuthorUpdateDto dto);
    Task DeleteAsync(int id);
}