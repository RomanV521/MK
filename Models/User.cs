namespace MK.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public ICollection<Quote> CreatedQuotes { get; set; } = new List<Quote>();
}