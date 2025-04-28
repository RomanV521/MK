using Microsoft.EntityFrameworkCore;
using MK.Data;
using MK.Models;
using MK.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace MK.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> AuthenticateAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null || !VerifyPassword(password, user.PasswordHash))
        {
            return null;
        }
        return user;
    }


    public async Task<User> CreateAsync(string username, string password)
    {
        var user = new User
        {
            Username = username,
            PasswordHash = HashPassword(password)
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }
}