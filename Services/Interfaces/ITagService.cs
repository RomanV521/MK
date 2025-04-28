using MK.DTO;

namespace MK.Services.Interfaces;

public interface ITagService
{
    Task<List<TagDto>> GetAllAsync();
    Task<TagDto> GetByIdAsync(int id);
    Task<TagDto> CreateAsync(TagDto dto);
    Task<TagDto> UpdateAsync(int id, TagDto dto);
    Task DeleteAsync(int id);
}