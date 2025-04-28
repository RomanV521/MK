using MK.Models;

namespace MK.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(string username, string password);
        Task<User> CreateAsync(string username, string password);
    }
}
