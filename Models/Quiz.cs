namespace biochallenge.Models;

public class Quiz
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Question { get; set; }
	public string Hint { get; set; } = string.Empty;
	public ICollection<string> Images { get; set; } = new List<string>();
	public TimeOnly Duration { get; set; }

	public virtual ICollection<Options> Options { get; set; }
}
