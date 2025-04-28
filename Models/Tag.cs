namespace MK.Models;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}