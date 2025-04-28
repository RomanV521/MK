namespace MK.DTO;

public class QuoteCreateDto
{
    public string Text { get; set; } = null!;
    public int AuthorId { get; set; }
    public List<string> TagNames { get; set; } = new List<string>();
    public List<string> Tags { get; set; } = new();
}