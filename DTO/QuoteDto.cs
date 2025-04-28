namespace MK.DTO;

public class QuoteDto
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public int AuthorId { get; set; }
    public string AuthorName { get; set; } = null!;
    public List<string> TagNames { get; set; } = new List<string>();
    public int CreatedById { get; set; }
}