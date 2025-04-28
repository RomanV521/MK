namespace MK.Models;

public class Quote
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}